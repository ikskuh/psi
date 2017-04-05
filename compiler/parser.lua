local lpeg = require "lpeg"
local re = require "re"

local P = lpeg.P
local S = lpeg.S
local R = lpeg.R
local G = lpeg.G
local B = lpeg.B
local V = lpeg.V
local C = lpeg.C
local Ct = lpeg.Ct

local WS_blank = lpeg.S(" \t\r\n")
local WS_comment_long = (P("#!") * (1 - P("!#"))^0 * P("!#"))
local WS_comment_short = (P("#") * (1 - P("\n"))^0)
local WS  = (WS_blank + WS_comment_long + WS_comment_short)^1
local WSO = WS^0

-- List of binary operators with precedence
local binops = 
{
	-- Highest precedence (binds most)
	{ "**" },
	{ "*", "/", "%" },
	{ "+", "--", "-" },
	{ ">=", ">", "<=", "<" },
	{ "==", "!=" },
	{ "&", "|", "^", "<->", "->", "<-" },
	{ "+=", "-=", "*=", "/=", "%=", "|=", "--=", ":=", "=" },
	-- Lowest precedence (binds least)
}

local function packCondition(cond)
	return (WS * cond * WS) + 
				 (WSO * P"(" * WSO * cond * WSO * P")" * WSO)
end

local function id(foo,...)
	return foo
end
local function exists(foo)
	return foo ~= ""
end

local captures = require "ast-captures"

local totaloplist = { }
for i=1,#binops do
	for j=1,#binops[i] do
		table.insert(totaloplist, binops[i][j])
	end
end

table.sort(totaloplist)

local ANYOPERATOR = P(totaloplist[1])
for i=#totaloplist,2,-1 do
	ANYOPERATOR = ANYOPERATOR + P(totaloplist[i])
end

-- Define the ruleset for Psi
local ruleset = {
	"program",
	program = Ct((WSO * (V"declaration" + V"module") * WSO)^0),
	declaration = (V"assert" + V"import" + V"objdecl") / id,
	module = (P"module" * WSO * V"exname" * WSO * P"{" * WSO * V"program" * WSO * P"}") / captures.module,
	import = (P"import" * WSO * V"exname" * (WSO * P"as" * WSO * V"name")^-1 * WSO * P";") / captures.import,
	objdecl = (((P"export" * WS)^-1) / exists * (V"opdecl" + V"genvardecl" + V"gentypedecl" + V"vardecl" + V"typedecl")) / captures.objectdecl,
	opdecl = (C(P"unary" + P"binary") * WS * P"operator" * WS * P"'" * C(ANYOPERATOR) * P"'" * WSO * P"=" * WSO * V"func" * WSO * P";") / captures.operator,
	vardecl = (C(P"var" + P"const") * WS * V"param" * WSO * P";") / captures.vardecl,
	typedecl = (P"type" * WS * V"name" * WSO * P"=" * WSO * V"type" * WSO * P";") / captures.typedecl,
	genvardecl = (P"generic" * WS * (P"var" + P"const") * WS * V"name" * WSO * V"genparams" * WSO * V"paramspec" * WSO * P";") / captures.genvardecl,
	gentypedecl = (P"generic" * WS * P"type" * WS * V"name" * WSO * V"genparams" * WSO * P"=" * WSO * V"type" * WSO * P";") / captures.gentypedecl,
	genparams = P"<" * WSO * V"paramlist" * WSO * P">",
	assert = (P"assert" * WS * V"expr" * WSO * P";") / captures.assert,
	
	name = C((R("AZ", "az") + S"_")^1),
	exname = Ct(V"name" * (P"." * V"name")^0),
	
	type = ((P"(" * WSO * V"type" * WSO * P")") + V"fndecl" + V"record" + V"gentype" + V"exname" / captures.namedType) / captures.type,
	gentype = (V"exname" * WSO * P"<" * V"exprlist" * WSO * P">") / captures.gentyperef,
	record = (P"record" * WSO * P"(" * WSO * V"paramlist" * WSO * P")") / captures.recordtype,
	fndecl = (P"fn" * WSO * P"(" * WSO * (V"paramlist" * WSO)^-1 * P")" * (WSO * P"->" * WSO * V"type")^-1) / captures.funsig,
	
	paramlist = Ct(V"param" * (WSO * P"," * WSO * V"param")^0),
	param = (V"name" * WSO * V"paramspec") / captures.param,
	paramspec =
						(P":" * WSO * V"type" * WSO * P"=" * WSO * V"expr") / captures.paramspec +
						(P":" * WSO * V"type") / captures.paramspec + 
						(P"=" * WSO * V"expr") / captures.paramspec,
	
	exprlist = Ct(V"expr" * (WSO * P"," * WSO * V"expr")^0),
	-- 'expr' and all 'binop_l*_expr' are generated below
	--expr = V"binop_l0_expr",
	
	-- Handwritten binary operator for indexing fields and metafields
	binop_l0_expr = (V"binop_end" * (
										(C(S".'") * V"name") / captures.fieldindex + 
										(P"[" * WSO * V"exprlist" * WSO * P"]") / captures.arrayindex + 
										(P"(" * WSO * (V"exprlist" * WSO)^-1 * P")") / captures.fncall
									)^0) / captures.indexer,
	binop_end = (V"unop_expr" + V"func" + V"literal" + V"brackexpr") / id,
	
	brackexpr = (P"(" * WSO * V"expr" * WSO * P")") / id,
	unop_expr = (V"unop" * WSO * V"binop_l0_expr") / captures.unop,
	unop = C(S"+-~"),
	
	literal = V"array" + V"number" + V"name" / captures.variableref + V"string",
	number = (V"hexint" + V"real" + V"integer") / id,
	integer = C(S("+-")^-1 * R("09")^1) / captures.number,
	hexint = C(S("+-")^-1 * P"0x" * R("09", "af", "AF")^1) / captures.number,
	real = C(S("+-")^-1 * R("09")^1 * P"." * R("09")^1) / captures.number,
	array = (P"[" * (WSO * V"exprlist")^-1 * WSO * P"]") / captures.array,
	string = P('"') * C((1 - P('"'))^0) * P('"') / captures.string,
	
	func = (V"fndecl" * WSO * (V"body" + P"=>" * WSO * V"expr" / captures.exprinstr)) / captures.func,
	body = Ct(P"{" * (WSO * V"instr")^0 * WSO * P"}"),
	instr = V"declaration" + V"if_instr" + V"select_instr" + V"for_instr" + V"loop_instr" + V"while_instr" + V"goto_instr" + V"return_instr" + V"singleword_instr" + V"expr_instr" + V"body"/captures.bodyinstr + P";",
	
	expr_instr = (V"expr" * WSO * P";") / captures.exprinstr,
	if_instr = (P"if" * packCondition(V"expr") * V"instr" * (WSO * P"else" * WSO * V"instr")^-1) / captures.ifinstr,
	while_instr = (P"while" * packCondition(V"expr") * V"instr") / captures.whileinstr,
	for_instr = (P"for" * packCondition(V"name" * WS * P"in" * WS * V"expr") * V"instr") / captures.forinstr,
	return_instr = (P"return" * (WS * V"expr")^-1 * WSO * P";") / captures.returninstr,
	goto_instr = (P"goto" * WS * V"expr" * WSO * P";") / captures.gotoinstr,
	loop_instr = (P"loop" * WSO * V"instr" * WSO * P"until" * packCondition(V"expr")) / captures.loopinstr,
	singleword_instr = (C(P"break" + P"continue" + P"next") * WSO * P";") / captures.wordinstr,
	select_instr = (P"select" * packCondition(V"expr") * P"{" * WSO * (
									WSO * (P"otherwise" / captures.otherwise + (P"when" * WS * V"expr") / captures.when) * WSO * P":" + 
									WSO * V"instr" * WSO
								 )^0 * WSO * P"}") / captures.selectinstr
}
-- Autogenerate rulesets for binary operators
-- with precedence:
for i=1,#binops do
	local function getExprLevelName(l)
		if l == #binops then
			return "expr"
		else
			return string.format("binop_l%1d_expr", l)
		end
	end
	local ops = binops[i]
	local expr = getExprLevelName(i)
	local subexpr = getExprLevelName(i - 1)
	local opname = string.format("binop_l%1d", i)

	ruleset[opname] = P(ops[1])
	for j=2,#ops do
		ruleset[opname] = ruleset[opname] + P(ops[j])
	end
	
	ruleset[opname] = C(ruleset[opname])
	
	ruleset[expr] = (V(subexpr) * (WSO * V(opname) * WSO * V(subexpr))^0) / captures.binop
end

-- Compile the grammar
local grammar = P(ruleset)

local function parse(str)
	local ast = grammar:match(str)
	if ast == nil then
		error("Failed to parse source!", 2)
	end
	return ast
end

return parse
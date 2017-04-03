local lpeg = require "lpeg"
local re = require "re"

require "print"
inspect = require "inspect"

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

local testsource = 
[==[
import std;

module vars
{
	var idefix = 10;
	var idefix : int;
	var idefix : real = 10.0;
}
]==]

-- List of binary operators with precedence
local binops = 
{
	-- Highest precedence (binds most)
	{ "**" },
	{ "*", "/", "%" },
	{ "+", "-", "--" },
	{ ">=", ">", "<=", "<" },
	{ "==", "!=" },
	{ "&", "|", "^", "->" },
	{ "+=", "-=", "*=", "/=", "%=", "|=", "--=", "=" },
	-- Lowest precedence (binds least)
}

local function packCondition(cond)
	return (WS * cond * WS) + 
				 (WSO * P"(" * WSO * cond * WSO * P")" * WSO)
end

local function id(foo)
	return foo
end
local function exists(foo)
	return foo ~= ""
end

local captures = { }

function captures.import(mod, alias)
	return {
		_TYPE = "import",
		module = mod,
		alias = alias
	}
end

function captures.objectdecl(exported, obj)
	obj.isExported = exported
	return obj
end

function captures.vardecl(const, param)
	return { 
		_TYPE = "vardecl",
		isConst = (const == "const"),
		name = param.name,
		type = param.type,
		value = param.value,
	}
end

function captures.typedecl(...)
	-- print("type", ...)
	return { }
end

function captures.genvardecl(...)
	-- print("genvar", ...)
	return { }
end

function captures.gentypedecl(...)
	-- print("gentype", ...)
	return { }
end

function captures.assert(expr)
	return {
		_TYPE = "assertion",
		expression = expr,
	}
end

function captures.param(name, spec)
	return { 
		_TYPE = "param",
		name = name,
		type = spec.type,
		value = spec.value,
	}
end

function captures.paramspec(type, value)
	if type._TYPE == "expression" then
		value = type
		type = nil
	end
	return {
		type = type,
		value = value,
	}
end

function captures.type(...)
	-- print("type", ...)
	return {
		_TYPE = "type",
	}
end

function captures.expr(...)
	print("expr", ...)
	return {
		_TYPE = "expression",
	}
end

function captures.number(val)
	return {
		_TYPE = "number",
		value = tonumber(val)
	}
end

function captures.string(val)
	return {
		_TYPE = "string",
		value = tostring(val)
	}
end

function captures.module(name, prg)
	return {
		_TYPE = "module",
		name = name,
		contents = prg
	}
end

-- Define the ruleset for Psi
local ruleset = {
	"program",
	program = Ct((WSO * (V"declaration" + V"module") * WSO)^0),
	declaration = (V"assert" + V"import" + V"objdecl") / id,
	module = (P"module" * WSO * V"exname" * WSO * P"{" * WSO * V"program" * WSO * P"}") / captures.module,
	import = (P"import" * WSO * C(V"exname") * (WSO * P"as" * WSO * C(V"name"))^-1 * WSO * P";") / captures.import,
	objdecl = (((P"export" * WS)^-1) / exists * (V"genvardecl" + V"gentypedecl" + V"vardecl" + V"typedecl")) / captures.objectdecl,
	vardecl = (C(P"var" + P"const") * WS * V"param" * WSO * P";") / captures.vardecl,
	typedecl = (P"type" * WS * V"name" * WSO * P"=" * WSO * V"type" * WSO * P";") / captures.typedecl,
	genvardecl = (P"generic" * WS * (P"var" + P"const") * WS * V"name" * WSO * V"genparams" * WSO * V"paramspec" * WSO * P";") / captures.genvardecl,
	gentypedecl = (P"generic" * WS * P"type" * WS * V"name" * WSO * V"genparams" * WSO * P"=" * WSO * V"type" * WSO * P";") / captures.gentypedecl,
	genparams = P"<" * WSO * V"paramlist" * WSO * P">",
	assert = (P"assert" * WS * C(V"expr") * WSO * P";") / captures.assert,
	name = C((R("AZ", "az") + S"_")^1),
	exname = V"name" * (P"." * V"name")^0,
	type = ((P"(" * WSO * V"type" * WSO * P")") + V"fndecl" + V"record" + V"gentype" + V"exname") / captures.type,
	gentype = V"exname" * WSO * P"<" * V"exprlist" * WSO * P">",
	record = P"record" * WSO * P"(" * WSO * V"paramlist" * WSO * P")",
	fndecl = P"fn" * WSO * P"(" * WSO * (V"paramlist" * WSO)^-1 * P")" * (WSO * P"->" * WSO * V"type")^-1,
	paramlist = V"param" * (WSO * P"," * WSO * V"param")^0,
	param = (V"name" * WSO * V"paramspec") / captures.param,
	paramspec =
						(P":" * WSO * V"type" * WSO * P"=" * WSO * V"expr") / captures.paramspec +
						(P":" * WSO * V"type") / captures.paramspec + 
						(P"=" * WSO * V"expr") / captures.paramspec,
	exprlist = V"expr" * (WSO * P"," * WSO * V"expr")^0,
	-- 'expr' and all 'binop_l*_expr' are generated below
	--expr = V"binop_l0_expr",
	binop_l0_expr = (V"unop_expr" + V"func" + V"fncall" + V"literal" + V"brackexpr") / captures.expr,
	brackexpr = (P"(" * WSO * V"expr" * WSO * P")"),
	unop_expr = V"unop" * WSO * V"binop_l2_expr",
	unop = S"+-~",
	fncall = V"exname" * WSO * P"(" * WSO * (V"exprlist" * WSO)^-1 * P")",
	literal = V"array" + V"number" + V"exname" + V"string",
	number = C(V"hexint" + V"real" + V"integer") / id,
	integer = C(S("+-")^-1 * R("09")^1) / captures.number,
	hexint = C(S("+-")^-1 * P"0x" * R("09", "af", "AF")^1) / captures.number,
	real = C(S("+-")^-1 * R("09")^1 * P"." * R("09")^1) / captures.number,
	array = P"[" * (WSO * V"exprlist")^-1 * WSO * P"]",
	string = P('"') * C((1 - P('"'))^0) * P('"') / captures.string,
	
	
	
	func = V"fndecl" * WSO * (V"body" + P"=>" * WSO * V"expr"),
	body = P"{" * (WSO * V"instr")^0 * WSO * P"}",
	instr = V"declaration" + V"if_instr" + V"select_instr" + V"for_instr" + V"loop_instr" + V"while_instr" + V"goto_instr" + V"return_instr" + V"singleword_instr" + V"expr_instr" + V"body" + P";",
	
	expr_instr = V"expr" * WSO * P";",
	if_instr = P"if" * packCondition(V"expr") * V"instr" * (WSO * P"else" * WSO * V"instr")^-1,
	while_instr = P"while" * packCondition(V"expr") * V"instr",
	for_instr = P"for" * packCondition(V"name" * WS * P"in" * WS * V"expr") * V"instr",
	return_instr = P"return" * (WS * V"expr")^-1 * WSO * P";",
	goto_instr = P"goto" * WS * V"expr" * WSO * P";",
	loop_instr = P"loop" * WSO * V"instr" * WSO * P"until" * packCondition(V"expr"),
	singleword_instr = (P"break" + P"continue" + P"next") * WSO * P";",
	select_instr = P"select" * packCondition(V"expr") * P"{" * WSO * (
									WSO * (P"otherwise" + (P"when" * WS * V"expr")) * WSO * P":" + 
									WSO * V"instr" * WSO
								 )^0 * WSO * P"}"
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
	
	ruleset[opname] = C(ruleset[opname]) / captures.expr
	
	ruleset[expr] = V(subexpr) * (WSO * V(opname) * WSO * V(subexpr))^0
end

-- Compile the grammar
local grammar = P(ruleset)

function parse(str)
	local ast = grammar:match(str)
	
	-- Check if match could be found
	if ast ~= nil then
		-- Check if we mathed entire input string
		if (ast==(#str+1)) then
			return ast
		else
			
			local start,ende,c
			c = 3
			for st=ast,1,-1 do
				if str:sub(st,st) == "\n" then
					c = c - 1
				end
				if c <= 0 then
					break
				end
				start = st
			end
			
			c = 3
			for en=ast,#str do
				if str:sub(en,en) == "\n" then
					c = c - 1
				end
				if c <= 0 then
					break
				end
				ende = en
			end
			
			print(str:sub(start, ast - 1) .. "[!]" .. str:sub(ast, ende))
			
			error("Parse error! Didn't match all input.")
		end
	else
		print("Parse error!")
	end
end

local f = io.open("parsertest.psi", "r")
local src = f:read("*all")
f:close()

src = testsource

-- local ast = parse(src)
local ast = grammar:match(src)

print("success:", ast ~= nil)
if ast then
	io.write(inspect(ast), "\n")
end
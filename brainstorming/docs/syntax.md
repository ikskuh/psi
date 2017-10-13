# Psi Syntax

> TODO: Describe the basic idea of the language syntax here
> As less as possible without losing expressiveness and verboseness

## Grammar

This is the grammar for *Psi*. Whitespace is left out intentionally to
increase the readability of the grammar.

```
program     := (<declaration> | <module>)*;
declaration := <assert> | <import> | <objdecl>;

assert := assert" <expr> ";";
import := ("import" <exname> ("as" <name>)? ";";
module := "module" <exname> "{" <program> "}";

objdecl     := ("export")? (<opdecl> | <genvardecl> | <gentypedecl> | <vardecl> | <typedecl>);
opdecl      := ("unary" | "binary") "operator" "'" <ANYOPERATOR> "'" "=" <func> ";";
vardecl     := ("var" | "const") <param> ";";
typedecl    := ("type" <name> "=" <extype> ";";
genvardecl  := "generic" ("var" | "const") <name> <genparams> <paramspec> ";";
gentypedecl := "generic" "type" <name> <genparams> "=" <extype> ";";
genparams   := "<" <paramlist> ">";

name   := '[A-Za-z_][A-Za-z0-9_]*';
exname := <name> ("." <name>)*;

type    := ("(" <extype> ")") | <fndecl> | <enum> | <record> | <gentype>;
extype  := <type> | <exname>;
gentype := <exname> "<" <exprlist> ">";
record  := "record" "(" <paramlist> ")",
enum    := "enum" "(" <name> ( "," <name>)* ")";
fndecl  := "fn" "(" <paramlist>? ")"
					 ("->" * WSO * <extype>)? 
					 (("with" | "where") V"exprlist")?;

# TODO: Continue here!
paramlist = Ct(V"param" * (WSO * P"," * WSO * V"param")^0)/captures.paramlist,
param = (V"name" * WSO * V"paramspec") / captures.param,
paramspec =
					(P":" * WSO * V"extype" * WSO * P"=" * WSO * V"expr") / captures.paramspec +
					(P":" * WSO * V"extype") / captures.paramspec + 
					(P"=" * WSO * V"expr") / captures.paramspec,

exprlist = Ct(V"expr" * (WSO * P"," * WSO * V"expr")^0) / captures.exprlist,
arglist_entry = ((V"name" * WSO * P":" * WSO)^-1 * V"expr") / captures.argument,
arglist = Ct(V"arglist_entry" * (WSO * P"," * WSO * V"arglist_entry")^0) / captures.arglist,
-- 'expr' and all 'binop_l*_expr' are generated below
--expr = V"binop_l0_expr",

-- Handwritten binary operator for indexing fields and metafields
binop_l0_expr = (V"binop_end" * (
									(C(S".'") * V"name") / captures.fieldindex + 
									(P"[" * WSO * V"exprlist" * WSO * P"]") / captures.arrayindex + 
									V"fncall"
								)^0) / captures.indexer,
binop_end = (V"new_expr" + V"unop_expr" + V"func" + V"literal" + V"brackexpr") / id,

fncall = (P"(" * WSO * (V"arglist" * WSO)^-1 * P")") / captures.fncall,

new_expr = (P"new" * WS * V"exname" * WSO * V"fncall") / captures.newexpr,

brackexpr = (P"(" * WSO * V"expr" * WSO * P")") / id,
unop_expr = (V"unop" * WSO * V"binop_l0_expr") / captures.unop,
unop = C(S"+-~"),

literal = V"type"/captures.typeexpr + V"array" + V"number" + V"name" / captures.symbolref + V"string",
number = (V"hexint" + V"real" + V"integer") / id,
integer = C(S("+-")^-1 * R("09")^1) / captures.number,
hexint = C(S("+-")^-1 * P"0x" * R("09", "af", "AF")^1) / captures.number,
real = C(S("+-")^-1 * R("09")^1 * P"." * R("09")^1) / captures.number,
array = (P"[" * (WSO * V"exprlist")^-1 * WSO * P"]") / captures.array,
string = P('"') * C((1 - P('"'))^0) * P('"') / captures.string,

func = (V"fndecl" * WSO * (V"body" + P"=>" * WSO * V"expr" / captures.exprinstr)) / captures.func,
body = Ct(P"{" * (WSO * V"instr")^0 * WSO * P"}")/captures.bodyinstr,
instr = V"delete_instr" + V"declaration" + V"if_instr" + V"select_instr" + V"for_instr" + V"loop_instr" + V"while_instr" + V"goto_instr" + V"return_instr" + V"singleword_instr" + V"expr_instr" + V"body" + P";"/captures.emptyinstr,

delete_instr = (P"delete" * WS * V"expr" * WSO * P";") / captures.deleteinstr,
expr_instr = (V"expr" * WSO * P";") / captures.exprinstr,
if_instr = (P"if" * packCondition(V"expr") * V"instr" * (WSO * P"else" * WSO * V"instr")^-1) / captures.ifinstr,
while_instr = (P"while" * packCondition(V"expr") * V"instr") / captures.whileinstr,
for_instr = (P"for" * packCondition(V"name" * (WSO * P":" * WSO * V"extype")^-1 * WS * P"in" * WS * V"expr") * V"instr") / captures.forinstr,
return_instr = (P"return" * (WS * V"expr")^-1 * WSO * P";") / captures.returninstr,
goto_instr = (P"goto" * WS * V"expr" * WSO * P";") / captures.gotoinstr,
loop_instr = (P"loop" * WSO * V"instr" * WSO * P"until" * packCondition(V"expr")) / captures.loopinstr,
singleword_instr = (C(P"break" + P"continue" + P"next") * WSO * P";") / captures.wordinstr,
select_instr = (P"select" * packCondition(V"expr") * P"{" * WSO * (
								WSO * (P"otherwise" / captures.otherwise + (P"when" * WS * V"expr") / captures.when) * WSO * P":" + 
								WSO * V"instr" * WSO
							 )^0 * WSO * P"}") / captures.selectinstr



```
local lpeg = require "lpeg"
local re = require "re"

require "print"

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
	{ "+", "-", "--" },
	{ ">=", ">", "<=", "<" },
	{ "==", "!=" },
	{ "&", "|", "^", "->" },
	{ "+=", "-=", "*=", "/=", "%=", "|=", "--=", "=" },
	-- Lowest precedence (binds least)
}

-- Define the ruleset for Psi
local ruleset = {
	"program",
	program = V"declaration"^0,
	declaration = WSO * ( V"module" + V"assert" + V"import" + V"vardecl" + V"typedecl" ) * WSO,
	module = P"module" * WSO * V"exname" * WSO * P"{" * WSO * V"program" * WSO * P"}",
	import = P"import" * WSO * V"exname" * (WSO * P"as" * WSO * V"name")^-1 * WSO * P";",
	vardecl = (P"export" * WS)^-1 * (P"var" + P"const") * WS * V"param" * WSO * P";",
	typedecl = (P"export" * WS)^-1 * P"type" * WS * V"name" * WSO * P"=" * WSO * V"type" * WSO * P";",
	assert = P"assert" * WS * V"expr" * P";",
	name = (R("AZ", "az") + S"_")^1,
	exname = V"name" * (P"." * V"name")^0,
	type = (P"(" * WSO * V"type" * WSO * P")") + V"fndecl" + V"record" + V"gentype" + V"exname",
	gentype = V"exname" * WSO * P"<" * V"exprlist" * WSO * P">",
	record = P"record" * WSO * P"(" * WSO * V"paramlist" * WSO * P")",
	fndecl = P"fn" * WSO * P"(" * WSO * (V"paramlist" * WSO)^-1 * P")" * (WSO * P"->" * WSO * V"type")^-1,
	paramlist = V"param" * (WSO * P"," * WSO * V"param")^0,
	param = V"name" * WSO * (
						(P":" * WSO * V"type" * WSO * P"=" * WSO * V"expr") +
						(P":" * WSO * V"type") + 
						(P"=" * WSO * V"expr")),
	exprlist = V"expr" * (WSO * P"," * WSO * V"expr")^0,
	-- 'expr' and all 'binop_l*_expr' are generated below
	--expr = V"binop_l0_expr",
	binop_l0_expr = V"unop_expr" + V"literal" + V"brackexpr",
	
	brackexpr = (P"(" * WSO * V"expr" * WSO * P")"),
	unop_expr = V"unop" * WSO * V"binop_l2_expr",
	unop = S"+-~",
	literal = V"array" + V"number" + V"exname" + V"string",
	number = V"hexint" + V"real" + V"integer",
	integer = S("+-")^-1 * R("09")^1,
	hexint = S("+-")^-1 * P"0x" * R("09", "af", "AF")^1,
	real = S("+-")^-1 * R("09")^1 * P"." * R("09")^1,
	array = P"[" * (WSO * V"exprlist")^-1 * WSO * P"]",
	string = P('"') * (1 - P('"'))^0 * P('"'),
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

local ast = parse 
[[
import std;
import std.io;
import std.io.network;

import std as foo;
import std.io as bar;
import std.io.network as baz;

assert true;

#!
 ! Module testing and nesting
 !#
module std
{
	var foo : int;
	module io
	{
		var foo = 10;
	}
	
	module io.network
	{
		# Foo!
	}
}

#!
 ! This module contains all possible variants of variable declarations
 !#
module vardecl
{
	var foo : int;
	var foo = 10;
	var foo : int = 10;
	
	const foo : int;
	const foo = 10;
	const foo : int = 10;
	
	export var foo : int;
	export var foo = 10;
	export var foo : int = 10;
	
	export const foo : int;
	export const foo = 10;
	export const foo : int = 10;
}

module types
{
	type foo = int;
	type foo = std.io.socket;
	type foo = int<0,1,wrapping>;
	
	type foo = enum<first,second.third,fourth>;
	type foo = record(foo : bar);
	type foo = record(foo = 10);
	type foo = record(foo = 10, bar : std.io.socket, baz : int = 10);
	type foo = record(foo : bar, bam : baz, moo : int<10>);
	
	type foo = fn();
	type foo = fn(i : int);
	type foo = fn(i : int, j : int);

	type foo = fn() -> int;
	type foo = fn() -> std.io.socket;
	type foo = fn(i : int) -> int;
	type foo = fn(i : int, j : int) -> int;
	
	type foo = fn() -> fn();
	type foo = fn() -> fn() -> fn();
	type foo = fn() -> fn() -> fn() -> int;
	
	export type foo = int;
	export type foo = int<0,1,clamping>;
}

#!
 ! This module tests all possible numeric literal types
 !#
module numbers
{
	assert 10;
	assert 0xB00B5;
	assert 1.0;
	
	assert -10;
	assert -0xDEADB005;
	assert -1.0;
}

module arrays
{
	assert [];
	assert [ 1 ];
	assert [ 1, 2, 3 ];
	assert [ 1, name, 3 ];
}

module unary_operators
{
	assert -name;
	assert +name;
	assert ~name;
	assert -(+(name));
}

module binary_operators
{
	assert 10 + 10;
	assert 10 + 10**10 + 10**foo**bar;
	assert 10 *  10;
	assert 10 -  10;
	assert 10 /  10;
	assert 10 %  10;
	assert 10 ** 10;
	assert 10 >= 10;
	assert 10 <= 10;
	assert 10 >  10;
	assert 10 <  10;
	assert 10 == 10;
	assert 10 != 10;
	assert 10 =  10;
	assert 10 &  10;
	assert 10 |  10;
	assert 10 ^  10;
	assert 10 -> 10;
	assert 10 -- 10;
}

module brackexp
{
	assert 10;
	assert ( 10 );
	assert ( -10 );
	assert -( 10 );
	assert -( ( 10 ) );
	assert -( -10 );
}
]]

print(ast)



-- This file contains constants that
-- define the type of AST nodes
local mt = { }
local function uniq()
	return setmetatable({},mt)
end
local AST = 
{
	__mt = mt,
	IMPORT = uniq(),
	VARDECL = uniq(),
	SELECTOR = uniq(),
	ASSERTION = uniq(),
	EXPRESSION = uniq(),
	INSTRUCTION = uniq(),
	OPERATORDECL = uniq(),
	SELECTORLIST = uniq(),
	EXPRESSIONLIST = uniq(),
	ARGUMENTLIST = uniq(),
	COMPOUNDNAME = uniq(),
	PARAMSPEC = uniq(),
	PARAMLIST = uniq(),
	ARGUMENT = uniq(),
	PROGRAM = uniq(),
	MODULE = uniq(),
	PARAM = uniq(),
	TYPE = uniq(),
	INDEX = uniq(),
}

function mt.__tostring(self)
	for i,v in pairs(AST) do
		if v == self then
			return i
		end
	end
	return "UNKOWN"
end
function mt.__index(t,k)
	error("Unknown AST node: "..tostring(k),2)
end
function mt.__newindex(t,k,v)
	error("Constant table!",2)
end
setmetatable(AST, mt)
return AST
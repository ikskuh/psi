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
	TYPEDECL = uniq(),
	ASSERTION = uniq(),
	EXPRESSION = uniq(),
	INSTRUCTION = uniq(),
	OPERATORDECL = uniq(),
	EXPRESSIONLIST = uniq(),
	PARAMSPEC = uniq(),
	PARAMLIST = uniq(),
	SELECTOR = uniq(),
	PROGRAM = uniq(),
	MODULE = uniq(),
	PARAM = uniq(),
	TYPE = uniq(),
}

function mt.__tostring(self)
	for i,v in pairs(AST) do
		if v == self then
			return i
		end
	end
	return "UNKOWN"
end
function mt.__newindex(t,k,v)
	error("Constant table!")
end

return AST
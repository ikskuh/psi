local AST = require "ast"

local xml = { }

function xml.escape(str)
	return str:gsub(".", function (val)
		if val == ">" then
			return "&gt;"
		elseif val == "<" then
			return "&lt;"
		elseif val == "&" then
			return "&amp;"
		end
	end)
end

function xml.dump(file, root, indent, name, skipDecl)
	assert(type(file.write) == "function")
	assert(type(root) == "table")

	local ichar = '    '
	if not indent then
		indent = ''
	end
	
	if not skipDecl then
		file:write(indent, '<?xml version="1.0" ?>\n')
	end

	if not root[AST] then
		error("Invalid node type!")
	end
	
	name = name or tostring(root[AST]):lower()
	
	file:write(indent, '<', name)
	
	if not skipDecl then
		file:write(' xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"')
	end
	
	if type(root.type)=="string" then
		local n = tostring(root.type)
		n = n:sub(1,1):upper() .. n:sub(2)
		
		local typeName = n
		
		n = tostring(root[AST]):lower()
		n = n:sub(1,1):upper() .. n:sub(2)
		
		typeName = n .. typeName
		
		-- Replace -c with C
		typeName = typeName:gsub("%W(.)", string.upper)
		
		file:write(' xsi:type="', typeName, '"')
	end
	
	file:write('>\n')
	
	for i,v in pairs(root) do
		if i == AST then
		
		elseif type(v) == "table" and v[AST] then
			local ind
			if type(i) ~= "number" then
				ind = i
			end
			xml.dump(file, v, indent..ichar, ind, true)
		elseif type(v) == "table" then
			file:write(indent, ichar, '<', tostring(i), '>\n')
			for j=1,#v do
				local o = v[j]
				file:write(
					indent, ichar, ichar, 
					'<', type(o), '>',
					tostring(o),
					'</', type(o), '>\n')
			end
			file:write(indent, ichar, '</', tostring(i), '>\n')
		
		elseif type(i) == "number" then
			file:write(indent, ichar, '<', type(v), '>', xml.escape(tostring(v)), '</', type(v), '>\n')
		else
			file:write(indent, ichar, '<', tostring(i), '>', xml.escape(tostring(v)), '</', tostring(i), '>\n')
		end
	end
	
	file:write(indent, '</', name, '>\n')
end



return xml
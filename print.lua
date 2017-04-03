require "opairs"
inspect = require "inspect"

function print(...)
	
	local packed = table.pack(...)
	
	for i,v in ipairs(packed) do
		if i > 1 then
			io.write("\t")
		end
		io.write(inspect(v))
	end
	io.write("\n")
	return
	
	--[[
	local INDENT = "  "
	local function put(val)
		if type(val) == "nil" then
			io.write("nil")
			return
		end
		if type(val) == "table" then
			io.write("{ ")
			local fag = false
			local function prefix()
				if fag then
					io.write(", ")
				end
				fag = true
			end
			for i,v in opairs(val) do
				if type(i) ~= "number" then
					prefix()
					if type(i) == "string" and i:match("^[%w_]+$") then
						io.write(i)
					else
						io.write("[")
						put(i)
						io.write("]")
					end
					io.write(" = ")
					put(v)
				end
			end
			for i,v in ipairs(val) do
				prefix()
				put(v)
			end
			io.write(" }")
		elseif type(val) == "string" then
			io.write("\""..val.."\"")
		else
			io.write(tostring(val))
		end
	end
	local t = table.pack(...)
	for i,v in ipairs(t) do
		if i > 1 then
			io.write("\t")
		end
		put(v)
	end
	io.write("\n")
	]]
end
return print
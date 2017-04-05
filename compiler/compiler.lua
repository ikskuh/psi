require "print"

local parse = require "parser"

local getopt = require "getopt"

local function loadFile(name)
	local f, err = io.open(name, "r")
	if f == nil then
		return nil, err
	end
	local src = f:read("*all")
	f:close()
	return src
end

local files, options = getopt({
	verbose = {
		info = "Prints more stuff to the console than usual",
		shorthand = "v",
	},
	test = {
		info = "Runs internal tests on the compiler.",
		shorthand = "t",
	},
	parse = {
		info = "Parses the given file",
		shorthand = "p",
		arg = "file",
		trigger = function(file)
			local src = loadFile(file)
			if src == nil then
				error("Failed to open " .. file .. "!")
			end
			local ast = parse(src)
			if ast then
				print("AST for "..file, ast)
			else
				error("Failed to parse "..file.."!")
			end
		end
	}
}, ...)

-- print(files)
-- print(options)

if options["test"] then
	local src = loadFile("../samples/parsertest.psi")
	local ast = parse(src)
	
	if (ast ~= nil) and (ast[#ast].name == "main") then
		print("Test successful!")
	else
		print("Test failed!")
		print(ast)
	end
end

for i,file in ipairs(files) do
	local source, err = loadFile(file)
	if source == nil then
		error(err)
	end
	local ast = parse(source)
	if ast == nil then
		error("Failed to parse " .. file .. "!")
	end
	
	-- Process AST here
	print(file, ast)
end

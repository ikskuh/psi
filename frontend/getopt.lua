local opairs = require "opairs"

local function renderHelp(config)
	for key,obj in opairs(config) do
		local arg = ""
		if obj.arg then
			arg = " <" .. obj.arg .. ">"
		end
		if obj.shorthand then
			io.write("\t-", obj.shorthand, arg, "\n")
		end
		io.write("\t--", key, arg, "\n")
		io.write("\t\t", obj.info or "???", "\n")
	end
end

return function (config, ...)
	local arguments = table.pack(...)
  local options = { }
	local files = { }
	local printHelp = false

	if config.help == nil then
		config.help = {
			info = "Prints this help",
			shorthand = "h",
			trigger = function() printHelp = true end
		}
	end
	
	local shorthands = { }
	for i,v in pairs(config) do
		v.name = i
		if v.shorthand then
			shorthands[v.shorthand] = v
		end
	end
	
	local function readOption(opt, file)
		options[opt.name] = opt.arg and file or true
		if opt.trigger then
			opt.trigger(file)
		end
		return not not opt.arg
	end
	
	local i = 1
	while i <= #arguments do
		local a = arguments[i]
		if a:sub(1,2) == "--" then
			local name = a:sub(3)
			local opt = config[name]
			if opt then
				if readOption(opt, arguments[i + 1]) == true then
					i = i + 1
				end
			else
				error("Option "..a.." not found!")
			end
			i = i + 1
		elseif a:sub(1,1) == "-" then
			i = i + 1
			for j=2,#a do
				local opt = shorthands[a:sub(j,j)]
				if opt then
					if readOption(opt, arguments[i]) == true then
						i = i + 1
					end
				else
					error("Option -"..a:sub(j,j).." not found!")
				end
			end
		else
			files[#files+1] = arg[i]
			i = i + 1
		end
	end

	if printHelp then
		renderHelp(config)
		os.exit()
	end
	return files, options
end
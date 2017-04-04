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
		isGeneric = false,
		isConst = (const == "const"),
		name = param.name,
		type = param.type,
		value = param.value,
	}
end

function captures.typedecl(name, type)
	return {
		_TYPE = "typedecl",
		isGeneric = false,
		name = name,
		type = type,
	}
end

function captures.genvardecl(name, params, info)
	return { 
		_TYPE = "vardecl",
		isGeneric = true,
		isConst = (const == "const"),
		name = name,
		type = info.type,
		value = info.value,
		params = params
	}
end

function captures.gentypedecl(name, params, type)
	return { 
		_TYPE = "typedecl",
		isGeneric = true,
		name = name,
		type = type,
		params = params,
	}
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

function captures.type(t)
	assert(t._TYPE == "type", "type must be a type!")
	return t
end

function captures.number(val)
	return {
		_TYPE = "expression",
		type = "number",
		value = tonumber(val)
	}
end

function captures.string(val)
	return {
		_TYPE = "expression",
		type = "string",
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

function captures.namedType(name)
	return {
		_TYPE = "type",
		type = "reference",
		name = name,
	}
end

function captures.recordtype(list)
	return {
		_TYPE = "type",
		type = "record",
		fields = list
	}
end

function captures.gentyperef(name, exprlist)
	return {
		_TYPE = "type",
		type = "generic-reference",
		name = name,
		args = exprlist
	}
end

function captures.funsig(params, returntype)
	return {
		_TYPE = "type",
		type = "function",
		params = params or { },
		returntype = returntype
	}
end

function captures.fncall(name, args)
	return {
		_TYPE = "expression",
		type = "call",
		name = name,
		arguments = args,
	}
end

function captures.unop(op, value)
	return {
		_TYPE = "expression",
		type = "unary-operator",
		operator = op,
		value = value,
	}
end

function captures.binop(...)
	local t = table.pack(...)
	if #t==1 then
		return t[1]
	elseif #t%2==0 then
		error("Invalid binop!")
	end
	local function mkop(lhs, op, rhs)
		return {
			_TYPE = "expression",
			type = "binary-operator",
			lhs = lhs,
			operator = op,
			rhs = rhs,
		}
	end
	
	local function reverse(tbl)
		for i=1, math.floor(#tbl / 2) do
			tbl[i], tbl[#tbl - i + 1] = tbl[#tbl - i + 1], tbl[i]
		end
	end

	local rightRecursive = true
	
	if rightRecursive then
		local expr = mkop(t[1],t[2],t[3])
		for i=4,#t,2 do
			expr = mkop(expr, t[i], t[i+1])
		end
		return expr
	else
		reverse(t)
		local expr = mkop(t[3],t[2],t[1])
		for i=4,#t,2 do
			expr = mkop(t[i+1], t[i], expr)
		end
		return expr
	end
end

function captures.array(values)
	return {
		_TYPE = "expression",
		type = "array",
		values = values
	}
end

function captures.metaindex(expr, index)
	return {
		_TYPE = "metaindex",
		expression = expr,
		index = index
	}
end

function captures.variableref(name)
	return {
		_TYPE = "expression",
		type = "variable",
		name = name,
	}
end

function captures.func(sig, body)
	return {
		_TYPE = "expression",
		type = "function",
		signature = sig,
		body = body,
	}
end

function captures.exprinstr(expr)
	return {
		_TYPE = "instruction",
		type = "expression",
		expression = expr,
	}
end

function captures.ifinstr(cond, yes, no)
	return {
		_TYPE = "instruction",
		type = "conditional",
		condition = cond,
		positive = yes,
		negative = no
	}
end

function captures.whileinstr(cond, body)
	return {
		_TYPE = "instruction",
		type = "while",
		condition = cond,
		body = body,
	}
end

function captures.forinstr(var, expr, body)
	return {
		_TYPE = "instruction",
		type = "for",
		variable = var,
		expression = expr,
		body = body,
	}
end

function captures.returninstr(expr)
	if expr._TYPE ~= "expression" then
		expr = nil
	end
	return {
			_TYPE = "instruction",
			type = "return",
			expression = expr
		}
end

function captures.gotoinstr(expr)
	return {
		_TYPE = "instruction",
		type = "goto",
		expression = expr
	}
end

function captures.loopinstr(body, cond)
	return {
		_TYPE = "instruction",
		type = "loop-until",
		condition = cond,
		body = body,
	}
end

function captures.wordinstr(word)
	return {
		_TYPE = "instruction",
		type = word
	}
end

function captures.selectinstr(expr, ...)
	local t = table.pack(...)
	local options = { }
	local option
	
	for i=1,#t do
		if t[i]._TYPE == "selector" then
			option = t[i]
			table.insert(options, option)
		elseif t[i]._TYPE == "instruction" then
			
			table.insert(option.contents, t[i])
		else
			print(i, t[i])
			error("Invalid selector!")
		end
	end
	
	return {
		_TYPE = "instruction",
		type = "select",
		selector = expr,
		options = options
	}
end

function captures.otherwise()
	return {
		_TYPE = "selector",
		isDefault = true,
		contents = { },
	}
end

function captures.when(expr)
	return {
		_TYPE = "selector",
		isDefault = false,
		expression = expr,
		contents = { },
	}
end

function captures.bodyinstr(body)
	return {
		_TYPE = "instruction",
		type = "body",
		contents = body
	}
end

return captures
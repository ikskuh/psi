

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
		params = params,
		returntype = returntype
	}
end

return captures
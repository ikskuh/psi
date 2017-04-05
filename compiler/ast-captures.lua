local AST =require"ast"

local function checkType(obj, type, optional)
	if obj == nil and optional then
		return nil
	end
	assert(obj[AST] == type, "Invalid type: "..tostring(obj[AST]).." != "..tostring(type))
	return obj
end

local captures = { }

function captures.program(list)
	assert(type(list)=="table", "Program must be a table!")
	list[AST] = AST.PROGRAM
	return list
end

function captures.import(mod, alias)
	return {
		[AST] = AST.IMPORT,
		module = mod,
		alias = alias
	}
end

function captures.objectdecl(exported, obj)
	obj.isExported = exported
	return obj
end

function captures.vardecl(const, param)
	checkType(param, AST.PARAM)
	if param.type == nil and param.value == nil then
		error("Variable must have either type or value!")
	end
	return { 
		[AST] = AST.VARDECL,
		isGeneric = false,
		isConst = (const == "const"),
		name = param.name,
		type = checkType(param.type, AST.TYPE, true),
		value = checkType(param.value, AST.EXPRESSION, true)
	}
end

function captures.typedecl(name, type)
	return {
		[AST] = AST.TYPEDECL,
		isGeneric = false,
		name = name,
		type = checkType(type, AST.TYPE),
	}
end

function captures.genvardecl(name, params, info)
	checkType(info, AST.PARAMSPEC)
	if info.type == nil and info.value == nil then
		error("Variable must have either type or value!")
	end
	return { 
		[AST] = AST.VARDECL,
		isGeneric = true,
		isConst = (const == "const"),
		name = name,
		type = checkType(info.type, AST.TYPE, true),
		value = checkType(info.value, AST.EXPRESSION, true),
		params = checkType(params, AST.PARAMLIST),
	}
end

function captures.gentypedecl(name, params, type)
	return { 
		[AST] = AST.TYPEDECL,
		isGeneric = true,
		name = name,
		type = checkType(type, AST.TYPE),
		params = checkType(params, AST.PARAMLIST),
	}
end

function captures.assert(expr)
	return {
		[AST] = AST.ASSERTION,
		expression = checkType(expr, AST.EXPRESSION),
	}
end

function captures.param(name, spec)
	return { 
		[AST] = AST.PARAM,
		name = name,
		type = checkType(spec.type, AST.TYPE, true),
		value = checkType(spec.value, AST.EXPRESSION, true),
	}
end

function captures.paramspec(type, value)
	if type[AST] == AST.EXPRESSION then
		value = type
		type = nil
	end
	if type == nil and value == nil then
		error("Typespec needs at least a type or a value!")
	end
	return {
		[AST] = AST.PARAMSPEC,
		type = checkType(type, AST.TYPE, true),
		value = checkType(value, AST.EXPRESSION, true),
	}
end

function captures.type(t)
	return checkType(t, AST.TYPE)
end

function captures.number(val)
	return {
		[AST] = AST.EXPRESSION,
		type = "number",
		value = tonumber(val)
	}
end

function captures.string(val)
	return {
		[AST] = AST.EXPRESSION,
		type = "string",
		value = tostring(val)
	}
end

function captures.module(name, prg)
	return {
		[AST] = AST.MODULE,
		name = name,
		contents = checkType(prg, AST.PROGRAM)
	}
end

function captures.namedType(name)
	return {
		[AST] = AST.TYPE,
		type = "reference",
		name = name,
	}
end

function captures.recordtype(list)
	return {
		[AST] = AST.TYPE,
		type = "record",
		fields = list
	}
end

function captures.gentyperef(name, exprlist)
	return {
		[AST] = AST.TYPE,
		type = "generic-reference",
		name = name,
		args = exprlist
	}
end

function captures.funsig(params, returntype)
	return {
		[AST] = AST.TYPE,
		type = "function",
		params = params or { },
		returntype = returntype
	}
end

function captures.unop(op, value)
	return {
		[AST] = AST.EXPRESSION,
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
			[AST] = AST.EXPRESSION,
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
		[AST] = AST.EXPRESSION,
		type = "array",
		values = values
	}
end

function captures.indexer(...)
	local t = table.pack(...)
	if #t==1 then
		return t[1]
	end
	local function mkindex(value, index)
		return {
			[AST] = AST.EXPRESSION,
			type = "index",
			value = value,
			index = index,
		}
	end
	
	local expr = mkindex(t[1],t[2])
	for i=3,#t do
		expr = mkindex(expr, t[i])
	end
	return expr
--]]
end

function captures.arrayindex(list)
	return {
		type = "array",
		indices = list,
	}
end

function captures.fieldindex(...)
	local t = table.pack(...)
	return {
		type = (t[1] == ".") and "field" or "meta",
		field = t[2]
	}
end

function captures.fncall(args)
	if type(args) == "string" then
		args = { }
	end
	return {
		type = "call",
		name = name,
		arguments = args,
	}
end

function captures.variableref(name)
	return {
		[AST] = AST.EXPRESSION,
		type = "variable",
		name = name,
	}
end

function captures.func(sig, body)
	return {
		[AST] = AST.EXPRESSION,
		type = "function",
		signature = checkType(sig, AST.TYPE),
		body = checkType(body, AST.INSTRUCTION),
	}
end

function captures.exprinstr(expr)
	return {
		[AST] = AST.INSTRUCTION,
		type = "expression",
		expression = checkType(expr, AST.EXPRESSION),
	}
end

function captures.ifinstr(cond, yes, no)
	return {
		[AST] = AST.INSTRUCTION,
		type = "conditional",
		condition = checkType(cond, AST.EXPRESSION),
		positive = checkType(yes, AST.INSTRUCTION),
		negative = checkType(no, AST.INSTRUCTION, true)
	}
end

function captures.whileinstr(cond, body)
	return {
		[AST] = AST.INSTRUCTION,
		type = "while",
		condition = checkType(cond, AST.EXPRESSION),
		body = checkType(body, AST.INSTRUCTION),
	}
end

function captures.forinstr(var, expr, body)
	return {
		[AST] = AST.INSTRUCTION,
		type = "for",
		variable = var,
		expression = checkType(expr, AST.EXPRESSION),
		body = checkType(body, AST.INSTRUCTION),
	}
end

function captures.returninstr(expr)
	if expr[AST] ~= AST.EXPRESSION then
		expr = nil
	end
	return {
			[AST] = AST.INSTRUCTION,
			type = "return",
			expression = checkType(expr, AST.EXPRESSION, true)
		}
end

function captures.gotoinstr(expr)
	return {
		[AST] = AST.INSTRUCTION,
		type = "goto",
		expression = checkType(expr, AST.EXPRESSION)
	}
end

function captures.loopinstr(body, cond)
	return {
		[AST] = AST.INSTRUCTION,
		type = "loop-until",
		condition = checkType(cond, AST.EXPRESSION),
		body = checkType(body, AST.INSTRUCTION),
	}
end

function captures.wordinstr(word)
	return {
		[AST] = AST.INSTRUCTION,
		type = word
	}
end

function captures.selectinstr(expr, ...)
	local t = table.pack(...)
	local options = { }
	local option
	
	for i=1,#t do
		if t[i][AST] == AST.SELECTOR then
			option = t[i]
			table.insert(options, option)
		elseif t[i][AST] == AST.INSTRUCTION then
			table.insert(option.contents, t[i])
		else
			print(i, t[i])
			error("Invalid selector!")
		end
	end
	
	return {
		[AST] = AST.INSTRUCTION,
		type = "select",
		selector = checkType(expr, AST.EXPRESSION),
		options = options
	}
end

function captures.otherwise()
	return {
		[AST] = AST.SELECTOR,
		isDefault = true,
		contents = captures.bodyinstr({ }),
	}
end

function captures.when(expr)
	return {
		[AST] = AST.SELECTOR,
		isDefault = false,
		expression = checkType(expr, AST.EXPRESSION),
		contents = captures.bodyinstr({ }),
	}
end

function captures.bodyinstr(body)
	assert(type(body)=="table")
	body[AST] = AST.INSTRUCTION
	body.type = "body"
	return body
end

function captures.operator(type, operator, func)
	return {
		[AST] = AST.OPERATORDECL,
		type = type,
		operator = operator,
		func = checkType(func, AST.EXPRESSION),
	}
end

function captures.emptyinstr()
	return {
		[AST] = AST.INSTRUCTION,
		type = "empty",
	}
end

function captures.exprlist(list)
	assert(type(list)=="table")
	list[AST] = AST.EXPRESSIONLIST
	return list
end

function captures.paramlist(list)
	assert(type(list)=="table")
	list[AST] = AST.PARAMLIST
	return list
end

function captures.typeexpr(type)
	return {
		[AST] = AST.EXPRESSION,
		type = "type",
		reference = checkType(type, AST.TYPE),
	}
end

return captures
-- Psi Lexer for textadept
-- 

local l = require('lexer')
local token, word_match = l.token, l.word_match
local P, R, S = lpeg.P, lpeg.R, lpeg.S

local M = {_NAME = 'psi'}

-- Whitespace.
local ws = token(l.WHITESPACE, l.space^1)

-- Comments.
local line_comment = '#' * l.nonnewline^0
local block_comment = '#!' * (l.any - '!#')^0 * P('!#')^-1
local comment = token(l.COMMENT, block_comment + line_comment)

-- Strings.
-- local sq_str = P('L')^-1 * l.delimited_range("'", true)
local dq_str = l.delimited_range('"', true)
--local string = token(l.STRING, sq_str + dq_str)
local string = token(l.STRING, dq_str)

-- Numbers.
local number = token(l.NUMBER, l.float + l.integer)
											
-- Keywords.
local keyword = token(l.KEYWORD, word_match{
  'module', 'import', 'as', 'var', 'const',
	'generic', 'type', 'assert', 'fn', 'in',
	'if', 'else', 'for', 'while', 'loop',
	'until', 'break', 'goto', 'next', 'continue',
	'select', 'when', 'otherwise', 'export',
	'return', 'new', 'delete', 'with', 'where',
	'binary', 'unary', 'operator', 'restrict'
})

-- Types.
local type = token(l.TYPE, word_match{
  'u8', 'u16', 'u32', 'i8', 'i16', 'i32', 'int', 'uint', 
  'string', 'ptr', 'ref', 'bool', 'array', 'fixarray',
	'any', 'option', 'optional', 'char', 'real', 'enum',
	'weak', 'record'
})

-- Identifiers.
local identifier = token(l.IDENTIFIER, l.word)

-- Operators.
local operator = token(l.OPERATOR, S('!%%^&%|+-*/>=<%:(){}[]'))

M._rules = {
  {'whitespace', ws},
  {'keyword', keyword},
  {'type', type},
  {'identifier', identifier},
  {'string', string},
  {'comment', comment},
  {'number', number},
  {'operator', operator},
}

M._foldsymbols = {
  _patterns = {'%l+', '%[', '%]', '[{}]', '#!', '!#', '#'},
  [l.OPERATOR] = {
		['{'] = 1, 
		['}'] = -1,
		['['] = 1, 
		[']'] = -1,
	},
  [l.COMMENT] = {
		['#!'] = 1, 
		['!#'] = -1, 
		['#'] = l.fold_line_comments('#')
	}
}

return M

# Grammar

```yacc
program     : /* empty */
            | program assertion
            | program declaration
            | program module
            | program import
            ;

assertion   : 'assert' expression ';'
            ;

import      : 'import' modname ';'
            ;

module      : 'module' modname '{' program '}'
            ;

modname     : identifier
            | modname '.' identifier
            ;

declaration : export typedecl
            | export vardecl
            ;

typedecl    : 'type' identifier '=' expression ';'
            ;

vardecl     : storage identifier ':' type terminator
            | storage identifier '=' expression terminator
            | storage identifier ':' type '=' expression terminator
            ;

type        : value
            ;

terminator  : /* optional */
            | TERMINATOR;

storage     : 'const'
            | 'var'
            ;

export      : /* optional */
            | 'export'
            ;

expression  : expression '='    expression
            | expression ':='   expression
            | expression '--='  expression
            | expression '+='   expression
            | expression '-='   expression
            | expression '**='  expression
            | expression '*='   expression
            | expression '%='   expression
            | expression '/='   expression
            | expression '&='   expression
            | expression '|='   expression
            | expression '^='   expression
            | expression '>>>=' expression
            | expression '<<='  expression
            | expression '>>='  expression
            | expr_or
            ;

expr_or     : expr_or '|' expr_or
            | expr_xor
            ;

expr_xor    : expr_xor '^' expr_xor
            | expr_and
            ;

expr_and    : expr_and '&' expr_and
            | equality
            ;

equality    : equality '==' equality
            | equality '!=' equality
            | comparison
            ;

comparison  : comparison '<=' comparison
            | comparison '>=' comparison
            | comparison '<'  comparison
            | comparison '>'  comparison
            | expr_arrows
            ;

expr_arrows : expr_arrows '->' expr_arrows
            | expr_arrows '<-' expr_arrows
            | sum
            ;

sum         : sum '+'  sum
            | sum '-'  sum
            | sum '--' sum
            | term
            ;

term        : term '*' term
            | term '/' term
            | term '%' term
            | expo
            ;

expo        : expo '**' expo
            | shifting
            ;

shifting    : shifting '>>>' shifting
            | shifting '>>'  shifting
            | shifting '<<'  shifting
            | unary
            ;

unary       : '+'   value
            | '-'   value
            | '~'   value
            | 'new' value
            | value
            ;

value       : value '.' identifier
            | value '\'' identifier
            | 'enum' '(' idlist ')'
            | 'enum' '<' type '>' '(' fieldlist ')'
            | 'ref' '<' type '>'
            | 'record' '(' fieldlist ')'
            | 'array' '<' type '>'
            | 'array' '<' type ',' '0x[A-Fa-f0-9]+|\d+(\.\d+)?' '>'
            | value '[' exprlist ']'
            | '[' exprlist ']'
            | value '(' ')'
            | value '(' arglist ')'
            | '(' expression ')'
            | identifier
            | functiontype
            | functiontype block
            | functiontype '=>' expression
            | '\\' '(' idlist ')' '=>' expression
            | '"(?:\\"|.)*?"'
            | ENUMVAL
            | '0x[A-Fa-f0-9]+|\d+(\.\d+)?'
            ;

idlist      : idlist ',' identifier
            | identifier
            ;

fieldlist   : fieldlist ',' field
            | field
            ;

field       : identifier ':' type terminator
                $$ = new Declaration($1, $3, null);
                $$.IsField = true;
            | identifier '='    expression terminator
                $$ = new Declaration($1, Undefined, $3);
                $$.IsField = true;
            | identifier ':' type '=' expression terminator
                $$ = new Declaration($1, $3, $5);
                $$.IsField = true;
            ;

functiontype: 'fn' '(' paramlist ')' '->' type
            | 'fn' '(' ')' '->' type
            | 'fn' '(' paramlist ')'
            | 'fn' '(' ')'
            ;

paramlist   : paramlist ',' parameter
            | parameter
            ;

parameter   : prefix identifier ':' type '=' expression
            | prefix identifier '=' expression
            | prefix identifier ':' type
            ;

prefix      : /* empty */
            | prefix 'in'
            | prefix 'out'
            | prefix 'inout'
            | prefix 'this'
            ;

arglist     : arglist ',' argument
            | argument
            ;

argument    : expression
            | identifier ':' expression
            ;

exprlist    : expression
            | exprlist ',' expression
            ;

block       : '{' stmtlist '}'
            | '{' '}'
            ;

stmtlist    : /* empty */
            | stmtlist statement
            ;

statement   : declaration
            | assertion
            | block
            | 'break' ';'
            | FALLTROUGH ';'
            | 'continue' ';'
            | 'error' expression ';'
            | 'return' expression ';'
            | 'return' ';'
            | 'goto' expression ';'
            | 'if' '(' expression ')' statement 'else' statement
            | 'if' '(' expression ')' statement
            | 'while' '(' expression ')' statement
            | 'loop' statement 'until' '(' expression ')' ';'
            | 'restrict' '(' exprlist ')' statement
            | 'for' '(' identifier 'in' expression ')' statement
            | 'select' '(' expression ')' '{' options '}'
            | expression ';'
            | ';'
            ;

options     : /* empty */
            | options 'when' expression ':' stmtlist
            | options 'otherwise' ':' stmtlist
            ;

identifier  : '[\w-[\d]]\w*'
            | 'operator' '\'' opsym '\''
            ;

opsym       : '+' | '-' | '*' | '/' | '&' | '|' | '~' | '^' | '--' | '.' | '\'' | '**' | '%'
            | '->' | '<-' | '<=' | '>=' | '==' | '!=' | '<' | '>' | '=' | ':='
            | '>>>' | '<<' | '>>'
            | '[' ']' // array indexing operator symbol
            ;
```
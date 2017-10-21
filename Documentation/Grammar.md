# Grammar

```yacc
program     : /* empty */         
            | program assertion   
            | program declaration 
            | program module      
            | program import      
            ;

assertion   : ASSERT expression TERMINATOR
            ;

import      : IMPORT modname TERMINATOR
            ;

module      : MODULE modname CURLY_O program CURLY_C
            ;

modname     : identifier
            | modname DOT identifier
            ;

declaration : export typedecl
            | export vardecl
            ;
            
typedecl    : TYPE identifier IS expression TERMINATOR
            ;

vardecl     : storage identifier COLON type terminator
            | storage identifier IS    expression terminator
            | storage identifier COLON type IS expression terminator
            ;
            
type        : value
            ;

terminator  : /* optional */
            | TERMINATOR;

storage     : CONST          
            | VAR            
            ;

export      : /* optional */ 
            | EXPORT         
            ;

expression  : expression IS expression
            | expression ASSIGN expression
            | expression WB_CONCAT expression
            | expression WB_PLUS expression
            | expression WB_MINUS expression
            | expression WB_EXP expression
            | expression WB_MULT expression
            | expression WB_MOD expression
            | expression WB_DIV expression
            | expression WB_AND expression
            | expression WB_OR expression
            | expression WB_INVERT expression
            | expression WB_XOR expression
            | expression WB_ASR expression
            | expression WB_SHL expression
            | expression WB_SHR expression
            | expr_or
            ;

expr_or     : expr_or OR expr_or
            | expr_xor
            ;

expr_xor    : expr_xor XOR expr_xor
            | expr_and
            ;

expr_and    : expr_and AND expr_and
            | equality
            ;

equality    : equality EQUAL equality
            | equality NEQUAL equality
            | comparison
            ;

comparison  : comparison LEQUAL comparison
            | comparison GEQUAL comparison
            | comparison LESS comparison
            | comparison MORE comparison
            | expr_arrows
            ;

expr_arrows : expr_arrows FORWARD expr_arrows
            | expr_arrows BACKWARD expr_arrows
            | sum
            ;
            
sum         : sum PLUS sum
            | sum MINUS sum
            | sum CONCAT sum
            | term
            ;
            
term        : term MULT term
            | term DIV term
            | term MOD term
            | expo
            ;
            
expo        : expo EXP expo
            | shifting
            ;

shifting    : shifting ASR shifting
            | shifting SHR shifting
            | shifting SHL shifting
            | unary
            ;
            
unary       : PLUS value
            | MINUS value
            | INVERT value
            | NEW value
            | value
            ;

value       : value DOT identifier
            | value META identifier
            | ENUM ROUND_O idlist ROUND_C
            | ENUM LESS type MORE ROUND_O fieldlist ROUND_C
            | REF LESS type MORE
            | RECORD ROUND_O fieldlist ROUND_C
            | ARRAY LESS type MORE
            | ARRAY LESS type COMMA NUMBER MORE
            | value SQUARE_O exprlist SQUARE_C
            | SQUARE_O exprlist SQUARE_C
            | value ROUND_O ROUND_C
            | value ROUND_O arglist ROUND_C
            | ROUND_O expression ROUND_C
            | identifier
            | functiontype
            | functiontype block
            | functiontype MAPSTO expression
            | LAMBDA ROUND_O idlist ROUND_C MAPSTO expression
            | STRING
            | ENUMVAL
            | NUMBER
            ;

idlist      : idlist COMMA identifier
            | identifier
            ;

fieldlist   : fieldlist COMMA field
            | field
            ;

field       : identifier COLON type terminator 
                $$ = new Declaration($1, $3, null);
                $$.IsField = true;
            | identifier IS    expression terminator 
                $$ = new Declaration($1, Undefined, $3);
                $$.IsField = true;
            | identifier COLON type IS expression terminator 
                $$ = new Declaration($1, $3, $5);
                $$.IsField = true;
            ;

functiontype: FN ROUND_O paramlist ROUND_C FORWARD type
            | FN ROUND_O ROUND_C FORWARD type
            | FN ROUND_O paramlist ROUND_C
            | FN ROUND_O ROUND_C
            ;

paramlist   : paramlist COMMA parameter
            | parameter
            ;

parameter   : prefix identifier COLON type IS expression
            | prefix identifier IS expression
            | prefix identifier COLON type
            ;

prefix      : /* empty */
            | prefix IN
            | prefix OUT
            | prefix INOUT
            | prefix THIS
            ;

arglist     : arglist COMMA argument
            | argument
            ;

argument    : expression
            | identifier COLON expression
            ;

exprlist    : expression
            | exprlist COMMA expression
            ;

block       : CURLY_O stmtlist CURLY_C
            | CURLY_O CURLY_C
            ;

stmtlist    : /* empty */
            | stmtlist statement
            ;

statement   : BREAK TERMINATOR
            | FALLTROUGH TERMINATOR
            | CONTINUE TERMINATOR
            | ERROR expression TERMINATOR
            | RETURN expression TERMINATOR
            | RETURN TERMINATOR
            | GOTO expression TERMINATOR
            | IF ROUND_O expression ROUND_C statement ELSE statement
            | IF ROUND_O expression ROUND_C statement
            | WHILE ROUND_O expression ROUND_C statement
            | LOOP statement UNTIL ROUND_O expression ROUND_C TERMINATOR
            | RESTRICT ROUND_O exprlist ROUND_C statement
            | FOR ROUND_O identifier IN expression ROUND_C statement
            | SELECT ROUND_O expression ROUND_C CURLY_O options CURLY_C
            | declaration
            | assertion
            | block
            | expression TERMINATOR
            | TERMINATOR
            ;

options     : /* empty */
            | options WHEN expression COLON stmtlist
            | options OTHERWISE COLON stmtlist
            ;

identifier  : IDENT
            | OPERATOR META opsym META
            ;

opsym       : PLUS | MINUS | MULT | DIV | AND | OR | INVERT | XOR | CONCAT | DOT | META | EXP | MOD
            | FORWARD | BACKWARD | LEQUAL | GEQUAL | EQUAL | NEQUAL | LESS | MORE | IS | ASSIGN
            | ASR | SHL | SHR
            | SQUARE_O SQUARE_C // array indexing operator symbol
            ;
```
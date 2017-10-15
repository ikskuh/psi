%{
    Dictionary<string,int> regs = new Dictionary<string,int>();
%}

%start program

%parsertype PsiParser
%tokentype PsiTokenType
%visibility public

%output="PsiParser.cs"

%YYSTYPE ParserNode

%token CURLY_O, CURLY_C, ROUND_O, ROUND_C, POINTY_O, POINTY_C, SQUARE_O, SQUARE_C
%token IMPORT, EXPORT, MODULE, ASSERT, ERROR, CONST, VAR, TYPE, FN, NEW
%token OPERATOR, ENUM, RECORD, OPTION, INOUT, IN, OUT, THIS, FOR, WHILE, LOOP, UNTIL
%token IF, ELSE, SELECT, WHEN, OTHERWISE, RESTRICT, BREAK, CONTINUE, NEXT, RETURN, GOTO
%token MAPSTO, FORWARD, BACKWAR, LEQUAL, GEQUAL, EQUAL, NEQUAL, LESS, MORE, IS, ASSIGN
%token CONCAT, DOT, META, COMMA, TERMINATOR, COLON, LAMBDA, PLUS, MINUS, EXP, MULT, MOD, DIV
%token AND, OR, INVERT, XOR

%token NUMBER, STRING, ENUMVAL, IDENT

// lexer ignored tokens:
%token Comment,	LongComment, Whitespace

// cheat mode activated :)
%left UMINUS, UPLUS, UINVERT

%namespace PsiCompiler

%%

program : /* empty */
        | program assertion
        | program declaration
        | program module
        ;

assertion : ASSERT expression TERMINATOR;

module : MODULE modname CURLY_O program CURLY_C 
       ;

modname : IDENT
        | modname DOT IDENT
        ;

declaration : export typedecl
            | export vardecl
            ;
            
typedecl : TYPE IDENT IS type TERMINATOR
         ;

vardecl  : storage IDENT COLON type terminator
         | storage IDENT IS expression terminator
         | storage IDENT COLON type IS expression terminator
         ;

terminator : /* optional */
           | TERMINATOR;

storage : CONST
        | VAR
        ;

export  : /* optional */
        | EXPORT
        ;

type : IDENT ;

expression : NUMBER;
%%

public PsiParser(PsiLexer lexer) : base(lexer) 
{ 
	
}

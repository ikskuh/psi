%start program

%parsertype PsiParser
%tokentype PsiTokenType
%visibility public

%output="PsiParser.cs"

%YYSTYPE ParserNode

// Brackets
%token <Token> CURLY_O, CURLY_C, ROUND_O, ROUND_C, SQUARE_O, SQUARE_C

// Keywords
%token <String> IMPORT, EXPORT, MODULE, ASSERT, ERROR, CONST, VAR, TYPE, FN, NEW
%token <String> OPERATOR, ENUM, RECORD, INOUT, IN, OUT, THIS, LAZY, FOR, WHILE, LOOP, UNTIL
%token <String> IF, ELSE, SELECT, WHEN, OTHERWISE, RESTRICT, BREAK, CONTINUE, FALLTROUGH, RETURN, GOTO
%token <String> MAPSTO, COMMA, TERMINATOR, COLON, LAMBDA, REF, ARRAY

// Operators
%left <PsiOperator> PLUS, MINUS, MULT, DIV
%left <PsiOperator> AND, OR, INVERT, XOR, CONCAT, DOT, META, EXP, MOD
%left <PsiOperator> FORWARD, BACKWARD, LEQUAL, GEQUAL, EQUAL, NEQUAL, LESS, MORE, IS, ASSIGN
%left <PsiOperator> ASR, SHL, SHR

%left <PsiOperator> WB_PLUS, WB_MINUS, WB_MULT, WB_DIV
%left <PsiOperator> WB_AND, WB_OR, WB_XOR, WB_CONCAT, WB_EXP, WB_MOD
%left <PsiOperator> WB_ASR, WB_SHL, WB_SHR

%token <String> NUMBER, STRING, ENUMVAL, IDENT

// lexer ignored tokens:
%token Comment,	LongComment, Whitespace

// cheat mode activated :)
%left UMINUS, UPLUS, UINVERT

%namespace Psi.Compiler.Grammar

%type <String> identifier opsym
%type <Module> module program
%type <Name> modname import
%type <Assertion> assertion
%type <Expression> type expression expr_or expr_xor expr_and equality comparison expr_arrows sum term expo shifting unary value
%type <ExpressionList> exprlist
%type <Declaration> declaration typedecl vardecl field
%type <Boolean> export storage
%type <ArgumentList> arglist
%type <Argument> argument
%type <FunctionType> functiontype
%type <ParameterList> paramlist
%type <Parameter> parameter
%type <ParameterPrefix> prefix
%type <Statement> statement block
%type <StatementList> stmtlist
%type <StringList> idlist
%type <FieldList> fieldlist
%type <SelectOptions> options

%%

program     : /* empty */         { $$ = new Module(); }
            | program assertion   { $$ = $1.Add($2); }
            | program declaration { $$ = $1.Add($2); }
            | program module      { $$ = $1.Add($2); }
            | program import      { $$ = $1.Add($2); }
            ;

assertion   : ASSERT expression TERMINATOR
			{
            	$$ = new Assertion($2); 
            }
            ;

import      : IMPORT modname TERMINATOR
			{
				$$ = $2;
			}
			;

module      : MODULE modname CURLY_O program CURLY_C
			{
				$$ = $4;
				$$.Name = $2;
			}
            ;

modname     : identifier
			{
            	$$ = new CompoundName($1); 
            }
            | modname DOT identifier
			{
            	$$ = $1;
            	$$.Add($3);
        	}
            ;

declaration : export typedecl
			{
            	$$ = $2;
            	$$.IsExported = (bool)$1;
            }
            | export vardecl
			{
            	$$ = $2;
            	$$.IsExported = (bool)$1;
            }
            ;
            
typedecl    : TYPE identifier IS expression TERMINATOR
			{
            	$$ = new Declaration($2, TypeDeclaration, $4);
            	$$.IsConst = true;
            }
            ;

vardecl     : storage identifier COLON type terminator
			{
            	$$ = new Declaration($2, $4, null);
            	$$.IsConst = (bool)$1;
            }
            | storage identifier IS    expression terminator
            {
            	$$ = new Declaration($2, Undefined, $4);
            	$$.IsConst = (bool)$1;
            }
            | storage identifier COLON type IS expression terminator
			{
            	$$ = new Declaration($2, $4, $6);
            	$$.IsConst = (bool)$1;
            }
            ;
            
type        : value
			{
				$$ = $1;
			}
			;

terminator  : /* optional */
            | TERMINATOR;

storage     : CONST          { $$ = true;  }
            | VAR            { $$ = false; }
            ;

export      : /* optional */ { $$ = false; }
            | EXPORT         { $$ = true;  }
            ;

expression  : expression IS expression
			{
				$$ = Apply($1, $3, PsiOperator.CopyAssign);
			}
			| expression ASSIGN expression
			{
				$$ = Apply($1, $3, PsiOperator.SemanticAssign);
			}
			| expression WB_CONCAT expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackConcat);
			}
			| expression WB_PLUS expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackPlus);
			}
			| expression WB_MINUS expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackMinus);
			}
			| expression WB_EXP expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackExponentiate);
			}
			| expression WB_MULT expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackMultiply);
			}
			| expression WB_MOD expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackModulo);
			}
			| expression WB_DIV expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackDivide);
			}
			| expression WB_AND expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackAnd);
			}
			| expression WB_OR expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackOr);
			}
			| expression WB_XOR expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackXor);
			}
			| expression WB_ASR expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackArithmeticShiftRight);
			}
			| expression WB_SHL expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackShiftLeft);
			}
			| expression WB_SHR expression
			{
				$$ = Apply($1, $3, PsiOperator.WritebackShiftRight);
			}
			| expr_or
			{
				$$ = $1;
			}
			;

expr_or     : expr_or OR expr_or
			{
				$$ = Apply($1, $3, PsiOperator.Or);
			}
			| expr_xor
			{
				$$ = $1;
			}
			;

expr_xor    : expr_xor XOR expr_xor
			{
				$$ = Apply($1, $3, PsiOperator.Xor);
			}
			| expr_and
			{
				$$ = $1;
			}
			;

expr_and    : expr_and AND expr_and
			{
				$$ = Apply($1, $3, PsiOperator.And);
			}
			| equality
			{
				$$ = $1;
			}
			;

equality    : equality EQUAL equality
			{
				$$ = Apply($1, $3, PsiOperator.Equals);
			}
			| equality NEQUAL equality
			{
				$$ = Apply($1, $3, PsiOperator.NotEquals);
			}
			| comparison
			{
				$$ = $1;
			}
			;

comparison  : comparison LEQUAL comparison
			{
				$$ = Apply($1, $3, PsiOperator.LessOrEqual);
			}
			| comparison GEQUAL comparison
			{
				$$ = Apply($1, $3, PsiOperator.MoreOrEqual);
			}
			| comparison LESS comparison
			{
				$$ = Apply($1, $3, PsiOperator.Less);
			}
			| comparison MORE comparison
			{
				$$ = Apply($1, $3, PsiOperator.More);
			}
			| expr_arrows
			{
				$$ = $1;
			}
			;

expr_arrows : expr_arrows FORWARD expr_arrows
			{
				$$ = Apply($1, $3, PsiOperator.Forward);
			}
			| expr_arrows BACKWARD expr_arrows
			{
				$$ = Apply($1, $3, PsiOperator.Backward);
			}
			| sum
			{
				$$ = $1;
			}
			;
			
sum         : sum PLUS sum
			{
				$$ = Apply($1, $3, PsiOperator.Plus);
			}
			| sum MINUS sum
			{
				$$ = Apply($1, $3, PsiOperator.Minus);
			}
			| sum CONCAT sum
			{
				$$ = Apply($1, $3, PsiOperator.Concat);
			}
			| term
			{
				$$ = $1;
			}
			;
			
term        : term MULT term
			{
				$$ = Apply($1, $3, PsiOperator.Multiply);
			}
			| term DIV term
			{
				$$ = Apply($1, $3, PsiOperator.Divide);
			}
			| term MOD term
			{
				$$ = Apply($1, $3, PsiOperator.Modulo);
			}
			| expo
			{
				$$ = $1;
			}
			;
			
expo        : expo EXP expo
			{
				$$ = Apply($1, $3, PsiOperator.Exponentiate);
			}
			| shifting
			{
				$$ = $1;
			}
			;

shifting    : shifting ASR shifting
			{
				$$ = Apply($1, $3, PsiOperator.ArithmeticShiftRight);
			}
			| shifting SHR shifting
			{
				$$ = Apply($1, $3, PsiOperator.ShiftRight);
			}
			| shifting SHL shifting
			{
				$$ = Apply($1, $3, PsiOperator.ShiftLeft);
			}
			| unary
			{
				$$ = $1;
			}
			;
			
unary       : PLUS value
			{
				$$ = Apply($2, PsiOperator.Plus);
			}
			| MINUS value
			{
				$$ = Apply($2, PsiOperator.Minus);
			}
			| INVERT value
			{
				$$ = Apply($2, PsiOperator.Invert);
			}
			| NEW value
			{
				$$ = Apply($2, PsiOperator.New);
			}
			| value
			{
				$$ = $1;
			}
			;

value       : value DOT identifier
			{
				$$ = ApplyDot($1, $3);
			}
			| value META identifier
			{
				$$ = ApplyMeta($1, $3);
			}
			| ENUM ROUND_O idlist ROUND_C
			{
				$$ = new EnumTypeLiteral($3);
			}
			| ENUM LESS type MORE ROUND_O fieldlist ROUND_C
			{
				$$ = new TypedEnumTypeLiteral($3, $6);
			}
			| REF LESS type MORE
			{
				$$ = new ReferenceTypeLiteral($3);
			}
			| RECORD ROUND_O fieldlist ROUND_C
			{
				$$ = new RecordTypeLiteral($3);
			}
			| ARRAY LESS type MORE
			{
				$$ = new ArrayTypeLiteral($3, 1);
			}
			| ARRAY LESS type COMMA NUMBER MORE
			{
				$$ = new ArrayTypeLiteral($3, int.Parse($5));
			}
			| value SQUARE_O exprlist SQUARE_C
			{
				$$ = new ArrayIndexingExpression($1, $3);
			}
			| SQUARE_O exprlist SQUARE_C
			{
				$$ = new ArrayLiteral($2);
			}
			| value ROUND_O ROUND_C
			{
				$$ = new FunctionCallExpression($1, new List<Argument>());
			}
			| value ROUND_O arglist ROUND_C
			{
				$$ = new FunctionCallExpression($1, $3);
			}
			| ROUND_O expression ROUND_C
            {
                $$ = $2;
            }
            | identifier
			{
            	$$ = new VariableReference($1);
            }
			| functiontype
			{
				$$ = $1;
			}
			| functiontype block
			{
				$$ = new FunctionLiteral($1, $2);
			}
			| functiontype MAPSTO expression
			{
				$$ = new FunctionLiteral($1, new ExpressionStatement($3));
			}
			| LAMBDA ROUND_O idlist ROUND_C MAPSTO expression
			{
				$$ = new LambdaLiteral($3, new ExpressionStatement($6));
			}
            | STRING
			{
				$$ = new StringLiteral($1);
            }
            | ENUMVAL
			{
				$$ = new EnumLiteral($1);
            }
            | NUMBER
			{
				$$ = new NumberLiteral($1);
            }
            ;

idlist      : idlist COMMA identifier
			{
				$$ = $1;
				$$.Add($3);
			}
			| identifier
			{
				$$ = new List<string>();
				$$.Add($1);
			}
			;

fieldlist   : fieldlist COMMA field
			{
				$$ = $1;
				$$.Add($3);	
			}
			| field
			{
				$$ = new List<Declaration>();
				$$.Add($1);
			}
			;

field       : identifier COLON type terminator {
            	$$ = new Declaration($1, $3, null);
            	$$.IsField = true;
            }
            | identifier IS    expression terminator {
            	$$ = new Declaration($1, Undefined, $3);
            	$$.IsField = true;
            }
            | identifier COLON type IS expression terminator {
            	$$ = new Declaration($1, $3, $5);
            	$$.IsField = true;
            }
            ;

functiontype: FN ROUND_O paramlist ROUND_C FORWARD type
			{
				$$ = new FunctionTypeLiteral($3, $6);
			}
			| FN ROUND_O ROUND_C FORWARD type
			{
				$$ = new FunctionTypeLiteral(new List<Parameter>(), $5);
			}
			| FN ROUND_O paramlist ROUND_C
			{
				$$ = new FunctionTypeLiteral($3, Void);
			}
			| FN ROUND_O ROUND_C
			{
				$$ = new FunctionTypeLiteral(new List<Parameter>(), Void);
			}
			;

paramlist   : paramlist COMMA parameter
			{
				$$ = $1;
				$$.Add($3);
			}
			| parameter
			{
				$$ = new List<Parameter>();
				$$.Add($1);
			}
			;

parameter   : prefix identifier COLON type IS expression
			{
				$$ = new Parameter((Psi.Runtime.ParameterFlags)$1, $2, $4, $6);
			}
			| prefix identifier IS expression
			{
				$$ = new Parameter((Psi.Runtime.ParameterFlags)$1, $2, Undefined, $4);
			}
			| prefix identifier COLON type
			{
				$$ = new Parameter((Psi.Runtime.ParameterFlags)$1, $2, $4, null);
			}
			;

prefix      : /* empty */
			{
				$$ = Psi.Runtime.ParameterFlags.None;
			}
			| prefix IN
			{
				$$ = $1 | Psi.Runtime.ParameterFlags.In;
			}
			| prefix OUT
			{
				$$ = $1 | Psi.Runtime.ParameterFlags.Out;
			}
			| prefix INOUT
			{
				$$ = $1 | Psi.Runtime.ParameterFlags.InOut;
			}
			| prefix THIS
			{
				$$ = $1 | Psi.Runtime.ParameterFlags.This;
			}
			| prefix LAZY
			{
				$$ = $1 | Psi.Runtime.ParameterFlags.Lazy;
			}
			;

arglist     : arglist COMMA argument
			{
				$$ = $1;
				$$.Add($3);
			}
			| argument
			{
				$$ = new List<Argument>();
				$$.Add($1);
			}
			;

argument	: expression
			{
				$$ = new PositionalArgument($1);
			}
			| identifier COLON expression
			{
				$$ = new NamedArgument($1, $3);
			}
			;

exprlist    : expression
			{
				$$ = new List<Expression>();
				$$.Add($1);
			}
			| exprlist COMMA expression
			{
				$$ = $1;
				$$.Add($3);
			}
			;

block       : CURLY_O stmtlist CURLY_C
			{
				$$ = new Block($2);
			}
			| CURLY_O CURLY_C
			{
				$$ = new Block(new List<Statement>());
			}
			;

stmtlist    : /* empty */
			{
				$$ = new List<Statement>();
			}
			| stmtlist statement
			{
				$$ = $1;
				$$.Add($2);
			}
			;

statement   : declaration
			{
				$$ = $1;
			}
			| assertion
			{
				$$ = $1;
			}
			| block
			{
				$$ = $1;
			}
			| BREAK TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Break);
			}
			| FALLTROUGH TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Fallthrough);
			}
			| CONTINUE TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Continue);
			}
			| ERROR expression TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Error, $2);
			}
			| RETURN expression TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Return, $2);
			}
			| RETURN TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Return);
			}
			| GOTO expression TERMINATOR
			{
				$$ = new FlowBreakStatement(FlowBreakType.Goto, $2);
			}
			| IF ROUND_O expression ROUND_C statement ELSE statement
			{
				$$ = new IfElseStatement($3, $5, $7);
			}
			| IF ROUND_O expression ROUND_C statement
			{
				$$ = new IfElseStatement($3, $5, null);
			}
			| WHILE ROUND_O expression ROUND_C statement
			{
				$$ = new WhileLoopStatement($3, $5);
			}
			| LOOP statement UNTIL ROUND_O expression ROUND_C TERMINATOR
			{
				$$ = new LoopUntilStatement($5, $2);
			}
			| RESTRICT ROUND_O exprlist ROUND_C statement
			{
				$$ = new RestrictStatement($3, $5);
			}
			| FOR ROUND_O identifier IN expression ROUND_C statement
			{
				$$ = new ForLoopStatement($3, $5, $7);
			}
			| SELECT ROUND_O expression ROUND_C CURLY_O options CURLY_C
			{
				$$ = new SelectStatement($3, $6);
			}
			| expression TERMINATOR
			{
				$$ = new ExpressionStatement($1);
			}
			| TERMINATOR
			{
				$$ = Statement.Null;
			}
			;

options     : /* empty */
			{
				$$ = new List<SelectOption>();
			}
			| options WHEN expression COLON stmtlist
			{
				$$ = $1;
				$$.Add(new SelectOption($3, new Block($5)));
			}
			| options OTHERWISE COLON stmtlist
			{
				$$ = $1;
				$$.Add(new SelectOption(new Block($4)));
			}
			;

identifier  : IDENT
			| OPERATOR META opsym META
			;

/*			
| CONST
| IMPORT
| EXPORT
| MODULE
| ASSERT
| ERROR
| FN
| NEW
| OPERATOR
| INOUT
| IN
| OUT
| THIS
| FOR
| WHILE
| LOOP
| UNTIL
| IF
| ELSE
| SELECT
| WHEN
| OTHERWISE
| RESTRICT
| BREAK
| CONTINUE
| RETURN
| GOTO
*/

opsym       : PLUS | MINUS | MULT | DIV | AND | OR | INVERT | XOR | CONCAT | DOT | META | EXP | MOD
			| FORWARD | BACKWARD | LEQUAL | GEQUAL | EQUAL | NEQUAL | LESS | MORE | IS | ASSIGN
			| ASR | SHL | SHR
			| SQUARE_O SQUARE_C // array indexing operator symbol
			;
%%

public PsiParser(PsiLexer lexer) : base(lexer) 
{ 
	
}

public Module Result => this.CurrentSemanticValue.Module;

public static Expression TypeDeclaration { get; } = new VariableReference("<type>");

public static Expression Undefined { get; } = new VariableReference("<?>");

public static Expression Void { get; } = new VariableReference("<void>");

private static Expression Apply(Expression lhs, Expression rhs, PsiOperator op)
{
	return new BinaryOperation(op, lhs, rhs);
}

private static Expression Apply(Expression expr, PsiOperator op)
{
	return new UnaryOperation(op, expr);
}

private static Expression ApplyDot(Expression exp, string field)
{
	return new DotExpression(exp, field);
}

private static Expression ApplyMeta(Expression exp, string field)
{
	return new MetaExpression(exp, field);
}
%{
    Dictionary<string,int> regs = new Dictionary<string,int>();
%}

%start program

%parsertype PsiParser
%tokentype PsiTokenType
%visibility public

%output="PsiParser.cs"

%YYSTYPE ParserNode

// Brackets
%token <Token> CURLY_O, CURLY_C, ROUND_O, ROUND_C, POINTY_O, POINTY_C, SQUARE_O, SQUARE_C

// Keywords
%token <Token> IMPORT, EXPORT, MODULE, ASSERT, ERROR, CONST, VAR, TYPE, FN, NEW
%token <Token> OPERATOR, ENUM, RECORD, OPTION, INOUT, IN, OUT, THIS, FOR, WHILE, LOOP, UNTIL
%token <Token> IF, ELSE, SELECT, WHEN, OTHERWISE, RESTRICT, BREAK, CONTINUE, NEXT, RETURN, GOTO
%token <Token> MAPSTO, COMMA, TERMINATOR, COLON, LAMBDA

// Operators
%left <PsiOperator> PLUS, MINUS, MULT, DIV
%left <PsiOperator> AND, OR, INVERT, XOR, CONCAT, DOT, META, EXP, MOD
%left <PsiOperator> FORWARD, BACKWARD, LEQUAL, GEQUAL, EQUAL, NEQUAL, LESS, MORE, IS, ASSIGN
%left <PsiOperator> ASR, SHL, SHR

%left <PsiOperator> WB_PLUS, WB_MINUS, WB_MULT, WB_DIV
%left <PsiOperator> WB_AND, WB_OR, WB_INVERT, WB_XOR, WB_CONCAT, WB_EXP, WB_MOD
%left <PsiOperator> WB_ASR, WB_SHL, WB_SHR

%token <Token> NUMBER, STRING, ENUMVAL, IDENT

// lexer ignored tokens:
%token Comment,	LongComment, Whitespace

// cheat mode activated :)
%left UMINUS, UPLUS, UINVERT

%namespace PsiCompiler.Grammar

%type <Token> identifier
%type <Module> module program
%type <Name> modname
%type <Assertion> assertion
%type <Expression> expression expr_or expr_xor expr_and equality comparison expr_arrows sum term expo shifting unary value
%type <Declaration> declaration typedecl vardecl
%type <Boolean> export storage

%%

program     : /* empty */         { $$ = new Module(); }
            | program assertion   { $$ = $1.Add($2); }
            | program declaration { $$ = $1.Add($2); }
            | program module      { $$ = $1.Add($2); }
            ;

assertion   : ASSERT expression TERMINATOR {
            	$$ = new Assertion($2); 
            }
            ;

module      : MODULE modname CURLY_O program CURLY_C {
				$$ = $4;
				$$.Name = $2;
			}
            ;

modname     : identifier {
            	$$ = new CompoundName($1.Text); 
            }
            | modname DOT identifier {
            	$$ = $1;
            	$$.Add($3.Text);
        	}
            ;

declaration : export typedecl {
            	$$ = $2;
            	$$.IsExported = (bool)$1;
            }
            | export vardecl {
            	$$ = $2;
            	$$.IsExported = (bool)$1;
            }
            ;
            
typedecl    : TYPE identifier IS expression TERMINATOR {
            	$$ = new Declaration($2.Text, TypeDeclaration, $4);
            	$$.IsConst = true;
            }
            ;

vardecl     : storage identifier COLON expression terminator {
            	$$ = new Declaration($2.Text, $4, null);
            	$$.IsConst = (bool)$1;
            }
            | storage identifier IS    expression terminator {
            	$$ = new Declaration($2.Text, null, $4);
            	$$.IsConst = (bool)$1;
            }
            | storage identifier COLON expression IS expression terminator {
            	$$ = new Declaration($2.Text, $4, $6);
            	$$.IsConst = (bool)$1;
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

expression  : expression IS expr_or
			{
				$$ = Apply($1, $3, PsiOperator.CopyAssign);
			}
			| expression ASSIGN expr_or
			{
				$$ = Apply($1, $3, PsiOperator.CopyAssign);
			}
			| expression WB_CONCAT expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackConcat);
			}
			| expression WB_PLUS expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackPlus);
			}
			| expression WB_MINUS expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackMinus);
			}
			| expression WB_EXP expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackExponentiate);
			}
			| expression WB_MULT expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackMultiply);
			}
			| expression WB_MOD expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackModulo);
			}
			| expression WB_DIV expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackDivide);
			}
			| expression WB_AND expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackAnd);
			}
			| expression WB_OR expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackOr);
			}
			| expression WB_INVERT expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackInvert);
			}
			| expression WB_XOR expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackXor);
			}
			| expression WB_ASR expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackArithmeticShiftRight);
			}
			| expression WB_SHL expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackShiftLeft);
			}
			| expression WB_SHR expr_or
			{
				$$ = Apply($1, $3, PsiOperator.WritebackShiftRight);
			}
			| expr_or
			{
				$$ = $1;
			}
			;

expr_or     : expr_or OR expr_xor
			{
				$$ = Apply($1, $3, PsiOperator.Or);
			}
			| expr_xor
			{
				$$ = $1;
			}
			;

expr_xor    : expr_xor OR expr_and
			{
				$$ = Apply($1, $3, PsiOperator.Xor);
			}
			| expr_and
			{
				$$ = $1;
			}
			;

expr_and    : expr_and AND equality
			{
				$$ = Apply($1, $3, PsiOperator.And);
			}
			| equality
			{
				$$ = $1;
			}
			;

equality    : equality EQUAL comparison
			{
				$$ = Apply($1, $3, PsiOperator.Equals);
			}
			| equality NEQUAL comparison
			{
				$$ = Apply($1, $3, PsiOperator.NotEquals);
			}
			| comparison
			{
				$$ = $1;
			}
			;

comparison  : comparison LEQUAL expr_arrows
			{
				$$ = Apply($1, $3, PsiOperator.LessOrEqual);
			}
			| comparison GEQUAL expr_arrows
			{
				$$ = Apply($1, $3, PsiOperator.MoreOrEqual);
			}
			| comparison LESS expr_arrows
			{
				$$ = Apply($1, $3, PsiOperator.Less);
			}
			| comparison MORE expr_arrows
			{
				$$ = Apply($1, $3, PsiOperator.More);
			}
			| expr_arrows
			{
				$$ = $1;
			}
			;


expr_arrows : expr_arrows FORWARD sum
			{
				$$ = Apply($1, $3, PsiOperator.Equals);
			}
			| expr_arrows NEQUAL sum
			{
				$$ = Apply($1, $3, PsiOperator.NotEquals);
			}
			| sum
			{
				$$ = $1;
			}
			;
			
sum         : sum PLUS term
			{
				$$ = Apply($1, $3, PsiOperator.Plus);
			}
			| sum MINUS term
			{
				$$ = Apply($1, $3, PsiOperator.Minus);
			}
			| sum CONCAT term
			{
				$$ = Apply($1, $3, PsiOperator.Concat);
			}
			| term
			{
				$$ = $1;
			}
			;
			
term        : term MULT expo
			{
				$$ = Apply($1, $3, PsiOperator.Multiply);
			}
			| term DIV expo
			{
				$$ = Apply($1, $3, PsiOperator.Divide);
			}
			| term MOD expo
			{
				$$ = Apply($1, $3, PsiOperator.Modulo);
			}
			| expo
			{
				$$ = $1;
			}
			;
			
expo        : expo EXP shifting
			{
				$$ = Apply($1, $3, PsiOperator.Exponentiate);
			}
			| shifting
			{
				$$ = $1;
			}
			;

shifting    : shifting ASR unary
			{
				$$ = Apply($1, $3, PsiOperator.ArithmeticShiftRight);
			}
			| shifting SHR unary
			{
				$$ = Apply($1, $3, PsiOperator.ShiftRight);
			}
			| shifting SHL unary
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
			| value
			{
				$$ = $1;
			}
			;

value       : ROUND_O expression ROUND_C
            {
                $$ = $2;
            }
            | identifier
			{
            	$$ = new VariableReference($1.Text);
            }
            | NUMBER
			{
				$$ = new NumberLiteral($1.Text);
            }
            ;

// Allow any keyword as an identifier
// HACK: this may be useful when the tokenizer can be "informed" about
//       requiring a specific token
identifier  : IDENT
			| IMPORT
			| EXPORT
			| MODULE
			| ASSERT
			| ERROR
			| CONST
			| VAR
			| TYPE
			| FN
			| NEW
			| OPERATOR
			| ENUM
			| RECORD
			| OPTION
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
			| NEXT
			| RETURN
			| GOTO
			;
%%

public PsiParser(PsiLexer lexer) : base(lexer) 
{ 
	
}

public Module Result => this.CurrentSemanticValue.Module;

public Expression TypeDeclaration { get; } = new VariableReference("<type>");

private static Expression Apply(Expression lhs, Expression rhs, PsiOperator op)
{
	return new BinaryOperation(op, lhs, rhs);
}

private static Expression Apply(Expression expr, PsiOperator op)
{
	return new UnaryOperation(op, expr);
}
using System;
using System.Collections.Generic;
using CompilerKit;

namespace Psi.Compiler.Grammar
{
	public struct ParserNode
	{
		private Token<PsiTokenType> _Token;
		private Expression _Expression;
		private AstType _AstType;
		private Module _Module;
		private Assertion _Assertion;
		private CompoundName _Name;
		private Declaration _Declaration;
		private TypeDeclaration _TypeDeclaration;
		private bool? _Boolean;
		private PsiOperator? _Operator;
		private string _String;
		private List<Expression> _ExpressionList;
		private List<Argument> _ArgumentList;
		private Argument _Argument;
		private List<Parameter> _ParameterList;
		private Parameter _Parameter;
		private ParameterFlags? _ParameterPrefix;
		private FunctionTypeLiteral _FunctionType;
		private Statement _Statement;
		private List<Statement> _StatementList;
		private List<string> _StringList;
		private List<Declaration> _FieldList;
		private SelectOption _SelectOption;
		private List<SelectOption> _SelectOptions;
		
		public ParserNode(Token<PsiTokenType> value)
		{
			this._Token = value.NotNull();
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Expression value)
		{
			this._Token = null;
			this._Expression = value.NotNull();
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(AstType value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = value.NotNull();
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Module value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = value.NotNull();
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Assertion value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = value.NotNull();
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(CompoundName value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = value.NotNull();
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Declaration value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = value.NotNull();
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(TypeDeclaration value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = value.NotNull();
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(bool? value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = value.NotNull();
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(PsiOperator? value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = value.NotNull();
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(string value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = value.NotNull();
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(List<Expression> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = value.NotNull();
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(List<Argument> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = value.NotNull();
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Argument value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = value.NotNull();
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(List<Parameter> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = value.NotNull();
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Parameter value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = value.NotNull();
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(ParameterFlags? value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = value.NotNull();
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(FunctionTypeLiteral value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = value.NotNull();
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(Statement value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = value.NotNull();
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(List<Statement> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = value.NotNull();
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(List<string> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = value.NotNull();
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(List<Declaration> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = value.NotNull();
			this._SelectOption = null;
			this._SelectOptions = null;
		}
		
		public ParserNode(SelectOption value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = value.NotNull();
			this._SelectOptions = null;
		}
		
		public ParserNode(List<SelectOption> value)
		{
			this._Token = null;
			this._Expression = null;
			this._AstType = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._TypeDeclaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;
			this._ParameterList = null;
			this._Parameter = null;
			this._ParameterPrefix = null;
			this._FunctionType = null;
			this._Statement = null;
			this._StatementList = null;
			this._StringList = null;
			this._FieldList = null;
			this._SelectOption = null;
			this._SelectOptions = value.NotNull();
		}
		
		public Token<PsiTokenType> Token
		{
			get
			{
				if(this._Token == null)
					throw new InvalidOperationException("ParserNode is not a Token");
				return this._Token;
			}
			set
			{
				this._Token = value;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Expression Expression
		{
			get
			{
				if(this._Expression == null)
					throw new InvalidOperationException("ParserNode is not a Expression");
				return this._Expression;
			}
			set
			{
				this._Token = null;
				this._Expression = value;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public AstType AstType
		{
			get
			{
				if(this._AstType == null)
					throw new InvalidOperationException("ParserNode is not a AstType");
				return this._AstType;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = value;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Module Module
		{
			get
			{
				if(this._Module == null)
					throw new InvalidOperationException("ParserNode is not a Module");
				return this._Module;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = value;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Assertion Assertion
		{
			get
			{
				if(this._Assertion == null)
					throw new InvalidOperationException("ParserNode is not a Assertion");
				return this._Assertion;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = value;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public CompoundName Name
		{
			get
			{
				if(this._Name == null)
					throw new InvalidOperationException("ParserNode is not a Name");
				return this._Name;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = value;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Declaration Declaration
		{
			get
			{
				if(this._Declaration == null)
					throw new InvalidOperationException("ParserNode is not a Declaration");
				return this._Declaration;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = value;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public TypeDeclaration TypeDeclaration
		{
			get
			{
				if(this._TypeDeclaration == null)
					throw new InvalidOperationException("ParserNode is not a TypeDeclaration");
				return this._TypeDeclaration;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = value;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public bool? Boolean
		{
			get
			{
				if(this._Boolean == null)
					throw new InvalidOperationException("ParserNode is not a Boolean");
				return this._Boolean;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = value;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public PsiOperator? Operator
		{
			get
			{
				if(this._Operator == null)
					throw new InvalidOperationException("ParserNode is not a Operator");
				return this._Operator;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = value;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public string String
		{
			get
			{
				if(this._String == null)
					throw new InvalidOperationException("ParserNode is not a String");
				return this._String;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = value;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public List<Expression> ExpressionList
		{
			get
			{
				if(this._ExpressionList == null)
					throw new InvalidOperationException("ParserNode is not a ExpressionList");
				return this._ExpressionList;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = value;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public List<Argument> ArgumentList
		{
			get
			{
				if(this._ArgumentList == null)
					throw new InvalidOperationException("ParserNode is not a ArgumentList");
				return this._ArgumentList;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = value;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Argument Argument
		{
			get
			{
				if(this._Argument == null)
					throw new InvalidOperationException("ParserNode is not a Argument");
				return this._Argument;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = value;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public List<Parameter> ParameterList
		{
			get
			{
				if(this._ParameterList == null)
					throw new InvalidOperationException("ParserNode is not a ParameterList");
				return this._ParameterList;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = value;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Parameter Parameter
		{
			get
			{
				if(this._Parameter == null)
					throw new InvalidOperationException("ParserNode is not a Parameter");
				return this._Parameter;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = value;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public ParameterFlags? ParameterPrefix
		{
			get
			{
				if(this._ParameterPrefix == null)
					throw new InvalidOperationException("ParserNode is not a ParameterPrefix");
				return this._ParameterPrefix;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = value;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public FunctionTypeLiteral FunctionType
		{
			get
			{
				if(this._FunctionType == null)
					throw new InvalidOperationException("ParserNode is not a FunctionType");
				return this._FunctionType;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = value;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public Statement Statement
		{
			get
			{
				if(this._Statement == null)
					throw new InvalidOperationException("ParserNode is not a Statement");
				return this._Statement;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = value;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public List<Statement> StatementList
		{
			get
			{
				if(this._StatementList == null)
					throw new InvalidOperationException("ParserNode is not a StatementList");
				return this._StatementList;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = value;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public List<string> StringList
		{
			get
			{
				if(this._StringList == null)
					throw new InvalidOperationException("ParserNode is not a StringList");
				return this._StringList;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = value;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public List<Declaration> FieldList
		{
			get
			{
				if(this._FieldList == null)
					throw new InvalidOperationException("ParserNode is not a FieldList");
				return this._FieldList;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = value;
				this._SelectOption = null;
				this._SelectOptions = null;
			}
		}
		
		public SelectOption SelectOption
		{
			get
			{
				if(this._SelectOption == null)
					throw new InvalidOperationException("ParserNode is not a SelectOption");
				return this._SelectOption;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = value;
				this._SelectOptions = null;
			}
		}
		
		public List<SelectOption> SelectOptions
		{
			get
			{
				if(this._SelectOptions == null)
					throw new InvalidOperationException("ParserNode is not a SelectOptions");
				return this._SelectOptions;
			}
			set
			{
				this._Token = null;
				this._Expression = null;
				this._AstType = null;
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._TypeDeclaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;
				this._ParameterList = null;
				this._Parameter = null;
				this._ParameterPrefix = null;
				this._FunctionType = null;
				this._Statement = null;
				this._StatementList = null;
				this._StringList = null;
				this._FieldList = null;
				this._SelectOption = null;
				this._SelectOptions = value;
			}
		}
		
		public static implicit operator ParserNode(Token<PsiTokenType> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Expression value) => new ParserNode(value);
		
		public static implicit operator ParserNode(AstType value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Module value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Assertion value) => new ParserNode(value);
		
		public static implicit operator ParserNode(CompoundName value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Declaration value) => new ParserNode(value);
		
		public static implicit operator ParserNode(TypeDeclaration value) => new ParserNode(value);
		
		public static implicit operator ParserNode(bool? value) => new ParserNode(value);
		
		public static implicit operator ParserNode(PsiOperator? value) => new ParserNode(value);
		
		public static implicit operator ParserNode(string value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Expression> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Argument> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Argument value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Parameter> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Parameter value) => new ParserNode(value);
		
		public static implicit operator ParserNode(ParameterFlags? value) => new ParserNode(value);
		
		public static implicit operator ParserNode(FunctionTypeLiteral value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Statement value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Statement> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<string> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Declaration> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(SelectOption value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<SelectOption> value) => new ParserNode(value);
		
		public override string ToString()
		{
			if(this._Token != null)
				return "Node(Token): " + _Token.ToString();
			if(this._Expression != null)
				return "Node(Expression): " + _Expression.ToString();
			if(this._AstType != null)
				return "Node(AstType): " + _AstType.ToString();
			if(this._Module != null)
				return "Node(Module): " + _Module.ToString();
			if(this._Assertion != null)
				return "Node(Assertion): " + _Assertion.ToString();
			if(this._Name != null)
				return "Node(Name): " + _Name.ToString();
			if(this._Declaration != null)
				return "Node(Declaration): " + _Declaration.ToString();
			if(this._TypeDeclaration != null)
				return "Node(TypeDeclaration): " + _TypeDeclaration.ToString();
			if(this._Boolean != null)
				return "Node(Boolean): " + _Boolean.ToString();
			if(this._Operator != null)
				return "Node(Operator): " + _Operator.ToString();
			if(this._String != null)
				return "Node(String): " + _String.ToString();
			if(this._ExpressionList != null)
				return "Node(ExpressionList): " + _ExpressionList.ToString();
			if(this._ArgumentList != null)
				return "Node(ArgumentList): " + _ArgumentList.ToString();
			if(this._Argument != null)
				return "Node(Argument): " + _Argument.ToString();
			if(this._ParameterList != null)
				return "Node(ParameterList): " + _ParameterList.ToString();
			if(this._Parameter != null)
				return "Node(Parameter): " + _Parameter.ToString();
			if(this._ParameterPrefix != null)
				return "Node(ParameterPrefix): " + _ParameterPrefix.ToString();
			if(this._FunctionType != null)
				return "Node(FunctionType): " + _FunctionType.ToString();
			if(this._Statement != null)
				return "Node(Statement): " + _Statement.ToString();
			if(this._StatementList != null)
				return "Node(StatementList): " + _StatementList.ToString();
			if(this._StringList != null)
				return "Node(StringList): " + _StringList.ToString();
			if(this._FieldList != null)
				return "Node(FieldList): " + _FieldList.ToString();
			if(this._SelectOption != null)
				return "Node(SelectOption): " + _SelectOption.ToString();
			if(this._SelectOptions != null)
				return "Node(SelectOptions): " + _SelectOptions.ToString();
			return "<???>";
		}
	}
}

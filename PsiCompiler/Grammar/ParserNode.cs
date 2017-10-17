









using System;
using System.Collections.Generic;
using CompilerKit;

namespace PsiCompiler.Grammar
{
	public struct ParserNode
	{
		private Token<PsiTokenType> _Token;
		private Expression _Expression;
		private Module _Module;
		private Assertion _Assertion;
		private CompoundName _Name;
		private Declaration _Declaration;
		private bool? _Boolean;
		private PsiOperator? _Operator;
		private string _String;
		private List<Expression> _ExpressionList;
		private List<Argument> _ArgumentList;
		private Argument _Argument;
		
		public ParserNode(Token<PsiTokenType> value)
		{
			this._Token = value.NotNull();
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(Expression value)
		{
			this._Token = null;
			this._Expression = value.NotNull();
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(Module value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = value.NotNull();
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(Assertion value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = value.NotNull();
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(CompoundName value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = value.NotNull();
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(Declaration value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = value.NotNull();
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(bool? value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = value.NotNull();
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(PsiOperator? value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = value.NotNull();
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(string value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = value.NotNull();
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(List<Expression> value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = value.NotNull();
			this._ArgumentList = null;
			this._Argument = null;

		}
		
		public ParserNode(List<Argument> value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = value.NotNull();
			this._Argument = null;

		}
		
		public ParserNode(Argument value)
		{
			this._Token = null;
			this._Expression = null;
			this._Module = null;
			this._Assertion = null;
			this._Name = null;
			this._Declaration = null;
			this._Boolean = null;
			this._Operator = null;
			this._String = null;
			this._ExpressionList = null;
			this._ArgumentList = null;
			this._Argument = value.NotNull();

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = value;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = value;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = value;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = value;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = value;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = value;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = value;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = value;
				this._ArgumentList = null;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = value;
				this._Argument = null;

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
				this._Module = null;
				this._Assertion = null;
				this._Name = null;
				this._Declaration = null;
				this._Boolean = null;
				this._Operator = null;
				this._String = null;
				this._ExpressionList = null;
				this._ArgumentList = null;
				this._Argument = value;

			}
		}
		
		public static implicit operator ParserNode(Token<PsiTokenType> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Expression value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Module value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Assertion value) => new ParserNode(value);
		
		public static implicit operator ParserNode(CompoundName value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Declaration value) => new ParserNode(value);
		
		public static implicit operator ParserNode(bool? value) => new ParserNode(value);
		
		public static implicit operator ParserNode(PsiOperator? value) => new ParserNode(value);
		
		public static implicit operator ParserNode(string value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Expression> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(List<Argument> value) => new ParserNode(value);
		
		public static implicit operator ParserNode(Argument value) => new ParserNode(value);

		
		public override string ToString()
		{
			if(this._Token != null)
				return "Node(Token): " + _Token.ToString();
			if(this._Expression != null)
				return "Node(Expression): " + _Expression.ToString();
			if(this._Module != null)
				return "Node(Module): " + _Module.ToString();
			if(this._Assertion != null)
				return "Node(Assertion): " + _Assertion.ToString();
			if(this._Name != null)
				return "Node(Name): " + _Name.ToString();
			if(this._Declaration != null)
				return "Node(Declaration): " + _Declaration.ToString();
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

			return "<???>";
		}
	}
}

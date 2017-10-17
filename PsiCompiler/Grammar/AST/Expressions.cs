using System;
using CompilerKit;
using System.Collections.Generic;
using System.Linq;

namespace PsiCompiler.Grammar
{
	public abstract class Expression
	{
		
	}

	public sealed class UnaryOperation : Expression
	{
		public UnaryOperation(PsiOperator @operator, Expression operand)
		{
			this.Operator = @operator;
			this.Operand = operand.NotNull();
		}
		
		public PsiOperator Operator { get; }
		public Expression Operand { get; }

		public override string ToString() => Converter.ToString(Operator) + " " + Operand;
    }

    public sealed class DotExpression : Expression
    {
        public DotExpression(Expression operand, string field)
        {
            this.Object = operand.NotNull();
            this.FieldName = field.NotNull();
        }

        public string FieldName { get; }
        public Expression Object { get; }

        public override string ToString() => "(" + Object + "." + FieldName + ")";
    }

    public sealed class MetaExpression : Expression
    {
        public MetaExpression(Expression operand, string field)
        {
            this.Object = operand.NotNull();
            this.FieldName = field.NotNull();
        }

        public string FieldName { get; }
        public Expression Object { get; }

        public override string ToString() => "(" + Object + "'" + FieldName + ")";
    }

    public sealed class BinaryOperation : Expression
	{
		public BinaryOperation(PsiOperator @operator, Expression lhs, Expression rhs)
		{
			this.Operator = @operator;
			this.LeftHandSide = lhs.NotNull();
			this.RightHandSide = rhs.NotNull();
		}
		
		public PsiOperator Operator { get; }
		public Expression LeftHandSide { get; }
		public Expression RightHandSide { get; }

		public override string ToString() => "(" + LeftHandSide + " " + Converter.ToString(Operator) + " " + RightHandSide + ")";
	}

	public sealed class NumberLiteral : Expression
	{
		public NumberLiteral(string value)
		{
			this.Value = value.NotNull();
		}
		
		public string Value { get; }

		public override string ToString() => Value;
	}

	public sealed class StringLiteral : Expression
	{
		public StringLiteral(string value)
		{
			this.Text = value.NotNull();
		}
		
		public string Text { get; }

		public override string ToString() => "\"" + Text + "\"";
    }

    public sealed class EnumLiteral : Expression
    {
        public EnumLiteral(string value)
        {
            this.Name = value.NotNull();
        }

        public string Name { get; }

        public override string ToString() => ":" + Name;
    }

    public sealed class VariableReference : Expression
	{
		public VariableReference(string value)
		{
			this.Variable = value.NotNull();
		}
		
		public string Variable { get; }

		public override string ToString() => Variable;
	}

    public sealed class ArrayIndexingExpression : Expression
    {
        public ArrayIndexingExpression(Expression value, IEnumerable<Expression> indices)
        {
            this.Value = value.NotNull();
            this.Indices = indices.ToArray();
        }
           
        public Expression Value { get; }

        public IReadOnlyList<Expression> Indices { get; }

        public override string ToString() => string.Format("{0}[{1}]", Value, string.Join(", ", Indices));
    }

    public sealed class FunctionCallExpression : Expression
    {
        public FunctionCallExpression(Expression value, IEnumerable<Argument> args)
        {
            this.Value = value.NotNull();
            this.Arguments = args.ToArray();
        }

        public Expression Value { get; }

        public IReadOnlyList<Argument> Arguments { get; }

        public override string ToString() => string.Format("{0}({1})", Value, string.Join(", ", Arguments));
    }

    public abstract class Argument
    {
        protected Argument(Expression value)
        {
            this.Value = value.NotNull();
        }

        public Expression Value { get; }
    }

    public sealed class PositionalArgument : Argument
    {
        public PositionalArgument(Expression value) : base(value)
        {

        }

        public override string ToString() => this.Value.ToString();
    }

    public sealed class NamedArgument : Argument
    {
        public NamedArgument(string name, Expression value) : base(value)
         {
            this.Name = name.NotNull();
        }

        public string Name { get; }

        public override string ToString() => string.Format("{0}: {1}", this.Name, this.Value);
    }

    public sealed class FunctionTypeLiteral : Expression
    {
        public FunctionTypeLiteral(IEnumerable<Parameter> parameters, Expression returnType)
        {
            this.Parameters = parameters.ToArray();
            this.ReturnType = returnType;
        }

        public IReadOnlyList<Parameter> Parameters { get; }

        public Expression ReturnType { get; }

        public override string ToString() => string.Format("fn({0}) -> {1}", string.Join(", ", Parameters), ReturnType);
    }

    public sealed class Parameter
    {
        public Parameter(ParameterPrefix prefix, string name, Expression type, Expression value)
        {
            this.Prefix = prefix;
            this.Name = name.NotNull();
            this.Type = type;
            this.Value = value;
        }

        public string Name { get; }

        public Expression Type { get; }

        public Expression Value { get; }

        public ParameterPrefix Prefix { get;  }

        public override string ToString() => string.Format("{0} {1} : {2} = {3}", Prefix, Name, Type, Value);
    }

    [Flags]
    public enum ParameterPrefix
    {
        None = 0,
        In = 1,
        Out = 2,
        InOut = In | Out, // Mask together
        This = 4,

    }

    public sealed class FunctionLiteral : Expression
    {
        public FunctionLiteral(FunctionTypeLiteral type, Statement body)
        {
            this.Type = type;
            this.Body = body;
        }

        public FunctionTypeLiteral Type { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("{0} => {1}", Type, Body);
    }
}

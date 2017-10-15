using System;
using CompilerKit;

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

	public sealed class VariableReference : Expression
	{
		public VariableReference(string value)
		{
			this.Variable = value.NotNull();
		}
		
		public string Variable { get; }

		public override string ToString() => Variable;
	}
}

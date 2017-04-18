using System;
using System.Numerics;
namespace midend
{
	/// <summary>
	/// A literal expression that provides a type value.
	/// </summary>
	public sealed class TypeExpression : Expression
	{
		private readonly CType value;

		public TypeExpression(CType value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			this.value = value;
		}
		
		public override CValue Evaluate(EvaluationContext context) => new CValue(CType.Type, this.value);
		
		public CType Value => this.value;

		public override CType Type => CType.Type;
	}
	
	/// <summary>
	/// A literal expression that provides a string value.
	/// </summary>
	public sealed class StringExpression : Expression
	{
		private readonly string value;

		public StringExpression(string value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			this.value = value;
		}
		
		public override CValue Evaluate(EvaluationContext context) => new CValue(CType.Type, this.value);
		
		public string Value => this.value;

		public override CType Type => CType.Type;
	}
	
	/// <summary>
	/// A literal expression that provides an integer value.
	/// </summary>
	public sealed class IntegerExpression : Expression
	{
		private readonly BigInteger value;

		public IntegerExpression(BigInteger value)
		{
			this.value = value;
		}
		
		public override CValue Evaluate(EvaluationContext context) => new CValue(CType.Type, this.value);
		
		public BigInteger Value => this.value;

		public override CType Type => CType.Type;
	}
}

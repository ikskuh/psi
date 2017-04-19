using System;
using System.Numerics;
namespace midend
{
	public class LiteralExpression : Expression
	{
		private readonly CType type;
		private readonly object value;
		
		public LiteralExpression(CType type, object value)
		{
			if(type == null) throw new ArgumentNullException(nameof(type));
			if(value == null) throw new ArgumentNullException(nameof(value));
			this.type = type;
			this.value = value;
		}
		
		public override bool IsConstant => true;
		
		public override CValue Evaluate(EvaluationContext context) => new CValue(this.type, this.value);

		public object Value => this.value;

		public override CType Type => CTypes.Type;
	}

	/// <summary>
	/// A literal expression that provides a typed value.
	/// </summary>
	public class LiteralExpression<T> : LiteralExpression
	{
		public LiteralExpression(CType type, T value) : base(type, value)
		{
			if(type.IsAllowedValue(value) == false)
				throw new ArgumentOutOfRangeException(nameof(value), $"'{value}' is not an allowed value for '{type}'.");
		}
		
		public new T Value => (T)base.Value;
	}

	/// <summary>
	/// A literal expression that provides a type value.
	/// </summary>
	public sealed class TypeExpression : LiteralExpression<CType>
	{
		public TypeExpression(CType value) : base(CTypes.Type, value)
		{
		}
	}
	
	/// <summary>
	/// A literal expression that provides a string value.
	/// </summary>
	public sealed class StringExpression : LiteralExpression<string>
	{
		public StringExpression(string value) : base(CTypes.String, value)
		{
		}
	}
	
	/// <summary>
	/// A literal expression that provides an integer value.
	/// </summary>
	public sealed class IntegerExpression : LiteralExpression<BigInteger>
	{
		public IntegerExpression(BigInteger value) : base(new IntegerType(value, value, IntegerOverflowBehaviour.Failing), value)
		{
		}
	}
}

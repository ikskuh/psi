using System;
using System.Numerics;
namespace midend
{
	/// <summary>
	/// A compile time value that can be used to store literals and computed values.
	/// </summary>
	public sealed class CValue
	{
		private readonly CType type;
		private readonly object value;

		public CValue(CType type, object value)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			this.type = type;
			this.value = value;
			if(type.IsAllowedValue(value) == false)
				throw new ArgumentOutOfRangeException(nameof(value), "value is not a fitting value for type!");
		}
		
		public T Get<T>() => (T)this.value;
		
		public CType Type => this.type;
		
		public object Value => this.value;
		
		public override string ToString() => $"{this.Value}";
		
		#region Explicit Casts
		
		public static explicit operator CValue(bool value) => new CValue(CTypes.Boolean, value);
		
		public static explicit operator CValue(string value) => new CValue(CTypes.String, value);
		
		public static explicit operator CValue(BigInteger value) => new CValue(CTypes.Integer, value);
		
		public static explicit operator CValue(char value) => new CValue(CTypes.Char, value);
		
		#endregion
	}
}
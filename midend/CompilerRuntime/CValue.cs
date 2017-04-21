using System;
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
		}
		
		public CType Type => this.type;
		
		public object Value => this.value;
	}
}
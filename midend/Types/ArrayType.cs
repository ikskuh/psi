using System;
namespace midend
{
	public sealed class ArrayType : CType
	{
		private readonly CType elementType;

		public ArrayType(CType elementType)
		{
			if(elementType == null) throw new ArgumentNullException(nameof(elementType));
			this.elementType = elementType;
		}
		
		public override bool IsAllowedValue(object value)
		{
			return base.IsAllowedValue(value);
		}
		
		public CType ElementType => this.elementType;
		
		public override string ToString() => $"array<{ElementType}>";
	}
}

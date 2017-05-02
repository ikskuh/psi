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
			var array = value as CArray;
			if(array == null) return false;
			return (array.Type == this);
		}
		
		public override Indexer GetIndexer(params CType[] types)
		{
			if(types.Length == 1 && types[0] is IntegerType)
			{
				return new ArrayIndexer(this);
			}
			return base.GetIndexer(types);
		}
		
		public CType ElementType => this.elementType;
		
		public override string ToString() => $"array<{ElementType}>";
	}
}

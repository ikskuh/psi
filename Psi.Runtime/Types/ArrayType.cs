using System;
namespace Psi.Runtime
{
	public sealed class ArrayType : Type
	{
		public ArrayType(Type elementType) : this(elementType, 1)
		{

		}

		public ArrayType(Type elementType, int dims)
		{
			if (elementType == null) throw new ArgumentNullException(nameof(elementType));
			if (dims < 1) throw new ArgumentOutOfRangeException(nameof(dims));
			this.ElementType = elementType;
			this.Dimensions = dims;
		}

		public override bool Equals(Type other)
		{
			var arr = other as ArrayType;
			return object.Equals(this.ElementType, arr?.ElementType)
				&& object.Equals(this.Dimensions, arr?.Dimensions);
		}

		public override int GetHashCode() => (0x04 << 24) | (0xFFFFFF & ((this.ElementType.GetHashCode() >> 8) ^ this.Dimensions.GetHashCode()));

		public Type ElementType { get; }

		public int Dimensions { get; }
		
		public override string ToString() => $"array<{ElementType},{Dimensions}>";
	}
}

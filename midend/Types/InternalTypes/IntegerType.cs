using System;
using System.Numerics;
namespace midend
{
	public sealed class IntegerType
	{
		public static readonly IntegerType UInt8 = new IntegerType(byte.MinValue, byte.MaxValue, IntegerOverflowBehaviour.Wrapping);
		public static readonly IntegerType UInt16 = new IntegerType(ushort.MinValue, ushort.MaxValue, IntegerOverflowBehaviour.Wrapping);
		public static readonly IntegerType UInt32 = new IntegerType(uint.MinValue, uint.MaxValue, IntegerOverflowBehaviour.Wrapping);
		public static readonly IntegerType UInt64 = new IntegerType(ulong.MinValue, ulong.MaxValue, IntegerOverflowBehaviour.Wrapping);
		
		public static readonly IntegerType Int8 = new IntegerType(sbyte.MinValue, sbyte.MaxValue, IntegerOverflowBehaviour.Wrapping);
		public static readonly IntegerType Int16 = new IntegerType(short.MinValue, short.MaxValue, IntegerOverflowBehaviour.Wrapping);
		public static readonly IntegerType Int32 = new IntegerType(int.MinValue, int.MaxValue, IntegerOverflowBehaviour.Wrapping);
		public static readonly IntegerType Int64 = new IntegerType(long.MinValue, long.MaxValue, IntegerOverflowBehaviour.Wrapping);
	
		private readonly BigInteger minimum, maximum;
		private readonly IntegerOverflowBehaviour behaviour;

		public IntegerType(BigInteger min, BigInteger max, IntegerOverflowBehaviour behaviour)
		{
			if (min >= max)
				throw new ArgumentOutOfRangeException("min must be less than max.", (Exception)null);
			this.minimum = min;
			this.maximum = max;
			this.behaviour = behaviour;
		}

		public BigInteger Minimum => this.minimum;

		public BigInteger Maximum => this.maximum;

		public IntegerOverflowBehaviour Behaviour => this.behaviour;

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(this, obj))
				return true;
			var itype = obj as IntegerType;
			if (itype == null)
				return false;
			return (itype.minimum == this.minimum)
				&& (itype.maximum == this.maximum)
				&& (itype.behaviour == this.behaviour);
		}

		public override int GetHashCode() =>
			this.minimum.GetHashCode() ^
			this.maximum.GetHashCode() ^
			this.behaviour.GetHashCode();

		public override string ToString() => string.Format(
			"int<{0},{1},{2}>",
			this.minimum,
			this.maximum,
			this.behaviour.ToString().ToLower());
	}

	public enum IntegerOverflowBehaviour
	{
		Failing,
		Clamping,
		Wrapping,
	}
}

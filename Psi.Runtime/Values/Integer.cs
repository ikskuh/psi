using System;
namespace Psi.Runtime
{
	public sealed class Integer : Value, IPrimitiveValue<int>
	{
		private readonly int value;

		public Integer(int value) : base(IntegerType.Instance)
		{
			this.value = value;
		}

		public static implicit operator int(Integer i) => i.value;

		public static implicit operator Integer(int i) => new Integer(i);

		public int Value => this.value;

		public override string ToString() => value.ToString();
	}
}

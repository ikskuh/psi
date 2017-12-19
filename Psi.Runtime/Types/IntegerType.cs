using System;
namespace Psi.Runtime
{
	public sealed class IntegerType : Type
	{
		public static Type Instance { get; } = new IntegerType();

		private IntegerType() { }

		public override bool Equals(Type other) => other is IntegerType;

		public override int GetHashCode() => (0x02 << 24);
		
		public override string ToString() => "int";
	}
}

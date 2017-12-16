using System;
namespace Psi.Runtime
{
	public sealed class RealType : Type
	{
		public static Type Instance { get; } = new RealType();

		private RealType() { }

		public override bool Equals(Type other) => other is RealType;

		public override int GetHashCode() => (0x08 << 24);
	}
}

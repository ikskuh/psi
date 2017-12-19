using System;
namespace Psi.Runtime
{
	public sealed class VoidType : Type
	{
		public static Type Instance { get; } = new VoidType();

		private VoidType() { }

		public override bool Equals(Type other) => other is VoidType;

		public override int GetHashCode() => (0x06 << 24);
		
		public override string ToString() => "void";
	}
}

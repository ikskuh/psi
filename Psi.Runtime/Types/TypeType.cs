using System;
namespace Psi.Runtime
{
	public sealed class TypeType : Type
	{
		public static Type Instance { get; } = new TypeType();

		private TypeType() { }

		public override bool Equals(Type other) => other is TypeType;

		public override int GetHashCode() => (0x07 << 24);
		
		public override string ToString() => "type";
	}
}

using System;
namespace Psi.Runtime
{
	public sealed class CharacterType : Type
	{
		public static Type Instance { get; } = new CharacterType();

		private CharacterType() { }

		public override bool Equals(Type other) => other is CharacterType;

		public override int GetHashCode() => (0x03 << 24);
	}
}

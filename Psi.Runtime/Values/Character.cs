using System;
namespace Psi.Runtime
{

	public sealed class Character : Value, IPrimitiveValue<int>
	{
		private readonly int value;

		public Character(char value) : this(char.ConvertToUtf32(value.ToString(), 0))
		{

		}

		public Character(string value) : this(char.ConvertToUtf32(value, 0))
		{

		}

		public Character(int value) : base(CharacterType.Instance)
		{
			this.value = value;
		}

		public static implicit operator string(Character b) => char.ConvertFromUtf32(b.value);

		public static implicit operator Character(string b) => new Character(char.ConvertToUtf32(b, 0));

		public int Value => this.value;

		public override string ToString() => value.ToString();
	}
}

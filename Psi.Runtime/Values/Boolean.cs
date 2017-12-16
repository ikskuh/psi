using System;
namespace Psi.Runtime
{
	public sealed class Boolean : Value, IPrimitiveValue<bool>
	{
		private readonly bool value;

		public Boolean(bool value) : base(BooleanType.Instance)
		{
			this.value = value;
		}

		public static implicit operator bool(Boolean b) => b.value;

		public static implicit operator Boolean(bool b) => new Boolean(b);

		public bool Value => this.value;

		public override string ToString() => value.ToString();
	}
}

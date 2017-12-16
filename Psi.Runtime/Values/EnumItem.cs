using System;
using System.Linq;
namespace Psi.Runtime
{
	public sealed class EnumItem : Value
	{
		private readonly string value;

		public EnumItem(EnumType type, string value) : base(type)
		{
			if(value == null) throw new ArgumentNullException(nameof(value));
			if(type.Items.Contains(value) == false)
				throw new ArgumentOutOfRangeException(nameof(value));
			this.value = value;
		}

		public static implicit operator string(EnumItem i) => i.value;

		public string Value => this.value;

		public override string ToString() => value.ToString();
	}
}

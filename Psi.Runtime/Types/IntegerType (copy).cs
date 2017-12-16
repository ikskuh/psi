using System;
using System.Collections.Generic;
using System.Linq;
namespace Psi.Runtime
{
	public sealed class EnumType : Type
	{
		private readonly HashSet<string> items;

		public EnumType(params string[] items)
		{
			if (items == null) throw new ArgumentNullException(nameof(items));
			if (items.Length < 1) throw new ArgumentOutOfRangeException(nameof(items));
			this.items = new HashSet<string>(items);
		}

		public IReadOnlyCollection<string> Items => this.items;

		public override bool Equals(Type other)
		{
			var @enum = other as EnumType;
			if (@enum == null)
				return false;
			return this.items.SetEquals(@enum.items);
		}

		public override int GetHashCode() => (0x02 << 24) | (0xFFFFFF & this.items.Select(i => i.GetHashCode()).Aggregate(0, (a, b) => a ^ b));
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace Psi.Runtime
{
	// Type prototype
	public sealed class BooleanType : Type
	{
		public static Type Instance { get; } = new BooleanType();

		private BooleanType() { }

		public override bool Equals(Type other) => other is BooleanType;

		public override int GetHashCode() => (0x01 << 24);
	}
}

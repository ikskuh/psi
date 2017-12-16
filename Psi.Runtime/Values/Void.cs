using System;
namespace Psi.Runtime
{
	public sealed class Void : Value
	{
		public Void() : base(VoidType.Instance) { }

		public override string ToString() => "void";
	}
}

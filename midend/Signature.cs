using System;
using System.Diagnostics.Contracts;

namespace midend
{
	public sealed class Signature : IEquatable<Signature>
	{
		public Signature(SymbolName name, CType type)
		{
			Contract.Requires(type != null);
			this.Name = name;
			this.Type = type;
		}
	
		public bool Equals(Signature other)
		{
			if (other == null)
				return false;
			return (this.Name.Equals(other.Name)) 
				&& (NamedType.Equals(this.Type, other.Type));
		}

		public override bool Equals(object obj) => this.Equals(obj as Signature);

		public override int GetHashCode() => this.Name.GetHashCode() ^ this.Type.GetHashCode();
		
		public override string ToString() => string.Format("{0} : {1}", this.Name, this.Type);

		public SymbolName Name { get; private set; }

		public CType Type { get; private set; }

	}
}
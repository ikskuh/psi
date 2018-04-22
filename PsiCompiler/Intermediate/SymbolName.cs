using System;
namespace Psi.Compiler
{
	public sealed class SymbolName : IEquatable<SymbolName>
	{
		public SymbolName(PsiType type, string name)
		{
			this.Type = type.NotNull();
			this.Name = name.NotNull();
		}
	
		public PsiType Type { get; }
	
		public string Name { get; }

		public bool Equals(SymbolName other)
		{
			if(other == null)
				return false;
			return object.Equals(this.Name, other.Name)
				&& object.Equals(this.Type, other.Type);
		}
		
		public override bool Equals(object obj) => this.Equals(obj as SymbolName);
		
		public override int GetHashCode() => this.Type.GetHashCode() ^ this.Name.GetHashCode();
		
		public override string ToString() => $"{Name} : {Type}";
	}
}
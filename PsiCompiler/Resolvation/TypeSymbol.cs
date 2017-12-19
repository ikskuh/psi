namespace Psi.Compiler.Resolvation
{
	using Psi.Runtime;
	
	public sealed class TypeSymbol: INamedObject<string>
	{
		public TypeSymbol(string name, Psi.Runtime.Type value, Scope<string,TypeSymbol> scope)
		{
			this.Name = name;
			this.Scope = scope;
			this.Type = value;
		}
		
		public string Name { get; }
		
		public Scope<string,TypeSymbol> Scope { get; }
		
		public bool IsExported { get; set; }
		
		public Psi.Runtime.Type Type { get; }
		
		public override string ToString() => $"{Name} = {Type}";
	}
}
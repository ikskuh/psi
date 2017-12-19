namespace Psi.Compiler.Resolvation
{
	using Psi.Runtime;
	
	public sealed class Symbol : INamedObject<SymbolName>
	{
		public Symbol(SymbolName name, Scope<SymbolName,Symbol> scope)
		{
			this.Name = name;
			this.Scope = scope;
		}
		
		public SymbolName Name { get; }
		
		public Scope<SymbolName,Symbol> Scope { get; }
		
		public bool IsConst { get; set; }
		
		public bool IsExported { get; set; }
		
		public Psi.Runtime.Type Type => this.Name.Type;
		
		public Value KnownValue { get; set; }
		
		public bool HasKnownValue => (this.KnownValue != null);
	}
}
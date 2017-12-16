namespace Psi.Compiler
{
	using Psi.Runtime;
	
	public sealed class Symbol
	{	
		public Symbol(SymbolName name, Scope scope)
		{
			this.Name = name;
			this.Scope = scope;
		}
		
		public SymbolName Name { get; }
		
		public Scope Scope { get; }
		
		public bool IsConst { get; set; }
		
		public bool IsExported { get; set; }
		
		public Psi.Runtime.Type Type => this.Name.Type;
		
		public Value KnownValue { get; set; }
	}
}
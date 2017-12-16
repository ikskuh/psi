using System;
using Psi.Runtime;

namespace Psi.Compiler.Resolvation
{
	public sealed class SymbolReference : IResolvationResult
	{
		public SymbolReference(Symbol symbol)
		{
			if(symbol == null) throw new ArgumentNullException(nameof(symbol));
			this.Symbol = symbol;
		}
		
		public Symbol Symbol { get; }
	
		public Runtime.Type Type
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}

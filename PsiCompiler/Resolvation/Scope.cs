using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Resolvation
{
	public class Scope : IReadOnlyCollection<Symbol>
	{
		private readonly Scope parent;
		private readonly Dictionary<SymbolName,Symbol> symbols = new Dictionary<SymbolName, Symbol>();
	
		public Scope()
		{
			this.parent = null;
		}
		
		private Scope(Scope parent)
		{
			this.parent = parent;
		}
		
		public Scope CreateChild()
		{
			return new Scope(this);
		}
		
		public Symbol Add(SymbolName name)
		{
			var sym = new Symbol(name, this);
			this.symbols.Add(name, sym);
			return sym;
		}

		public Symbol this[SymbolName key]
		{
			get
			{
				Symbol sym;
				if(this.TryGetValue(key, out sym))
					return sym;
				return null;
			}
		}

		// Use the enumerator function for counting unique symbols with shadowing
		public int Count => this.Count();

		public bool ContainsKey(SymbolName key)
		{
			return symbols.ContainsKey(key);
		}

		public IEnumerator<Symbol> GetEnumerator()
		{
			var result = (IEnumerable<Symbol>)this.symbols.Values;
			if(this.parent != null)
				result = result.Concat(this.parent.Where(sym => !this.symbols.ContainsKey(sym.Name)));
			return result.GetEnumerator();
		}

		public bool TryGetValue(SymbolName key, out Symbol value)
		{
			if(symbols.TryGetValue(key, out value))
				return true;
			if(this.parent != null && this.parent.TryGetValue(key, out value))
				return true;
			value = default(Symbol);
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
namespace Psi.Compiler
{
	public class Scope : IReadOnlyDictionary<SymbolName, Symbol>
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

		public int Count
		{
			get
			{
				return symbols.Count;
			}
		}

		public IEnumerable<SymbolName> Keys
		{
			get
			{
				return ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).Keys;
			}
		}

		public IEnumerable<Symbol> Values
		{
			get
			{
				return ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).Values;
			}
		}

		public bool ContainsKey(SymbolName key)
		{
			return symbols.ContainsKey(key);
		}

		public IEnumerator<KeyValuePair<SymbolName, Symbol>> GetEnumerator()
		{
			return ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).GetEnumerator();
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

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).GetEnumerator();
		}
	}
}

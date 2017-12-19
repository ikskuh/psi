using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Resolvation
{
	public abstract class Scope<TName,TSym> : IReadOnlyCollection<TSym> where TSym : class, INamedObject<TName>
	{
		private readonly Scope<TName,TSym> parent;
		protected readonly Dictionary<TName,TSym> symbols = new Dictionary<TName, TSym>();
	
		protected Scope()
		{
			this.parent = null;
		}
		
		protected Scope(Scope<TName,TSym> parent)
		{
			this.parent = parent;
		}

		public TSym this[TName key]
		{
			get
			{
				TSym sym;
				if(this.TryGetValue(key, out sym))
					return sym;
				return null;
			}
		}

		// Use the enumerator function for counting unique symbols with shadowing
		public int Count => this.Count();

		public bool ContainsKey(TName key)
		{
			var success = symbols.ContainsKey(key);
			if(!success && parent != null)
				success = this.parent.ContainsKey(key);
			return success;
		}

		public IEnumerator<TSym> GetEnumerator()
		{
			var result = (IEnumerable<TSym>)this.symbols.Values;
			if(this.parent != null)
				result = result.Concat(this.parent.Where(sym => !this.symbols.ContainsKey(sym.Name)));
			return result.GetEnumerator();
		}

		public bool TryGetValue(TName key, out TSym value)
		{
			if(symbols.TryGetValue(key, out value))
				return true;
			if(this.parent != null && this.parent.TryGetValue(key, out value))
				return true;
			value = default(TSym);
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	}

	public interface INamedObject<TName>
	{
		TName Name { get; }
	}

	public sealed class VariableScope : Scope<SymbolName,Symbol>
	{
		public VariableScope() {}
		
		private VariableScope(VariableScope parent) : base(parent) { }
		
		public VariableScope CreateChild() => new VariableScope(this);
		
		public Symbol Add(SymbolName name)
		{
			var sym = new Symbol(name, this);
			this.symbols.Add(name, sym);
			return sym;
		}
	}
	
	public sealed class TypeScope : Scope<string,TypeSymbol>
	{
		public TypeScope() {}
		
		private TypeScope(TypeScope parent) : base(parent) { }
		
		public TypeScope CreateChild() => new TypeScope(this);
	
		public TypeSymbol Add(string name, Psi.Runtime.Type value)
		{
			var sym = new TypeSymbol(name, value, this);
			this.symbols.Add(name, sym);
			return sym;
		}
	}
}

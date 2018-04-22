using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Psi.Compiler
{
	public class Scope
	{
		public Scope() : this(null, true)
		{
			
		}
	
		public Scope(Scope parent ) : this(parent.NotNull(), true)
		{
			
		}
		
		private Scope(Scope parent, bool dummy)
		{
			this.Modules = new ScopedDictionary<string,IntermediateModule>(parent?.Modules);
			this.Types = new ScopedDictionary<string,PsiType>(parent?.Types);
			this.Symbols = new ScopedDictionary<SymbolName,Symbol>(parent?.Symbols);
		}
	
		public IDictionary<string, IntermediateModule> Modules { get; }
		
		public IDictionary<string, PsiType> Types { get; }
		
		public IDictionary<SymbolName, Symbol> Symbols { get; }
		
		public Scope Parent { get; }
	}

	public class ScopedDictionary<TK, TV> : IDictionary<TK, TV>
	{
		private readonly Dictionary<TK,TV> locals = new Dictionary<TK, TV>();

		private readonly IDictionary<TK, TV> parent;
		
		public ScopedDictionary(IDictionary<TK,TV> parent)
		{
			this.parent = parent ?? new Dictionary<TK,TV>();
		}
	
		public TV this[TK key]
		{
			get
			{
				TV val;
				if(this.TryGetValue(key, out val))
					return val;
				else
					return default(TV);
			}
			set
			{
				this.locals[key] = value;
			}
		}

		public int Count => this.Count();

		public bool IsReadOnly => false;

		public ICollection<TK> Keys => this.Select(kv => kv.Key).ToList();

		public ICollection<TV> Values => this.Select(kv => kv.Value).ToList();

		public void Add(KeyValuePair<TK, TV> item)
		{
			((IDictionary<TK,TV>)this.locals).Add(item);
		}

		public void Add(TK key, TV value)
		{
			this.locals.Add(key, value);
		}

		public void Clear()
		{
			this.locals.Clear();
		}

		public bool Contains(KeyValuePair<TK, TV> item) => Enumerable.Contains(this, item);

		public bool ContainsKey(TK key) => Enumerable.Any(this, k => object.Equals(k.Key, key));

		public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex)
		{
			this.ToList().CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator() => this.locals.Concat(this.parent.Where(p => !this.locals.ContainsKey(p.Key))).GetEnumerator();

		public bool Remove(KeyValuePair<TK, TV> item) => ((IDictionary<TK,TV>)this.locals).Remove(item);

		public bool Remove(TK key) => this.locals.Remove(key);

		public bool TryGetValue(TK key, out TV value)
		{
			if(this.locals.TryGetValue(key, out value))
				return true;
			if(this.parent.TryGetValue(key, out value))
				return true;
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	}
}
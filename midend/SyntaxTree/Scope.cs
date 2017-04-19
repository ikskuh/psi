using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public class Scope : IReadOnlyScope, IEnumerable<Signature>
	{
		private readonly Scope parent;
		private readonly Dictionary<Signature, Symbol> symbols = new Dictionary<Signature, Symbol>();

		public Scope(Scope parent = null)
		{
			this.parent = parent;
		}

		public void AddSymbol(Symbol sym)
		{
			if (sym == null) throw new ArgumentNullException(nameof(sym));
			this.symbols.Add(sym.Name, sym);
		}

		public void AddSymbol(string name, Module value)
		{
			this.AddSymbol(new Symbol(name, CTypes.Module)
			{
				IsConst = true,
				IsExported = true,
				InitialValue = Expression.Constant(value),
			});
		}

		public void AddSymbol(string name, CType type)
		{
			this.AddSymbol(new Symbol(name, CTypes.Type)
			{
				IsConst = true,
				IsExported = true,
				InitialValue = Expression.Constant(type),
			});
		}

		/// <summary>
		/// Gets a symbol from this scope.
		/// </summary>
		/// <param name="name">Name.</param>
		public Symbol this[Signature name]
		{
			get
			{
				if (name == null) throw new ArgumentNullException(nameof(name));
				Symbol sym;
				if (this.symbols.TryGetValue(name, out sym))
					return sym;
				if (this.parent != null)
					return this.parent[name];
				return null;
			}
		}

		/// <summary>
		/// Gets an enumeration of all locally defined symbols.
		/// </summary>
		/// <value>The locals.</value>
		public IEnumerable<Signature> Locals => new LocalEnumeration(this);

		#region IEnumerable<Signature>

		public IEnumerator<Signature> GetEnumerator()
		{
			if (this.parent == null)
				return this.symbols.Keys.GetEnumerator();
			else
				return this.symbols.Keys.Concat(this.parent).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		#endregion

		private sealed class LocalEnumeration : IEnumerable<Signature>
		{
			private readonly Scope scope;

			public LocalEnumeration(Scope scope)
			{
				if (scope == null) throw new ArgumentNullException(nameof(scope));
				this.scope = scope;
			}

			public IEnumerator<Signature> GetEnumerator() => this.scope.symbols.Keys.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
		}
	}
}

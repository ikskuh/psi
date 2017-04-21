using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using midend.AbstractSyntaxTree;

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
		
		public void AddSymbol(string name, Function value)
		{
			this.AddSymbol(new Symbol(new Signature(name, value.Type))
			{
				IsConst = true,
				IsExported = true,
				InitialValue = Expression.Constant(value),
			});
		}
		
		public void AddSymbol(Operator op, Function value)
		{
			this.AddSymbol(new Symbol(new Signature(op, value.Type))
			{
				IsConst = true,
				IsExported = true,
				InitialValue = Expression.Constant(value),
			});
		}

		/// <summary>
		/// Gets all signatures with a given name.
		/// </summary>
		/// <returns>The all.</returns>
		/// <param name="symbol">Symbol.</param>
		public Signature[] GetAll(string symbol) => this.Where(sig => (sig.Name == symbol)).ToArray();

		/// <summary>
		/// Gets all fitting signatures.
		/// </summary>
		/// <returns>The all.</returns>
		/// <param name="sig">Sig.</param>
		public Signature[] GetAll(Operator op) => this.Where(sig => sig.IsOperatorSignature && sig.Operator == op).ToArray();

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

		public Symbol this[string name, CType type] => this[new Signature(name, type)];

		public Symbol this[Operator op, CType type] => this[new Signature(op, type)];

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

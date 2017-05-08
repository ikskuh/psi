using System.Collections.Generic;
using System.Linq;
namespace midend
{
	using System;

	public sealed class ResolvationContext
	{
		private readonly Scope scope;
		private List<CType> wantedTypes = new List<CType>();

		public ResolvationContext(Scope scope)
		{
			if (scope == null) throw new ArgumentNullException(nameof(scope));
			this.scope = scope;
		}

		public Symbol GetSymbol(string name)
		{
			var symbols = this.scope.GetAll(name);
			// No symbol found
			if (symbols.Length == 0)
				throw new InvalidOperationException("Symbol not found!");
			
			// Symbol unique
			if (symbols.Length == 1)
				return this.scope[symbols[0]];

			symbols = symbols
				.Where(sym => this.wantedTypes.Contains(sym.Type))
				.ToArray();
			
			// No matching symbol
			if (symbols.Length == 0)
				return null;

			// Singular matching symol
			if (symbols.Length == 1)
				return this.scope[symbols[0]];

			// Ambigious symbol
			throw new InvalidOperationException($"Symbol {name} ambiguous!");
		}

		private ResolvationContext Derive()
		{
			var next = new ResolvationContext(this.scope);
			next.wantedTypes.AddRange(this.wantedTypes);
			// COPY EVERYTHING HERE
			return next;
		}

		public ResolvationContext WantsType(params CType[] types)
		{
			if (types == null) throw new ArgumentNullException(nameof(types));
			var next = this.Derive();
			next.wantedTypes = new List<CType>(types);
			return next;
		}

		public Scope Scope => this.scope;

		public override string ToString() => string.Format(
			"{0}",
			string.Join(", ", this.wantedTypes));

	}
}
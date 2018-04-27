using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public class SymbolCollection : IReadOnlyDictionary<Signature, Symbol>, IScope
    {
        private readonly Dictionary<Signature, Symbol> symbols = new Dictionary<Signature, Symbol>();

        public SymbolCollection()
        {
        }

        public void Add(Symbol sym)
        {
            if (sym == null)
                throw new ArgumentNullException(nameof(sym));
            if (this.symbols.ContainsKey(sym.Name))
                throw new InvalidOperationException($"A symbol {sym.Name} already exists!");
            this.symbols.Add(sym.Name, sym);
        }

        public Symbol this[Signature key] => symbols[key];

        public IEnumerable<Signature> Keys => ((IReadOnlyDictionary<Signature, Symbol>)symbols).Keys;

        public IEnumerable<Symbol> Values => ((IReadOnlyDictionary<Signature, Symbol>)symbols).Values;

        public int Count => symbols.Count;

        public bool ContainsKey(Signature key)
        {
            return symbols.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<Signature, Symbol>> GetEnumerator()
        {
            return ((IReadOnlyDictionary<Signature, Symbol>)symbols).GetEnumerator();
        }

        public bool TryGetValue(Signature key, out Symbol value)
        {
            return symbols.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyDictionary<Signature, Symbol>)symbols).GetEnumerator();
        }

        public bool HasSymbol(Signature name) => this.symbols.ContainsKey(name);

        IEnumerator<Symbol> IEnumerable<Symbol>.GetEnumerator() => this.symbols.Values.GetEnumerator();
    }
}
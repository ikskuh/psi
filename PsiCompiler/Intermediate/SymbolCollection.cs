using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public class SymbolCollection : IReadOnlyDictionary<SymbolName, Symbol>, IScope
    {
        private readonly Dictionary<SymbolName, Symbol> symbols = new Dictionary<SymbolName, Symbol>();

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

        public Symbol this[SymbolName key] => symbols[key];

        public IEnumerable<SymbolName> Keys => ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).Keys;

        public IEnumerable<Symbol> Values => ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).Values;

        public int Count => symbols.Count;

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
            return symbols.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyDictionary<SymbolName, Symbol>)symbols).GetEnumerator();
        }

        public bool HasSymbol(SymbolName name) => this.symbols.ContainsKey(name);

        IEnumerator<Symbol> IEnumerable<Symbol>.GetEnumerator() => this.symbols.Values.GetEnumerator();
    }
}
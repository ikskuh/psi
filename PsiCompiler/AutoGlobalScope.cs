using System;
using System.Collections;
using System.Collections.Generic;
using Psi.Compiler.Intermediate;

namespace Psi.Compiler
{
    internal class AutoGlobalScope : IScope
    {
        private readonly Dictionary<SymbolName, Symbol> values = new Dictionary<SymbolName, Symbol>();

        public Symbol this[SymbolName name]
        {
            get
            {
                if (!this.values.ContainsKey(name))
                    GenerateSymbolForName(name);

                if (this.values.ContainsKey(name))
                    return this.values[name];
                else
                    return null;
            }
        }

        public IEnumerator<Symbol> GetEnumerator() => new List<Symbol>().GetEnumerator();

        public bool HasSymbol(SymbolName name) => CanGeneratorSymbol(name);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private bool CanGeneratorSymbol(SymbolName name)
        {
            throw new NotImplementedException();
        }

        private void GenerateSymbolForName(SymbolName name)
        {
            throw new NotImplementedException();
        }
    }
}
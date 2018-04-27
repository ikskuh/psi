using System;
using System.Collections;
using System.Collections.Generic;
using Psi.Compiler.Intermediate;

namespace Psi.Compiler
{
    internal class AutoGlobalScope : IScope
    {
        private readonly Dictionary<Signature, Symbol> values = new Dictionary<Signature, Symbol>();

        public Symbol this[Signature name]
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

        public bool HasSymbol(Signature name) => CanGeneratorSymbol(name);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private bool CanGeneratorSymbol(Signature name)
        {
            throw new NotImplementedException();
        }

        private void GenerateSymbolForName(Signature name)
        {
            throw new NotImplementedException();
        }
    }
}
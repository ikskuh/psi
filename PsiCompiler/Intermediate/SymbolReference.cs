using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class SymbolReference : Expression
    {
        public SymbolReference(Symbol symbol)
        {
            this.Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
        }

        public override Type Type => this.Symbol.Type;

        public Symbol Symbol { get; }
    }
}
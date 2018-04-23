using System;

namespace Psi.Compiler.Intermediate
{
    /// <summary>
    /// A symbol that is contained in a module.
    /// </summary>
    public sealed class Symbol
    {
        public Symbol(IntermediateType type, string id) :
            this(new SymbolName(type, id))
        {

        }

        public Symbol(SymbolName name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Type = name.Type;
        }

        public SymbolName Name { get; }

        public IntermediateType Type { get; }

        public Expression Initializer { get; set; }

        public bool IsConst { get; set; }

        public bool IsExported { get; set; }
    }
}
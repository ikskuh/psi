using System;

namespace Psi.Compiler.Intermediate
{
    /// <summary>
    /// A symbol that is contained in a module.
    /// </summary>
    public sealed class Symbol
    {
        public Symbol(Type type, string id) :
            this(new SymbolName(type, id))
        {

        }

        public Symbol(SymbolName name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Type = name.Type;
        }

        public SymbolName Name { get; }

        public Type Type { get; }

        public Expression Initializer { get; set; }

        public bool IsConst { get; set; }

        public bool IsExported { get; set; }

        public SymbolKind Kind { get; set; }

        public T GetValue<T>() => (this.Initializer as Literal<T>).Value;

        public override string ToString() => $"{Kind} {this.Name}";
    }

    public enum SymbolKind
    {
        Global = 0,
        Parameter = 1,
        Local = 2,
    }
}
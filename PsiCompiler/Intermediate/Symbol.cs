using System;

namespace Psi.Compiler.Intermediate
{
    /// <summary>
    /// A symbol that is contained in a module.
    /// </summary>
    public sealed class Symbol
    {
        public Symbol(Type type, string id)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            this.Name = new Signature(type.Signature, id);
            this.Type = type;
        }

        public Symbol(Type type, PsiOperator id) :
            this(type, id.ToSymbolName())
        {

        }

        public Signature Name { get; }

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
        Builtin = 3,
    }
}
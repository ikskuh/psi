using System;

namespace Psi.Compiler.Intermediate
{
    /// <summary>
    /// A class that represents a "typed name" that is used for addressing symbols in a scope.
    /// </summary>
    public sealed class Signature : IEquatable<Signature>
    {
        public Signature(Type type, string id)
        {
            this.Type = type?.Signature ?? throw new ArgumentNullException(nameof(type));
            this.ID = id ?? throw new ArgumentNullException(nameof(id));
        }

        public Signature(ITypeSignature type, string id)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
            this.ID = id ?? throw new ArgumentNullException(nameof(id));
        }

        public Signature(Type type, PsiOperator op) : this(type, op.ToSymbolName())
        {

        }

        public Signature(ITypeSignature type, PsiOperator op) : this(type, op.ToSymbolName())
        {

        }

        public ITypeSignature Type { get; set; }

        public string ID { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as Signature);

        public bool Equals(Signature other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (other is null)
                return false;
            return Type.Equals(other.Type) && ID.Equals(other.ID);
        }

        public override int GetHashCode() => Type.GetHashCode() ^ ID.GetHashCode();
        
        public override string ToString() => $"({ID} : {Type})";

        public static bool operator ==(Signature lhs, Signature rhs) => lhs?.Equals(rhs) ?? false;
        public static bool operator !=(Signature lhs, Signature rhs) => !(lhs == rhs);
    }
}
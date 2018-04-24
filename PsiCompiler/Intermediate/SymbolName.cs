using System;

namespace Psi.Compiler.Intermediate
{
    /// <summary>
    /// A class that represents a "typed name" that is used for addressing symbols in a scope.
    /// </summary>
    public sealed class SymbolName : IEquatable<SymbolName>
    {
        public SymbolName(Type type, string id)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
            this.ID = id ?? throw new ArgumentNullException(nameof(id));
        }

        public Type Type { get; set; }

        public string ID { get; set; }

        public override bool Equals(object obj) => this.Equals(obj as SymbolName);

        public bool Equals(SymbolName other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (other is null)
                return false;
            return Type.Equals(other.Type) && ID.Equals(other.ID);
        }

        public override int GetHashCode() => Type.GetHashCode() ^ ID.GetHashCode();
        
        public override string ToString() => $"{ID} ({Type})";

        public static bool operator ==(SymbolName lhs, SymbolName rhs) => lhs?.Equals(rhs) ?? false;
        public static bool operator !=(SymbolName lhs, SymbolName rhs) => !(lhs == rhs);
    }
}
using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class RecordMember : IEquatable<RecordMember>
    {
        public RecordMember(RecordType type, string name)
        {
            this.Owner = type ?? throw new ArgumentNullException(nameof(type));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public RecordType Owner { get; }

        public string Name { get; }

        public Type Type { get; set; }

        public Expression Initializer { get; set; }

        public override bool Equals(object obj) => Equals(obj as RecordMember);

        public bool Equals(RecordMember other)
        {
            if (other == null)
                return false;
            return object.Equals(Name, other.Name)
                && object.Equals(Type, other.Type)
                && object.Equals(Initializer, other.Initializer);
        }

        public override int GetHashCode() => Name.GetHashCode() ^ (Type?.GetHashCode() ?? 0) ^ (Initializer?.GetHashCode() ?? 0);
    }
}
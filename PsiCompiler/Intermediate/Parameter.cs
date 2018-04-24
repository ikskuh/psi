using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class Parameter : IEquatable<Parameter>
    {
        public Parameter(FunctionType owner, string name, int position)
        {
            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position));
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Position = position;
        }

        public FunctionType Owner { get; }

        public string Name { get; }

        public int Position { get; }

        public ParameterFlags Flags { get; set; }

        public Type Type { get; set; }

        public Expression Initializer { get; set; }

        public override bool Equals(object obj) => Equals(obj as Parameter);

        public override int GetHashCode() =>
              Position.GetHashCode()
            ^ (Flags & ~ParameterFlags.This).GetHashCode()
            ^ (Type?.GetHashCode() ?? 0)
            ^ (Initializer?.GetHashCode() ?? 0);

        public bool Equals(Parameter other)
        {
            if (other == null)
                return false;
            return object.Equals(Position, other.Position)
                && object.Equals((Flags & ~ParameterFlags.This), (other.Flags & ~ParameterFlags.This))
                && object.Equals(Type, other.Type)
                && object.Equals(Initializer, other.Initializer);
        }
    }
}
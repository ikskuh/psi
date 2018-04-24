using System;

namespace Psi.Compiler.Intermediate
{
    public abstract class Expression
    {
        public abstract Type Type { get; }
    }

    public sealed class Literal<T> : Expression
    {
        public Literal(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            this.Value = value;
            this.Type = TypeMapper.Get<T>();
        }

        public override Type Type { get; }

        public T Value { get; }
    }
}
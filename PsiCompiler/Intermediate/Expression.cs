using System;

namespace Psi.Compiler.Intermediate
{
    public abstract class Expression
    {

    }

    public sealed class Literal<T> : Expression
    {
        public Literal(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            this.Value = value;
        }

        public T Value { get; }
    }
}
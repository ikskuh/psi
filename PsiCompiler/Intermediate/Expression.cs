using System;

namespace Psi.Compiler.Intermediate
{
    public abstract class Expression
    {
        public abstract Type Type { get; }
    }

    public sealed class FunctionLiteral : Expression
    {
        Function value;

        public FunctionLiteral(FunctionType type)
        {
            this.Type = type;
        }

        public FunctionLiteral(Function fun) : this(fun.Type)
        {
            this.value = fun;
        }

        public override Type Type { get; }

        public Function Value
        {
            get { return value; }
            set
            {
                if (value == null)
                {
                    this.value = null;
                }
                if (value.Type.Equals(this.Type) == false)
                    throw new InvalidOperationException();
                this.value = value;
            }
        }
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
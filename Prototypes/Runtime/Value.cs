using System;

namespace Runtime
{
    public interface RValue
    {
        Type Type { get; }

        Value GetValue();
    }

    public interface LValue : RValue
    {
        void SetValue(Value value);
    }

    public abstract class Value : RValue
    {
        protected Value(Type type)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        // Haha, very funny... But convenient
        public Value GetValue() { return this; }

        public Type Type { get; }

        public abstract Value Clone();
    }
}
using System;

namespace Runtime
{
    public abstract class Value
    {
        protected Value(Type type)
        {
        	if(type == null)
        		throw new ArgumentNullException(nameof(type));
            this.Type = type;
        }

        public Type Type { get; }
    }
}
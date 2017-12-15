using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
    public class ValueStore : LValue
    {
        private Value value;

        public ValueStore(Type type)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public Type Type { get; }

        public Value Value
        {
            get { return this.value ?? throw new InvalidOperationException("Access to unitialized variable!"); }
            set
            {
                if(value?.Type != this.Type)
                    throw new ArgumentOutOfRangeException(nameof(value));
                this.value = value;
             }
        }

        public void SetValue(Value value) => this.Value = value;

        public Value GetValue() => this.Value;

        public override string ToString() => this.value?.ToString() ?? "<nil>";
    }
}

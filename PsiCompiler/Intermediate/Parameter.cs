using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class Parameter
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
    }
}
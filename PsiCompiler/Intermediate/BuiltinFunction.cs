using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class BuiltinFunction : Function
    {
        public BuiltinFunction(FunctionType type)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public override FunctionType Type { get; }
    }
}
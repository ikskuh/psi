using System;

namespace Psi.Compiler.Intermediate
{
    public abstract class Expression
    {

    }

    public sealed class TypeLiteral : Expression
    {
        public  TypeLiteral(IntermediateType type)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public IntermediateType Type { get; }
    }
}
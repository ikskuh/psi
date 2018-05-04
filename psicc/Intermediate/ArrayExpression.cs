using System.Collections.Generic;

namespace Psi.Compiler.Intermediate
{
    internal class ArrayExpression : Expression
    {
        public ArrayExpression()
        {
        }

        public Expression[] Items { get; set; }

        public override Type Type => this.ItemType;

        public Type ItemType { get; set; }
    }
}
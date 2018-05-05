using System.Collections.Generic;

namespace Psi.Compiler.Intermediate
{
    public sealed class ArrayExpression : Expression
    {
        public ArrayExpression()
        {
        }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);

        public Expression[] Items { get; set; }

        public override Type Type => this.ItemType;

        public Type ItemType { get; set; }
    }
}
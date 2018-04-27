using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class ExpressionStatement : Statement
    {
        public Expression Expression { get; set; }
    }
}
using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class ExpressionStatement : Statement
    {
        public ExpressionStatement(Expression expr)
        {
            this.Expression = expr ?? throw new ArgumentNullException(nameof(expr));
        }

        public Expression Expression { get; }
    }
}
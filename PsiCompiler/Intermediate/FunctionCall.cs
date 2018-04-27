using System;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public sealed class FunctionCall : Expression
    {
        public FunctionCall(Expression function, Expression[] args)
        {
            this.Function = function ?? throw new ArgumentNullException(nameof(Function));
            this.Arguments = args?.ToArray() ?? throw new ArgumentNullException(nameof(args));
        }

        public Expression Function { get; }

        public IReadOnlyList<Expression> Arguments { get; }

        public override Type Type => (Function.Type as FunctionType)?.ReturnType;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public sealed class FunctionCall : Expression
    {
        public FunctionCall(Expression function, Expression[] args)
        {
            this.Functor = function ?? throw new ArgumentNullException(nameof(Functor));
            this.Arguments = args?.ToArray() ?? throw new ArgumentNullException(nameof(args));
        }

        public FunctionCall() { }

        /// <summary>
        /// The value that is beeing called
        /// </summary>
        public Expression Functor { get; set;  }

        /// <summary>
        /// The list of arguments that is passed into the function
        /// </summary>
        public IReadOnlyList<Expression> Arguments { get;set;  }

        public override Type Type => (Functor.Type as FunctionType)?.ReturnType;
    }
}
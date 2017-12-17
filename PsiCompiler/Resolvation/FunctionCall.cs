using System;
using System.Collections.Generic;
using System.Linq;
using Psi.Runtime;

namespace Psi.Compiler.Resolvation
{
	public sealed class FunctionCall : IResolvationResult
	{
		public FunctionCall(IResolvationResult fun, params IResolvationResult[]  args)
		{
			if(fun == null) throw new ArgumentNullException(nameof(fun));
			if(args == null) throw new ArgumentNullException(nameof(args));
			this.Function = fun;
			this.Arguments = args.ToArray();
		}
		
		public IResolvationResult Function { get; }
		
		public IReadOnlyList<IResolvationResult> Arguments { get; }
		
		public Runtime.Type Type => ((FunctionType)this.Function.Type).ReturnType;

		public bool IsEvaluatable => this.Function.IsEvaluatable && this.Arguments.All(a => a.IsEvaluatable);

		public Value Evaluate(ExecutionContext ctx)
		{
			throw new NotSupportedException();
		}
	}
}

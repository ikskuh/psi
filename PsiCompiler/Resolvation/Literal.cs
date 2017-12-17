using System;
using Psi.Runtime;

namespace Psi.Compiler.Resolvation
{
	public class Literal : IResolvationResult
	{
		public Literal(Value value)
		{
			if(value == null) throw new ArgumentNullException(nameof(value));
			this.Value = value;
		}
		
		public Value Value { get; }
		
		public Runtime.Type Type => this.Value.Type;

		public bool IsEvaluatable => true;

		public Value Evaluate(ExecutionContext ctx) => this.Value;
	}
}

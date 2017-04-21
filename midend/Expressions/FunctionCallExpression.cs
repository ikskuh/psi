using System;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public sealed class FunctionCallExpression : Expression
	{
		private readonly Function function;
		private readonly Dictionary<Parameter, Argument> arguments = new Dictionary<Parameter, Argument>();

		public FunctionCallExpression(Function function, params Expression[] args)
			: this(function, args.Select((v, i) => new PositionalArgument(i, v)).ToArray())
		{

		}

		public FunctionCallExpression(Function function, params Argument[] args)
		{
			if (function == null) throw new ArgumentNullException(nameof(function));
			if (args == null) throw new ArgumentNullException(nameof(args));
			this.function = function;

			var set = new HashSet<Parameter>(this.function.Type.Parameters);
			for (int i = 0; i < args.Length; i++)
			{
				var arg = args[i];
				if (arg is PositionalArgument)
				{
					var parg = (PositionalArgument)arg;
					var par = this.function.Type.Parameters[parg.Index];
					if (set.Remove(par) == false)
						throw new InvalidOperationException("Double argument!");
					this.arguments.Add(par, arg);
				}
				else if (arg is NamedArgument)
				{
					var narg = (NamedArgument)arg;
					var par = this.function.Type.Parameters[narg.Name];
					if (set.Remove(par) == false)
						throw new InvalidOperationException("Double argument!");
					this.arguments.Add(par, arg);
				}
				else
				{
					throw new InvalidOperationException("Invalid argument!");
				}
			}
			if (set.Count > 0)
				throw new InvalidOperationException("Insufficient arguments!");
		}

		public override CType Type => this.function.Type.ReturnType;

		public IReadOnlyDictionary<Parameter, Argument> Arguments => this.arguments;
		
		public override bool IsConstant => 
			this.function.IsCompileTimeEvaluatable
			&& this.arguments.Values.All(arg => arg.Value.IsConstant);

		public override CValue Evaluate(EvaluationContext context)
		{
			var args = new CValue[this.function.Type.Parameters.Count];
			for(int i = 0; i < args.Length; i++)
			{
				args[i] = this.Arguments[this.function.Type.Parameters[i]].Value.Evaluate(context);
			}
			return this.function.Evaluate(args);
		}
	}
}

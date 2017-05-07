using System;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public sealed class FunctionCallExpression : Expression
	{
		private readonly FunctionType type;
		private readonly Expression function;
		private readonly Function ctor;
		private readonly Dictionary<Parameter, Argument> arguments = new Dictionary<Parameter, Argument>();

		public FunctionCallExpression(Expression function, params Expression[] args)
			: this(function, args.Select((v, i) => new PositionalArgument(i, v)).ToArray())
		{

		}

		public FunctionCallExpression(Expression function, params Argument[] args)
		{
			if (function == null) throw new ArgumentNullException(nameof(function));
			if (args == null) throw new ArgumentNullException(nameof(args));
			this.function = function;

			if (this.function.Type is TypeType)
			{
				if (!this.function.IsConstant)
					throw new NotSupportedException("Types must be compile time evaluatable!");
				var value = this.function.Execute();
				this.ctor = value.Get<CType>().GetConstructor();
				this.type = ctor.Type;
			}
			else
			{
				this.type = this.function.Type as FunctionType;
			}
			if (this.type == null) throw new ArgumentException("The given function expression does not have a callable type!");


			var set = new HashSet<Parameter>(this.type.Parameters);
			for (int i = 0; i < args.Length; i++)
			{
				var arg = args[i];
				if (arg is PositionalArgument)
				{
					var parg = (PositionalArgument)arg;
					var par = type.Parameters[parg.Index];
					if (set.Remove(par) == false)
						throw new InvalidOperationException("Double argument!");
					this.arguments.Add(par, arg);
				}
				else if (arg is NamedArgument)
				{
					var narg = (NamedArgument)arg;
					var par = type.Parameters[narg.Name];
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

		public override CType Type => this.type.ReturnType;

		public IReadOnlyDictionary<Parameter, Argument> Arguments => this.arguments;

		public override bool IsConstant =>
			this.function.IsConstant
			&& this.arguments.Values.All(arg => arg.Value.IsConstant);

		public override CValue Evaluate(EvaluationContext context)
		{
			var args = new CValue[this.type.Parameters.Count];
			for (int i = 0; i < args.Length; i++)
			{
				args[i] = this.Arguments[this.type.Parameters[i]].Value.Evaluate(context);
			}
			// Don't evaluate the type at evaluation time but use the one from the constructor.
			var functor = this.ctor ?? this.function.Evaluate(context).Get<Function>();
			return functor.Evaluate(args);
		}
	}
}

using System;
namespace Psi.Runtime
{
	public abstract class ValueReference
	{
		protected ValueReference(bool isCopy)
		{
			this.IsCopy = isCopy;
		}

		public ValueStore Evaluate(ExecutionContext context)
		{
			var value = Extract(context);
			if (IsCopy)
				value = value.Clone();
			return value;
		}

		protected abstract ValueStore Extract(ExecutionContext context);

		public bool IsCopy { get; }
	}
}

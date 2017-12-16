using System;
namespace Psi.Runtime
{
	public sealed class StackFrameReference : ValueReference
	{
		public StackFrameReference(int index, bool isCopy) : base(isCopy)
		{
			this.Index = index;
		}

		protected override ValueStore Extract(ExecutionContext context) => context.StackFrame[Index];

		public int Index { get; }

		public override string ToString() => $"Global[{Index}]";
	}
}

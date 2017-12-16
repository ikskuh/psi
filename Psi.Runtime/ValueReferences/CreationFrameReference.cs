using System;
namespace Psi.Runtime
{
	public sealed class CreationFrameReference : ValueReference
	{
		public CreationFrameReference(int index, bool isCopy) : base(isCopy)
		{
			this.Index = index;
		}

		protected override ValueStore Extract(ExecutionContext context) => context.CreationFrame[Index];

		public int Index { get; }

		public override string ToString() => $"Global[{Index}]";
	}
}

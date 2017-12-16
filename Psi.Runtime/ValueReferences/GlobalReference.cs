using System;
namespace Psi.Runtime
{
	public sealed class GlobalReference : ValueReference
	{
		public GlobalReference(int index, bool isCopy) : base(isCopy)
		{
			this.Index = index;
		}

		protected override ValueStore Extract(ExecutionContext context) => context.Globals[Index];

		public int Index { get; }

		public override string ToString() => $"Global[{Index}]";
	}
}

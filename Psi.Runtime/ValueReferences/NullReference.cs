using System;
namespace Psi.Runtime
{
	public sealed class NullReference : ValueReference
	{
		public NullReference() : base(false) { }
		
		protected override ValueStore Extract(ExecutionContext context) => ValueStore.Null;
	}
}

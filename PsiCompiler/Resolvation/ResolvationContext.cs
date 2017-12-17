using System;
namespace Psi.Compiler.Resolvation
{
	public sealed class ResolvationContext
	{
		public ResolvationContext(Scope scope)
		{
			if(scope == null) throw new ArgumentNullException(nameof(scope));
			this.Scope = scope;
		}
	
		public Scope Scope { get; }
	}
}
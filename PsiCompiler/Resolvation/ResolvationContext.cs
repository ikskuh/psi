using System;
using System.Collections.Generic;

namespace Psi.Compiler.Resolvation
{
	public sealed class ResolvationContext
	{
		public ResolvationContext(VariableScope vars, TypeScope types)
		{
			if(vars == null) throw new ArgumentNullException(nameof(vars));
			if(types == null) throw new ArgumentNullException(nameof(types));
			this.Variables = vars;
			this.Types = types;
		}
	
		public VariableScope Variables { get; }
		
		public TypeScope Types { get; }
		
		public IDictionary<string,ResolvationContext> Modules { get; } = new Dictionary<string,ResolvationContext>();

		public ResolvationContext DeriveChild() => new ResolvationContext(
			this.Variables.CreateChild(),
			this.Types.CreateChild());
	}
}
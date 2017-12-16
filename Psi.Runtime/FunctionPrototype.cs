using System;

namespace Psi.Runtime
{
	public abstract class FunctionPrototype
	{
		protected FunctionPrototype(FunctionType type)
		{
			if(type == null) throw new ArgumentNullException(nameof(type));
			this.Type = type;
		}
		
		public abstract StorageContext CreateStack();
	
		public abstract void Execute(ExecutionContext context);
		
		public FunctionType Type { get; }
	}
}
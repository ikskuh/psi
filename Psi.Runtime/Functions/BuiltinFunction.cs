using System;
using System.Linq;
namespace Psi.Runtime
{
	public delegate Value BuiltinFunctionImplementationDelegate(ValueStore[] args);

	public class BuiltinFunction : FunctionPrototype
	{
		private readonly BuiltinFunctionImplementationDelegate impl;

		public BuiltinFunction(FunctionType type, BuiltinFunctionImplementationDelegate impl) : base(type)
		{
			if(impl == null) throw new InvalidOperationException();
			this.impl = impl;
		}
		
		public override StorageContext CreateStack()
		{
			int offset = (this.Type.ReturnType is VoidType ? 0 : 1);
			var stack = new StorageContext(
				offset + 
				this.Type.Parameters.Count);
			if(offset > 0)
				stack[0] = new ValueStore(this.Type.ReturnType);
			
			for(int i = 0; i < this.Type.Parameters.Count; i++)
				stack[offset + i] = new ValueStore(this.Type.Parameters[i].Type);
			offset += this.Type.Parameters.Count;
			
			return stack;
		}
		
		public override void Execute(ExecutionContext context)
		{
			if(this.Type.ReturnType is VoidType)
				this.impl(context.StackFrame.ToArray());
			else
				context.StackFrame[0].Value = this.impl(context.StackFrame.Skip(1).ToArray());
		}
	}
}

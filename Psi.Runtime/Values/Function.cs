using System;
namespace Psi.Runtime
{

	public sealed class Function : Value
	{
		public Function(FunctionPrototype proto) : this(proto, null)
		{

		}

		public Function(FunctionPrototype proto, StorageContext creationContext) : base(proto.Type)
		{
			if (proto == null) throw new ArgumentNullException(nameof(proto));
			this.Prototype = proto;
			this.CreationContext = creationContext;
		}

		public void Call(StorageContext globals, params ValueStore[] valueStore)
		{
			var stack = this.Prototype.CreateStack();
			for (int i = 0; i < valueStore.Length; i++)
				stack[i] = valueStore[i];

			var context = new ExecutionContext(
				globals,
				stack,
				this.CreationContext);
			this.Prototype.Execute(context);
		}

		public static implicit operator Function(FunctionPrototype proto) => new Function(proto);

		public StorageContext CreationContext { get; }

		public FunctionPrototype Prototype { get; }

	}
}

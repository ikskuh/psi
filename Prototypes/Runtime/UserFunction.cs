using System;
using System.Linq;
using System.Collections.Generic;
namespace Runtime
{
	public sealed class UserFunction : FunctionPrototype
	{
		private readonly Statement[] code;
		private readonly Type[] temporaryTypes;
	
		public UserFunction(FunctionType type, Statement[] code, params Type[] temporaries) : base(type)
		{
			if(code == null) throw new ArgumentNullException(nameof(code));
			if(code.Length == 0) throw new ArgumentOutOfRangeException(nameof(code));
			if(temporaries == null) throw new ArgumentNullException(nameof(temporaries));
			
			this.code = code.ToArray();
			this.temporaryTypes = temporaries.ToArray();
		}
		
		public override StorageContext CreateStack()
		{
			int offset = (this.Type.ReturnType is VoidType ? 0 : 1);
			var stack = new StorageContext(
				offset + 
				this.Type.Parameters.Count + 
				this.temporaryTypes.Length);
			if(offset > 0)
				stack[0] = new ValueStore(this.Type.ReturnType);
			
			for(int i = 0; i < this.Type.Parameters.Count; i++)
				stack[offset + i] = new ValueStore(this.Type.Parameters[i].Type);
			offset += this.Type.Parameters.Count;
			
			for(int i = 0; i < this.temporaryTypes.Length; i++)
				stack[offset + i] = new ValueStore(this.temporaryTypes[i]);
			
			return stack;
		}
		
		public override void Execute(ExecutionContext context)
		{
			context.InstructionPointer = 0;
			while(context.InstructionPointer != null)
			{
				int ip = context.InstructionPointer.Value;
				context.InstructionPointer++;
				var stmt = this.code[ip];
				// Console.Error.WriteLine("EXEC {0}", stmt.Location);
				stmt.Execute(context);
			}
		}
	}
	
	
	public abstract class Statement
	{
		public abstract void Execute(ExecutionContext context);
		
		public string Location { get; set; } = "unknown";

		public sealed class Call : Statement
		{
			public Call(ValueReference function, params ValueReference[] arguments)
			{
				if(function == null) throw new ArgumentNullException(nameof(function));
				if(arguments == null) throw new ArgumentNullException(nameof(arguments));
				this.Function = function;
				this.Arguments = arguments.ToArray();
			}
		
			public override void Execute(ExecutionContext context)
			{
				var function = this.Function.Evaluate(context).Value as Function;
				function.Call(context.Globals, this.Arguments.Select(v => v.Evaluate(context)).ToArray());
			}

			public ValueReference Function { get; }

			public IReadOnlyList<ValueReference> Arguments { get; }
		}

		public sealed class Exit : Statement
		{
			public override void Execute(ExecutionContext context)
			{
				context.InstructionPointer = null;
			}
		}

		public sealed class Jump : Statement
		{
			public Jump(int dest)
			{
				this.Destination = dest;
			}

			public override void Execute(ExecutionContext context)
			{
				context.InstructionPointer = this.Destination;
			}

			public int Destination { get; }
		}

		public sealed class ConditionalJump : Statement
		{
			public ConditionalJump(ValueReference conditional, int dest, JumpBehaviour when)
			{
				if(conditional == null) throw new ArgumentNullException(nameof(conditional));
				this.Conditional = conditional;
				this.JumpWhen = when;
				this.Destination = dest;
			}
			
			public override void Execute(ExecutionContext context)
			{
				var slot = this.Conditional.Evaluate(context);
				
				var condition = (bool)(slot.Value as Boolean);
				if(condition == (this.JumpWhen == JumpBehaviour.WhenTrue))
					context.InstructionPointer = this.Destination;
			}
			
			public ValueReference Conditional { get; }

			public JumpBehaviour JumpWhen { get; }

			public int Destination { get; }
		}

		public sealed class CreateClosure : Statement
		{
			public CreateClosure(ValueReference variable, FunctionPrototype function)
			{	
				if(variable == null) throw new ArgumentNullException(nameof(variable));
				if(function == null) throw new ArgumentNullException(nameof(function));
				this.Function = function;
				this.Variable = variable;
			}
			
			public override void Execute(ExecutionContext context)
			{
				this.Variable.Evaluate(context).Value = new Function(this.Function, context.StackFrame);
			}
			
			public FunctionPrototype Function { get; }

			public ValueReference Variable { get; }

		}
	}
	
	public enum JumpBehaviour
	{
		WhenFalse = 0,
		WhenTrue = 1
	}
}

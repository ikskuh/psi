using System;
namespace Psi.Runtime
{
	public sealed class ExecutionContext
	{
		public ExecutionContext(StorageContext globals, StorageContext stackFrame, StorageContext creationFrame)
		{
			if(globals == null) throw new ArgumentNullException(nameof(globals));
			if(stackFrame == null) throw new ArgumentNullException(nameof(stackFrame));
			this.Globals = globals;
			this.StackFrame = stackFrame;
			this.CreationFrame = creationFrame;
		}

		public StorageContext Globals { get; }

		public StorageContext StackFrame { get; }

		public StorageContext CreationFrame { get; }
		
		public int? InstructionPointer { get; set; } = 0;
	}
}

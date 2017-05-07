using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public abstract class FunctionType : CType
	{
		private readonly CType returnType;
		private readonly Parameter[] parameters;
	
		protected FunctionType(CType returnType, params Parameter[] parameters)
		{
			if(returnType == null) throw new ArgumentNullException(nameof(returnType));
			if(parameters == null) throw new ArgumentNullException(nameof(parameters));
			this.returnType = returnType;
			this.parameters = parameters.ToArray();
		}
		
		public CType ReturnType => this.returnType;
		
		public FunctionCollection Parameters => new FunctionCollection(this);
		
		// TODO: Implement restrictions
		
		
		
		public sealed class FunctionCollection : IReadOnlyList<Parameter>
		{
			private readonly FunctionType func;
		
			public FunctionCollection(FunctionType func)
			{
				if(func == null) throw new ArgumentNullException(nameof(func));
				this.func = func;
			}

			public Parameter this[int index] => this.func.parameters[index];
			
			public Parameter this[string name] => this.func.parameters.Single(p => p.Name == name);

			public int Count => this.func.parameters.Length;

			public IEnumerator<Parameter> GetEnumerator() => ((IReadOnlyList<Parameter>)this.func.parameters).GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
		}
	}
}

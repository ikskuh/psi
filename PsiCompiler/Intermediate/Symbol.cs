using System;

namespace Psi.Compiler
{
	public class Symbol
	{
		public string Name { get; set; }
		
		public PsiType Type { get; set; }
		
		public IntermediateExpression Value { get; set; }
		
		// public Value StaticValue { get; set; }
		
		public bool IsExported { get; set; }
		
		public bool IsConst { get; set; }
		
		public Scope Scope { get; set; }
		
		public bool IsComplete => (this.Value == null || this.Value.IsComplete) && (this.Type != null);
	}
}

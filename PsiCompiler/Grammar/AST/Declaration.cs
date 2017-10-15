using System;
namespace PsiCompiler.Grammar
{
	public sealed class Declaration
	{
		public Declaration(string name, Expression type, Expression value)
		{
			this.Name = name.NotNull();
			this.Type = type;
			this.Value = value;
		}
	
		public string Name { get; }
		
		public Expression Type { get; }
		
		public Expression Value { get; }
		
		public bool IsExported { get; set; }
		
		public bool IsConst { get; set; }
	}
}

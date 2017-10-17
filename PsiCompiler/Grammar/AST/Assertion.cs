using System;
namespace PsiCompiler.Grammar
{
    // Special statement: Can be stated outside of a block
	public sealed class Assertion : Statement
	{
		public Assertion(Expression expression)
		{
			this.Expression = expression.NotNull();
		}
		
		public Expression Expression { get; }
	}
}

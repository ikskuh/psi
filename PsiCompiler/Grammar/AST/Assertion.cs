using System;
namespace PsiCompiler.Grammar
{
	public sealed class Assertion
	{
		public Assertion(Expression expression)
		{
			this.Expression = expression.NotNull();
		}
		
		public Expression Expression { get; }
	}
}

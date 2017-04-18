using System;
namespace midend
{
	public abstract class Expression
	{
		protected Expression()
		{
			
		}
		
		public abstract CValue Evaluate(EvaluationContext context);
		
		public abstract CType Type { get; }

		public static Expression Constant(CType type) => new TypeExpression(type);
	}
}

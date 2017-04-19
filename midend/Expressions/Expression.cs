using System;
using System.Numerics;
namespace midend
{
	public abstract class Expression
	{
		protected Expression()
		{
			
		}
		
		public virtual bool IsConstant => false;
		
		public abstract CValue Evaluate(EvaluationContext context);
		
		public abstract CType Type { get; }

		public static Expression Constant(CType value) => new TypeExpression(value);

		public static Expression Constant(BigInteger value) => new IntegerExpression(value);

		public static Expression Constant(string value) => new StringExpression(value);

		public static Expression Constant(Module value) => new LiteralExpression<Module>(CTypes.Module, value);

		public static Expression Constant(bool value) => new LiteralExpression<bool>(CTypes.Boolean, value);
	}
}

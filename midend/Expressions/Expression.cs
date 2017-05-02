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
		
		/// <summary>
		/// Tries to evaluate the expression if constant, otherwise will return the expression itself.
		/// </summary>
		/// <returns>The simplify.</returns>
		/// <param name="ex">Ex.</param>
		public static Expression Simplify(Expression ex)
		{
			if(ex == null) throw new ArgumentNullException(nameof(ex));
			if(ex.IsConstant == false)
				return ex;
			
			var ec = new EvaluationContext();
			var value = ex.Evaluate(ec);
			if(value == null) throw new InvalidOperationException("Expression evaluation returned null!");
			
			return new ConstantExpression(value);
		}
		
		#region Constants
		
		public static Expression Constant(CType type, object value) => new ConstantExpression(new CValue(type, value));
		
		public static Expression Constant(CValue value) => new ConstantExpression(value);
		
		public static Expression Constant(Function value) => new LiteralExpression<Function>(value.Type, value);

		public static Expression Constant(CType value) => new TypeExpression(value);

		public static Expression Constant(BigInteger value) => new IntegerExpression(value);

		public static Expression Constant(string value) => new StringExpression(value);

		public static Expression Constant(Module value) => new LiteralExpression<Module>(CTypes.Module, value);

		public static Expression Constant(bool value) => new LiteralExpression<bool>(CTypes.Boolean, value);
		
		#endregion
	}
}

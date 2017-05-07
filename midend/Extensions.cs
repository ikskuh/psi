using System;
namespace midend
{
	public static class Extensions
	{
		public static Expression Simplify(this Expression ex) => Expression.Simplify(ex);
		
		public static CValue Execute(this Expression ex) => Expression.Execute(ex);
	}
}

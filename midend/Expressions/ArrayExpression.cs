using System;
using System.Linq;
namespace midend
{
	public sealed class ArrayExpression : Expression
	{
		private readonly ArrayType type;
		private readonly Expression[] items;

		public ArrayExpression(Expression[] items)
		{
			if(items == null) throw new ArgumentNullException(nameof(items));
			this.items = items;
			
			var types = items.Select(exp => exp.Type).Distinct().ToArray();
			this.type = new ArrayType(InferArrayType(types));
		}
		
		private static CType InferArrayType(CType[] includedTypes)
		{
			// Trivial case
			if(includedTypes.Length == 1)
				return includedTypes[0];
			
			if(includedTypes.All(type => type is IntegerType))
			{
				var types = includedTypes.Cast<IntegerType>();
				var min = types.Min(type => type.Minimum);
				var max = types.Max(type => type.Maximum);
				
				var behav = types.Select(type => type.Behaviour).OrderByDescending(b => b).Distinct().ToArray();
				
				// Take the most "restrictive" behavour
				return new IntegerType(min, max, behav[0]);
			}
			
			throw new NotSupportedException("Array type not supported yet.");
		}

		public override CType Type => this.type;
		
		public override bool IsConstant => this.items.All(exp => exp.IsConstant);

		public override CValue Evaluate(EvaluationContext context)
		{
			var array = new CArray(this.type, items.Select(exp => exp.Evaluate(context)).ToArray());
			return new CValue(this.type, array);
		}
	}
}

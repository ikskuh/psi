using System;
namespace midend
{
	public sealed class FieldIndexExpression : Expression
	{
		private readonly Expression value;
		private readonly Field field;

		public FieldIndexExpression(Expression value, Field field)
		{
			if(value == null) throw new ArgumentNullException(nameof(value));
			if(field == null) throw new ArgumentNullException(nameof(field));
			this.value = value;
			this.field = field;
		}
		
		public override CType Type => this.field.Type;
		
		public override bool IsConstant => this.value.IsConstant && this.field.IsCompileTimeEvaluatable;
		
		public override CValue Evaluate(EvaluationContext context)
		{
			var value = this.value.Evaluate(context);
			return this.field.Evaluate(value, context);
		}
	}
}

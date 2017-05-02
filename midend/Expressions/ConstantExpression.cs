using System;
namespace midend
{
	public sealed class ConstantExpression : Expression
	{
		private readonly CValue value;
		
		public ConstantExpression(CValue value)
		{
			if(value == null) throw new ArgumentNullException(nameof(value));
			this.value = value;
		}
		
		public override bool IsConstant => true;
		
		public override CValue Evaluate(EvaluationContext context) => this.value;

		public object Value => this.value.Value;

		public override CType Type => this.value.Type;
		
		public override string ToString() => $"`{this.Value}`";
	}
}

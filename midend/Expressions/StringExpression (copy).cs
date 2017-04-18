using System;
namespace midend
{
	public sealed class StringExpression : Expression
	{
		private readonly string value;

		public StringExpression(string value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));
			this.value = value;
		}
		
		public override CValue Evaluate(EvaluationContext context) => new CValue(CType.Type, this.value);
		
		public string Value => this.value;

		public override CType Type => CType.Type;
	}
}

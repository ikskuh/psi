using System;
namespace midend
{
	public sealed class ConstantField : Field
	{
		private readonly CValue value;

		public ConstantField(CType type, object value) :
			this(new CValue(type, value))
		{

		}

		public ConstantField(CValue value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			this.value = value;
		}

		public override CType Type => this.value.Type;

		public override bool IsCompileTimeEvaluatable => true;

		public override CValue Evaluate(CValue value, EvaluationContext context)
		{
			return this.value;
		}
	}
}
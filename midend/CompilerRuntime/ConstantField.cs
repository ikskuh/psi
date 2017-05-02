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
		
		}
		
		public override CType Type => this.value.Type;
		
		public override CValue Evaluate(CValue value, EvaluationContext context)
		{
			return this.value;
		}
	}
}
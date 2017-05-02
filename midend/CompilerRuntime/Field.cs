namespace midend
{
	public abstract class Field
	{
		public abstract CValue Evaluate(CValue value, EvaluationContext context);
		
		public abstract CType Type { get; }
	}
}
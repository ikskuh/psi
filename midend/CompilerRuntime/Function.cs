using System;
namespace midend
{
	public abstract class Function
	{
		private readonly FunctionType type;
		
		protected Function(FunctionType type)
		{
			if(type == null) throw new ArgumentNullException(nameof(type));
			this.type = type;
		}
		
		public virtual CValue Evaluate(CValue[] args)
		{
			throw new NotSupportedException($"{this.GetType().Name} does not supported compile time evaluation, but says so!");
		}
		
		public FunctionType Type => this.type;

		public virtual bool IsCompileTimeEvaluatable => false;
	}
	
	public class BuiltinFunction : Function
	{
		private readonly Func<CValue[], CValue> evaluator;

		public BuiltinFunction(FunctionType type) : base(type)
		{
			
		}
		
		public BuiltinFunction(FunctionType type, Func<CValue[], CValue> evaluator) : this(type)
		{
			if(evaluator == null) throw new ArgumentNullException(nameof(evaluator));
			this.evaluator = evaluator;
		}
		
		public override bool IsCompileTimeEvaluatable => (this.evaluator != null);
		
		public override CValue Evaluate(CValue[] args) => this.evaluator.Invoke(args);
	}
}

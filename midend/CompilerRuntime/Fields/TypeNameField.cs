using System;
namespace midend
{
	public sealed class TypeNameField : Field
	{		
		public override bool IsCompileTimeEvaluatable => true;

		public override CType Type => CTypes.String;

		public override CValue Evaluate(CValue value, EvaluationContext context)
		{
			return (CValue)value.Get<CType>().ToString();
		}
	}
}

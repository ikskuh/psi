using System;
namespace midend
{
	public sealed class UnaryOperatorType : FunctionType
	{
		public UnaryOperatorType(CType operand, CType returnType) :
			base(returnType, new Parameter("value", operand))
		{
		
		}
		
		public CType Value => this.Parameters[0].Type;
	}
}
using System;
namespace midend
{
	public sealed class BinaryOperatorType : FunctionType
	{
		public BinaryOperatorType(CType operands, CType returnType) :
			base(returnType, new Parameter("lhs", operands), new Parameter("rhs", operands))
		{
		
		}
		
		public CType LeftHandSide => this.Parameters[0].Type;

		public CType RightHandSide => this.Parameters[1].Type;
	}
}
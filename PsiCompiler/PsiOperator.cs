using System;
namespace Psi.Compiler
{
	public enum PsiOperator
	{
		New,
		Plus, Minus, Concat,
		Multiply, Divide, Modulo, Exponentiate,
		Invert, And, Or, Xor,
		Forward, Backward,
		Dot, Meta,
		CopyAssign, SemanticAssign,
		LessOrEqual, MoreOrEqual, Equals, NotEquals, More, Less,
		ArithmeticShiftRight, ShiftLeft, ShiftRight,
				
		WritebackPlus, WritebackMinus, WritebackConcat,
		WritebackMultiply, WritebackDivide, WritebackModulo, WritebackExponentiate,
		WritebackAnd, WritebackOr, WritebackXor,
		WritebackArithmeticShiftRight, WritebackShiftLeft, WritebackShiftRight
	}
}

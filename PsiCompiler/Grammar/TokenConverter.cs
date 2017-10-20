





using System;
using CompilerKit;

namespace PsiCompiler.Grammar
{
	internal static class Converter
	{
		public static PsiOperator? ToOperator(Token<PsiTokenType> token)
		{
			switch(token.Type)
			{

				case PsiTokenType.DOT: return PsiOperator.Dot;

				case PsiTokenType.META: return PsiOperator.Meta;

				case PsiTokenType.INVERT: return PsiOperator.Invert;

				case PsiTokenType.error: return PsiOperator.New;

				case PsiTokenType.ASR: return PsiOperator.ArithmeticShiftRight;

				case PsiTokenType.SHL: return PsiOperator.ShiftLeft;

				case PsiTokenType.SHR: return PsiOperator.ShiftRight;

				case PsiTokenType.PLUS: return PsiOperator.Plus;

				case PsiTokenType.MINUS: return PsiOperator.Minus;

				case PsiTokenType.CONCAT: return PsiOperator.Concat;

				case PsiTokenType.MULT: return PsiOperator.Multiply;

				case PsiTokenType.DIV: return PsiOperator.Divide;

				case PsiTokenType.MOD: return PsiOperator.Modulo;

				case PsiTokenType.EXP: return PsiOperator.Exponentiate;

				case PsiTokenType.AND: return PsiOperator.And;

				case PsiTokenType.OR: return PsiOperator.Or;

				case PsiTokenType.XOR: return PsiOperator.Xor;

				case PsiTokenType.FORWARD: return PsiOperator.Forward;

				case PsiTokenType.BACKWARD: return PsiOperator.Backward;

				case PsiTokenType.IS: return PsiOperator.CopyAssign;

				case PsiTokenType.ASSIGN: return PsiOperator.SemanticAssign;

				case PsiTokenType.WB_ASR: return PsiOperator.WritebackArithmeticShiftRight;

				case PsiTokenType.WB_SHL: return PsiOperator.WritebackShiftLeft;

				case PsiTokenType.WB_SHR: return PsiOperator.WritebackShiftRight;

				case PsiTokenType.WB_PLUS: return PsiOperator.WritebackPlus;

				case PsiTokenType.WB_MINUS: return PsiOperator.WritebackMinus;

				case PsiTokenType.WB_CONCAT: return PsiOperator.WritebackConcat;

				case PsiTokenType.WB_MULT: return PsiOperator.WritebackMultiply;

				case PsiTokenType.WB_DIV: return PsiOperator.WritebackDivide;

				case PsiTokenType.WB_MOD: return PsiOperator.WritebackModulo;

				case PsiTokenType.WB_EXP: return PsiOperator.WritebackExponentiate;

				case PsiTokenType.WB_INVERT: return PsiOperator.WritebackInvert;

				case PsiTokenType.WB_AND: return PsiOperator.WritebackAnd;

				case PsiTokenType.WB_OR: return PsiOperator.WritebackOr;

				case PsiTokenType.WB_XOR: return PsiOperator.WritebackXor;

				case PsiTokenType.LEQUAL: return PsiOperator.LessOrEqual;

				case PsiTokenType.GEQUAL: return PsiOperator.MoreOrEqual;

				case PsiTokenType.EQUAL: return PsiOperator.Equals;

				case PsiTokenType.NEQUAL: return PsiOperator.NotEquals;

				case PsiTokenType.LESS: return PsiOperator.Less;

				case PsiTokenType.MORE: return PsiOperator.More;

				default: return null;
			}
		}
		
		public static string ToString(PsiOperator op)
		{
			switch(op)
			{

				case PsiOperator.Dot: return ".";

				case PsiOperator.Meta: return "'";

				case PsiOperator.Invert: return "~";

				case PsiOperator.New: return "new";

				case PsiOperator.ArithmeticShiftRight: return ">>>";

				case PsiOperator.ShiftLeft: return "<<";

				case PsiOperator.ShiftRight: return ">>";

				case PsiOperator.Plus: return "+";

				case PsiOperator.Minus: return "-";

				case PsiOperator.Concat: return "--";

				case PsiOperator.Multiply: return "*";

				case PsiOperator.Divide: return "/";

				case PsiOperator.Modulo: return "%";

				case PsiOperator.Exponentiate: return "**";

				case PsiOperator.And: return "&";

				case PsiOperator.Or: return "|";

				case PsiOperator.Xor: return "^";

				case PsiOperator.Forward: return "->";

				case PsiOperator.Backward: return "<-";

				case PsiOperator.CopyAssign: return "=";

				case PsiOperator.SemanticAssign: return ":=";

				case PsiOperator.WritebackArithmeticShiftRight: return ">>>=";

				case PsiOperator.WritebackShiftLeft: return "<<=";

				case PsiOperator.WritebackShiftRight: return ">>=";

				case PsiOperator.WritebackPlus: return "+=";

				case PsiOperator.WritebackMinus: return "-=";

				case PsiOperator.WritebackConcat: return "--=";

				case PsiOperator.WritebackMultiply: return "*=";

				case PsiOperator.WritebackDivide: return "/=";

				case PsiOperator.WritebackModulo: return "%=";

				case PsiOperator.WritebackExponentiate: return "**=";

				case PsiOperator.WritebackInvert: return "~=";

				case PsiOperator.WritebackAnd: return "&=";

				case PsiOperator.WritebackOr: return "|=";

				case PsiOperator.WritebackXor: return "^=";

				case PsiOperator.LessOrEqual: return "<=";

				case PsiOperator.MoreOrEqual: return ">=";

				case PsiOperator.Equals: return "==";

				case PsiOperator.NotEquals: return "!=";

				case PsiOperator.Less: return "<";

				case PsiOperator.More: return ">";

				default: return null;
			}
		}
	}
}

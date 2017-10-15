using System;
using CompilerKit;

namespace PsiCompiler.Grammar
{
	public class ParserNode
	{
		public readonly Token<PsiTokenType> Token;
		public readonly Expression Expression;
		public readonly Module Module;
		public readonly Assertion Assertion;

		public ParserNode(Token<PsiTokenType> token)
		{
			this.Token = token.NotNull();
		}

		public ParserNode(Expression expression)
		{
			this.Expression = expression.NotNull();
		}

		public ParserNode(Module module)
		{
			this.Module = module.NotNull();
		}

		public ParserNode(Assertion assertion)
		{
			this.Assertion = assertion.NotNull();
		}
	}
}

using System;
using CompilerKit;

namespace PsiCompiler
{
	public class ParserNode
	{
		public readonly int Value;

		public readonly Token<PsiTokenType> Token;

		public ParserNode(int value)
		{
			this.Value = value;
		}
		
		public ParserNode(Token<PsiTokenType> token)
		{
			this.Token = token;
		}
	}
}

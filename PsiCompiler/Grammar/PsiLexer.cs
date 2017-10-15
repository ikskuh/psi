using System;
using System.IO;
using QUT.Gppg;

namespace PsiCompiler
{
	/*
	 * Copied from GPPG documentation.
	 */
	public sealed class PsiLexer : AbstractScanner<ParserNode, LexLocation>, IDisposable
	{
		private readonly PsiTokenizer tokenizer;

		//
		// Version 1.2.0 needed the following code.
		// In V1.2.1 the base class provides this empty default.
		//
		// public override LexLocation yylloc { 
		//     get { return null; } 
		//     set { /* skip */; }
		// }
		//

		public PsiLexer(System.IO.TextReader reader, string fileName)
		{
			this.tokenizer = new PsiTokenizer(reader, fileName);
		}

		public PsiLexer(string fileName)
		{
			this.tokenizer = new PsiTokenizer(new StreamReader(fileName), fileName, true);
		}

		~PsiLexer()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			this.tokenizer.Dispose();
		}

		public override int yylex()
		{
			if (this.tokenizer.EndOfText)
				return (int)PsiTokenType.EOF;

			var token = this.tokenizer.Read();

			Console.WriteLine("{0}", token);

			this.yylval = new ParserNode(token);

			return (int)token.Type;
		}

		public override void yyerror(string format, params object[] args)
		{
			Console.Error.WriteLine(format, args);
		}
	}
}

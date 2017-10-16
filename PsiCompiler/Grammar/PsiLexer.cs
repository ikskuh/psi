using System;
using System.IO;
using QUT.Gppg;

namespace PsiCompiler.Grammar
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

            if (Trace)
                Console.WriteLine(token.ToString(), "Lexer");

			var op = Converter.ToOperator(token);

			if (op != null)
				this.yylval = new ParserNode(op);
			else
				this.yylval = new ParserNode(token.Text);

			return (int)token.Type;
		}

		public override void yyerror(string format, params object[] args)
		{
			Console.Error.WriteLine(format, args);
		}
		
		public bool Trace
		{
			get { return this.tokenizer.TraceTokens; }
			set { this.tokenizer.TraceTokens = value; }
		}
		
		public bool TraceAll
		{
			get { return this.tokenizer.TraceIgnoredTokens; }
			set { this.tokenizer.TraceIgnoredTokens = value; }
		}
	}
}

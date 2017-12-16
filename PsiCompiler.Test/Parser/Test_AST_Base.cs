using System;
using System.IO;
using Psi.Compiler.Grammar;

namespace Psi.Compiler.Test
{
	public abstract class Test_AST_Base
	{
		protected static Module Load(string source)
		{
			using (var lexer = new PsiLexer(new StringReader(source), "???"))
			{
				var parser = new PsiParser(lexer);
				var success = parser.Parse();
				if (success)
					return parser.Result;
				else
					return null;
			}
		}
	}
}

using System;
using System.IO;

namespace PsiCompiler
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			using (var lexer = new PsiLexer("/home/felix/projects/psilang/Sources/CompilerTest.psi"))
			{
				var parser = new PsiParser(lexer);

				Console.WriteLine("Success: {0}", parser.Parse());
			}
		}
	}
}

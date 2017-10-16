using System;
using System.IO;

namespace PsiCompiler
{
	using PsiCompiler.Grammar;
    using System.Diagnostics;

    class MainClass
	{
		public static void Main(string[] args)
		{
			var module = Load("../../../Sources/CompilerTest.psi");

			if (module != null)
			{
				var printer = new ModulePrinter(Console.Out);
				printer.Print(module);
			}
			else
			{
				Console.WriteLine("Failed to parse!");
			}

            if (Debugger.IsAttached)
                Console.ReadLine();
		}

		private static Module Load(string fileName)
		{
			using (var lexer = new PsiLexer(fileName))
            {
                lexer.Trace = true;

                var parser = new PsiParser(lexer);

				var success = parser.Parse();
				if (success)
					return parser.Result;
				else
					return null;
			}
		}

		private static Module LoadSource(string fileName, string source)
		{
			using (var lexer = new PsiLexer(new StringReader(source), fileName))
			{
                lexer.Trace = true;

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

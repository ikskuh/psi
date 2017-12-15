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

            if (Debugger.IsAttached && Environment.OSVersion.Platform != PlatformID.Unix)
                Console.ReadLine();
		}

		private static Module Load(string fileName)
		{
			using (var lexer = new PsiLexer(fileName))
            {
                var parser = new PsiParser(lexer);

				var success = parser.Parse();

				if (success)
					return parser.Result;
                Console.WriteLine("Line: {0}", lexer.yylloc.StartLine);
				return null;
			}
		}

	}
}

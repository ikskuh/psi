using System;
using System.IO;

namespace Psi.Compiler
{
	using Psi.Compiler.Grammar;
    using Psi.Compiler.Intermediate;
    using System.Diagnostics;

	class MainClass
	{
		public static void Main(string[] args)
		{
            var std = CreateStd();
			var module = Load("../../../Sources/CompilerTest.psi");

			if (module != null)
			{
				var printer = new ModulePrinter(Console.Out);
				printer.Print(module);
                
                var globalScope = new SimpleScope
                {
                    new Symbol(IntermediateType.ModuleType, "std")
                    {
                        Initializer = new Literal<Intermediate.Module>(std),
                        IsConst = true,
                        IsExported = false
                    }
                };

                var astConverter = new ASTConverter(globalScope);
                astConverter.AddModule(module);
                astConverter.Convert();

                var output = astConverter.GetModule(module);
			}
			else
			{
				Console.WriteLine("Failed to parse!");
			}

			if (Debugger.IsAttached && Environment.OSVersion.Platform != PlatformID.Unix)
				Console.ReadLine();
		}

		private static Grammar.Module Load(string fileName)
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

        private static Intermediate.Module CreateStd()
        {
            var t_int = new BuiltinType("int");
            var t_char = new BuiltinType("char");
            var t_string = new ArrayType { ElementType = t_char, Dimensions = 1 };


            var std = new Intermediate.Module(null, "std");
            std.AddType("int", t_int, true);
            std.AddType("char", t_char, true);
            std.AddType("string", t_string, true);

            var compiler = new Intermediate.Module(std, "compiler");
            compiler.AddType("type", IntermediateType.MetaType, true);
            compiler.AddType("void", IntermediateType.VoidType, true);
            compiler.AddType("module", IntermediateType.ModuleType, true);
            std.AddModule("compiler", compiler);

            return std;
        }
	}
}

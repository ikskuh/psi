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
            // primitives
            TypeMapper.Add(typeof(bool), BuiltinType.Boolean);
            TypeMapper.Add(typeof(int), BuiltinType.Integer);
            TypeMapper.Add(typeof(double), BuiltinType.Real);
            TypeMapper.Add(typeof(string), BuiltinType.String);
            TypeMapper.Add(typeof(char), BuiltinType.Character); // TODO: this is wrong for now, but works. replace with int32 later!

            // required types
            TypeMapper.Add(typeof(void), Type.VoidType);
            TypeMapper.Add(typeof(Type), Type.MetaType);
            TypeMapper.Add(typeof(Intermediate.Module), Type.ModuleType);


            var std = CreateStd();
			var module = Load("../../../Sources/CompilerTest.psi");

			if (module != null)
			{
				var printer = new ModulePrinter(Console.Out);
				printer.Print(module);
                
                var globalScope = new SimpleScope
                {
                    new Symbol(Type.ModuleType, "std")
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
            var std = new Intermediate.Module(null, "std");
            std.AddType("bool", BuiltinType.Boolean, true);
            std.AddType("int", BuiltinType.Integer, true);
            std.AddType("char", BuiltinType.Character, true);
            std.AddType("real", BuiltinType.Real, true);
            std.AddType("string", BuiltinType.String, true);

            std.AddConst("true", BuiltinType.Boolean, new Literal<bool>(true), true);
            std.AddConst("false", BuiltinType.Boolean, new Literal<bool>(false), true);

            var compiler = new Intermediate.Module(std, "compiler");
            compiler.AddType("type", Type.MetaType, true);
            compiler.AddType("void", Type.VoidType, true);
            compiler.AddType("module", Type.ModuleType, true);
            std.AddModule("compiler", compiler);

            var math = new Intermediate.Module(std, "math");

            math.AddConst("pi", BuiltinType.Real, new Literal<double>(3.14159265358979323846), true);
            math.AddConst("e",  BuiltinType.Real, new Literal<double>(2.71828182845904523536), true);

            std.AddModule("math", math);

            return std;
        }
	}
}

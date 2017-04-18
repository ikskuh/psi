using System;
using midend.AbstractSyntaxTree;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace midend
{
	using NLua;

	class MainClass
	{
		public static void Main(string[] args)
		{
			if (Debugger.IsAttached)
			{
				Console.SetIn(new StreamReader("/tmp/foobar.xml", Encoding.ASCII));
			}

			var ast = AST.Load(Console.In);

			AST.Store(Console.Out, ast);

			Console.WriteLine();


			var modBuiltin = new Module();
			modBuiltin.Variables.Add(new Signature(new SymbolName("string"), CType.Type), new Variable
			{
				IsConst = true,
				IsExported = true,
				Type = CType.Type,
				InitialValue = Expression.Constant(CType.String),
			});
		}
	}
}
using System;
using midend.AbstractSyntaxTree;

namespace midend
{
	using NLua;

	class MainClass
	{
		public static void Main(string[] args)
		{
			var ast = AST.Load(Console.In);

			AST.Store(Console.Out, ast);
			
			Console.WriteLine();
		}
	}
}

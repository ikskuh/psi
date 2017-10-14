using System;
using CompilerKit;
namespace PsiCompiler
{
	partial class PsiParser
	{
		public void Parse()
		{
			while (!EndOfText)
			{
				var decl = ReadDeclaration();
			}
		}

		object ReadDeclaration()
		{
			throw new NotImplementedException();
		}
}
}

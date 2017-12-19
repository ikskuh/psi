using System;
using NUnit.Framework;
using Psi.Compiler.Grammar;

namespace Psi.Compiler.Test
{
	[TestFixture]
	public class Test_AST_Declarations : Test_AST_Base
	{
		[Test]
		public void BlankModule()
		{
			var module = Load("");
			Assert.NotNull(module);
			Assert.IsNull(module.Name);
			Assert.NotNull(module.Assertions);
			Assert.NotNull(module.Submodules);
			Assert.NotNull(module.Declarations);
			
			Assert.AreEqual(0, module.Assertions.Count);
			Assert.AreEqual(0, module.Submodules.Count);
			Assert.AreEqual(0, module.Declarations.Count);
		}

		[Test]
		public void DeclarationConstNoType()
		{
			var module = Load("const name = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsFalse(decl.IsExported);
			Assert.IsTrue(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Value);
			Assert.AreSame(decl.Type, PsiParser.Undefined);

			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);
		}
		
		[Test]
		public void DeclarationVarNoType()
		{
			var module = Load("var name = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsFalse(decl.IsExported);
			Assert.IsFalse(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Value);
			Assert.AreSame(decl.Type, PsiParser.Undefined);

			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);
		}

		[Test]
		public void DeclarationConstOnlyType()
		{
			var module = Load("const name : string;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsFalse(decl.IsExported);
			Assert.IsTrue(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.IsNull(decl.Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void DeclarationVarOnlyType()
		{
			var module = Load("var name : string;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsFalse(decl.IsExported);
			Assert.IsFalse(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.IsNull(decl.Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void DeclarationConst()
		{
			var module = Load("const name : string = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsFalse(decl.IsExported);
			Assert.IsTrue(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.NotNull(decl.Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void DeclarationVar()
		{
			var module = Load("var name : string = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsFalse(decl.IsExported);
			Assert.IsFalse(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.NotNull(decl.Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void ExportedDeclarationConstNoType()
		{
			var module = Load("export const name = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsTrue(decl.IsExported);
			Assert.IsTrue(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Value);
			Assert.AreSame(decl.Type, PsiParser.Undefined);

			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);
		}
		
		[Test]
		public void ExportedDeclarationVarNoType()
		{
			var module = Load("export var name = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsTrue(decl.IsExported);
			Assert.IsFalse(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Value);
			Assert.AreSame(decl.Type, PsiParser.Undefined);

			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);
		}

		[Test]
		public void ExportedDeclarationConstOnlyType()
		{
			var module = Load("export const name : string;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsTrue(decl.IsExported);
			Assert.IsTrue(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.IsNull(decl.Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void ExportedDeclarationVarOnlyType()
		{
			var module = Load("export var name : string;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsTrue(decl.IsExported);
			Assert.IsFalse(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.IsNull(decl.Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void ExportedDeclarationConst()
		{
			var module = Load("export const name : string = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsTrue(decl.IsExported);
			Assert.IsTrue(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.NotNull(decl.Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}

		[Test]
		public void ExportedDeclarationVar()
		{
			var module = Load("export var name : string = 10;");
			Assert.AreEqual(1, module.Declarations.Count);

			var decl = module.Declarations[0];
			Assert.IsTrue(decl.IsExported);
			Assert.IsFalse(decl.IsConst);
			Assert.AreEqual("name", decl.Name);
			Assert.NotNull(decl.Type);
			Assert.NotNull(decl.Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), decl.Value);
			Assert.AreEqual("10", ((NumberLiteral)decl.Value).Value);

			Assert.IsInstanceOf(typeof(NamedTypeLiteral), decl.Type);
			Assert.AreEqual("string", ((NamedTypeLiteral)decl.Type).Name.ToString());
		}


		[Test]
		public void DeclarationOptionalTerminator()
		{
			Module module;
			
			module = Load("const name = 10;");
			Assert.AreEqual(1, module.Declarations.Count);
			
			module = Load("const name = 10");
			Assert.AreEqual(1, module.Declarations.Count);
		}
	}
}

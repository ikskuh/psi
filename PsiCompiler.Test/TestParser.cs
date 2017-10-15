using NUnit.Framework;
using System;
using PsiCompiler.Grammar;
using System.IO;

namespace PsiCompiler.Test
{
	[TestFixture]
	public class TestParser
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
			Assert.IsNull(decl.Type);

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
			Assert.IsNull(decl.Type);

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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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
			Assert.IsNull(decl.Type);

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
			Assert.IsNull(decl.Type);

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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

			Assert.IsInstanceOf(typeof(VariableReference), decl.Type);
			Assert.AreEqual("string", ((VariableReference)decl.Type).Variable);
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

		[Test]
		public void Assertion()
		{
			var module = Load("assert 10;");
			Assert.AreEqual(1, module.Assertions.Count);
			
			var ass = module.Assertions[0];
			Assert.NotNull(ass);
			Assert.NotNull(ass.Expression);

			Assert.IsInstanceOf(typeof(NumberLiteral), ass.Expression);
			Assert.AreEqual("10", ((NumberLiteral)ass.Expression).Value);
		}
		
		[Test]
		public void SubmoduleEmpty()
		{
			var module = Load("module simple { }");
			Assert.AreEqual(1, module.Submodules.Count);

			var sub = module.Submodules[0];
			Assert.NotNull(sub);
			Assert.NotNull(sub.Name);
			Assert.AreEqual(1, sub.Name.Count);
			Assert.AreEqual("simple", sub.Name[0]);
			Assert.AreEqual(0, sub.Submodules.Count);
			Assert.AreEqual(0, sub.Assertions.Count);
			Assert.AreEqual(0, sub.Declarations.Count);
		}
		
		[Test]
		public void SubmoduleCompoundName()
		{
			var module = Load("module fancy.triple.name { }");
			Assert.AreEqual(1, module.Submodules.Count);

			var sub = module.Submodules[0];
			Assert.NotNull(sub.Name);
			Assert.AreEqual(3, sub.Name.Count);
			Assert.AreEqual("fancy", sub.Name[0]);
			Assert.AreEqual("triple", sub.Name[1]);
			Assert.AreEqual("name", sub.Name[2]);
		}
		
		[Test]
		public void SubmoduleContent()
		{
			var module = Load("module simple { assert 10; }");
			Assert.AreEqual(1, module.Submodules.Count);

			var sub = module.Submodules[0];
			Assert.AreEqual(1, sub.Assertions.Count);

			var ass = sub.Assertions[0];
			Assert.IsNotNull(ass);
			Assert.IsInstanceOf(typeof(NumberLiteral), ass.Expression);
			Assert.AreEqual("10", ((NumberLiteral)ass.Expression).Value);
		}
		
		[Test]
		public void SingleLineCommentIsIgnored()
		{
			var module = Load("// Foo");
			Assert.AreEqual(0, module.Submodules.Count);
			Assert.AreEqual(0, module.Assertions.Count);
			Assert.AreEqual(0, module.Declarations.Count);
			
			module = Load("assert 10;// Foo\nassert 10;");
			Assert.AreEqual(0, module.Submodules.Count);
			Assert.AreEqual(2, module.Assertions.Count);
			Assert.AreEqual(0, module.Declarations.Count);
		}
		
		[Test]
		public void MultiLineCommentIsIgnored()
		{
			var module = Load("/* Foo */");
			Assert.AreEqual(0, module.Submodules.Count);
			Assert.AreEqual(0, module.Assertions.Count);
			Assert.AreEqual(0, module.Declarations.Count);
			
			module = Load("assert 10; /* Foo */ assert 10;");
			Assert.AreEqual(0, module.Submodules.Count);
			Assert.AreEqual(2, module.Assertions.Count);
			Assert.AreEqual(0, module.Declarations.Count);
		}
		
		// TODO: Test all expression/literal types

		private static Module Load(string source)
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

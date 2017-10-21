using System;
using NUnit.Framework;
using PsiCompiler.Grammar;

namespace PsiCompiler.Test
{
	[TestFixture]
	public class Test_AST : Test_AST_Base
	{
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
	}
}

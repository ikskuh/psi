using System;
using System.Collections.Generic;
using NUnit.Framework;
using PsiCompiler.Grammar;

namespace PsiCompiler.Test
{
	[TestFixture]
	public class Test_AST_Expressions : Test_AST_Base
	{
		[Test]
		public void NumericLiteralExpression()
		{
			Module module;
			Expression expression;

			module = Load("const name = 10;");
			expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(NumberLiteral), expression);
			Assert.AreEqual("10", ((NumberLiteral)expression).Value);
			
			//--
			
			module = Load("const name = 25.0;");
			expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(NumberLiteral), expression);
			Assert.AreEqual("25.0", ((NumberLiteral)expression).Value);
			
			//-- 
			
			module = Load("const name = 0xab007f;");
			expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(NumberLiteral), expression);
			Assert.AreEqual("0xab007f", ((NumberLiteral)expression).Value);
		}
		
		[Test]
		public void StringLiteralExpression()
		{
			Module module;
			Expression expression;

			module = Load("const name = \"Hallo, Welt!\";");
			expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(StringLiteral), expression);
			Assert.AreEqual("Hallo, Welt!", ((StringLiteral)expression).Text);
		}
		
		[Test]
		public void StringEscapeSequencesExpression()
		{
			Module module;
			Expression expression;

			var items = new Dictionary<string, string>
			{
				{ "a",   "\x07" },
				{ "b",   "\x08" },
				{ "f",   "\x0C" },
				{ "n",   "\x0A" },
				{ "r",   "\x0D" },
				{ "t",   "\x09" },
				{ "v",   "\x0B" },
				{ "\\",  "\x5C" },
				{ "'",   "\x27" },
				{ "\"",  "\x22" },
				{ "e",   "\x1B" },
				{ "123", "\x53" },
				{ "356", "\xEE" },
				{ "277", "\xBF" },
				{ "x53", "\x53" },
				{ "xEE", "\xEE" },
				{ "xFF", "\xFF" },
				{ "u1234", "\u1234" },
				{ "U00105678", char.ConvertFromUtf32(0x105678) },
			};

			foreach (var escape in items)
			{
				var code = string.Format("const name = \"\\{0}\";", escape.Key);
				Console.WriteLine("{0}", code);
				module = Load(code);
				expression = module.Declarations[0].Value;

				Assert.AreEqual(
					escape.Value, 
					((StringLiteral)expression).Text,
					"Invalid escaped sequence: {0}", escape.Key);
			}
		}
		
		[Test]
		public void EnumLiteralExpression()
		{
			Module module;
			Expression expression;

			module = Load("const name = :literal;");
			expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(EnumLiteral), expression);
			Assert.AreEqual("literal", ((EnumLiteral)expression).Name);

			module = Load("const name = :check_box;");
			expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(EnumLiteral), expression);
			Assert.AreEqual("check_box", ((EnumLiteral)expression).Name);
		}
		
		[Test]
		public void VariableExpression()
		{
			var module = Load("const name = foo;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(VariableReference), expression);
			Assert.AreEqual("foo", ((VariableReference)expression).Variable);
		}
		
		[Test]
		public void ArrayLiteralExpression()
		{
			var module = Load("const name = [ 0, 1, 2 ];");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(ArrayLiteral), expression);

			var array = (ArrayLiteral)expression;
			
			Assert.AreEqual(3, array.Values.Count);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), array.Values[0]);
			Assert.AreEqual("0", ((NumberLiteral)array.Values[0]).Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), array.Values[1]);
			Assert.AreEqual("1", ((NumberLiteral)array.Values[1]).Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), array.Values[2]);
			Assert.AreEqual("2", ((NumberLiteral)array.Values[2]).Value);
		}
		
		[Test]
		public void DotSubscriptOperator()
		{
			var module = Load("const name = foo.bar;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(DotExpression), expression);
			Assert.AreEqual("bar", ((DotExpression)expression).FieldName);
			Assert.IsInstanceOf(typeof(VariableReference), ((DotExpression)expression).Object);
		}
		
		[Test]
		public void MetaSubscriptOperator()
		{
			var module = Load("const name = foo'bar;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(MetaExpression), expression);
			Assert.AreEqual("bar", ((MetaExpression)expression).FieldName);
			Assert.IsInstanceOf(typeof(VariableReference), ((MetaExpression)expression).Object);
		}
		
		[Test]
		public void EmptyArrayIndexerExpression()
		{
			var module = Load("const name = foo[];");
			Assert.IsNull(module);
		}
		
		[Test]
		public void SingleArrayIndexerExpression()
		{
			var module = Load("const name = foo[0];");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(ArrayIndexingExpression), expression);
			var indexer = (ArrayIndexingExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), indexer.Value);
			Assert.AreEqual("foo", ((VariableReference)indexer.Value).Variable);

			Assert.AreEqual(1, indexer.Indices.Count);
			Assert.IsInstanceOf(typeof(NumberLiteral), indexer.Indices[0]);
			Assert.AreEqual("0", ((NumberLiteral)indexer.Indices[0]).Value);
		}
		
		[Test]
		public void MultipleArrayIndexerExpression()
		{
			var module = Load("const name = foo[0, 1, 2];");
			var expression = module.Declarations[0].Value;
			var indexer = (ArrayIndexingExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), indexer.Value);
			Assert.AreEqual("foo", ((VariableReference)indexer.Value).Variable);

			Assert.AreEqual(3, indexer.Indices.Count);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), indexer.Indices[0]);
			Assert.AreEqual("0", ((NumberLiteral)indexer.Indices[0]).Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), indexer.Indices[1]);
			Assert.AreEqual("1", ((NumberLiteral)indexer.Indices[1]).Value);
			
			Assert.IsInstanceOf(typeof(NumberLiteral), indexer.Indices[2]);
			Assert.AreEqual("2", ((NumberLiteral)indexer.Indices[2]).Value);
		}
		
		// TODO: Test for function literals
		
		// TODO: Test for lambda literals
	}
}

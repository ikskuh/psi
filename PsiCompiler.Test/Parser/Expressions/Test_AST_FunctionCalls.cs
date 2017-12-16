using System;
using System.Collections.Generic;
using NUnit.Framework;
using Psi.Compiler;
using Psi.Compiler.Grammar;
using System.Linq;

namespace Psi.Compiler.Test
{
	[TestFixture]
	public class Test_AST_FunctionCalls : Test_AST_Base
	{
		[Test]
		public void TrivialFunctionCall()
		{
			var module = Load("const name = f();");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(FunctionCallExpression), expression);
			var call = (FunctionCallExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), call.Value);
			Assert.AreEqual("f", ((VariableReference)call.Value).Variable);

			Assert.AreEqual(0, call.Arguments.Count());
		}
		
		[Test]
		public void SinglePositionalArgumentFunctionCall()
		{
			var module = Load("const name = f(1);");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(FunctionCallExpression), expression);
			var call = (FunctionCallExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), call.Value);
			Assert.AreEqual("f", ((VariableReference)call.Value).Variable);
			
			Assert.AreEqual(1, call.Arguments.Count());
			Assert.IsInstanceOf(typeof(PositionalArgument), call.Arguments.ElementAt(0));
			Assert.IsInstanceOf(typeof(NumberLiteral), ((PositionalArgument)call.Arguments.ElementAt(0)).Value);
		}
		
		[Test]
		public void MultiplePositionalArgumentFunctionCall()
		{
			var module = Load("const name = f(1,\"foo\",bar);");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(FunctionCallExpression), expression);
			var call = (FunctionCallExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), call.Value);
			Assert.AreEqual("f", ((VariableReference)call.Value).Variable);
			
			Assert.AreEqual(3, call.Arguments.Count());
			Assert.IsInstanceOf(typeof(PositionalArgument), call.Arguments.ElementAt(0));
			Assert.IsInstanceOf(typeof(NumberLiteral), ((PositionalArgument)call.Arguments.ElementAt(0)).Value);
			
			Assert.IsInstanceOf(typeof(PositionalArgument), call.Arguments.ElementAt(1));
			Assert.IsInstanceOf(typeof(StringLiteral), ((PositionalArgument)call.Arguments.ElementAt(1)).Value);
			
			Assert.IsInstanceOf(typeof(PositionalArgument), call.Arguments.ElementAt(2));
			Assert.IsInstanceOf(typeof(VariableReference), ((PositionalArgument)call.Arguments.ElementAt(2)).Value);
		}
		
		[Test]
		public void SingleNamedArgumentFunctionCall()
		{
			var module = Load("const name = f(foo: 1);");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(FunctionCallExpression), expression);
			var call = (FunctionCallExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), call.Value);
			Assert.AreEqual("f", ((VariableReference)call.Value).Variable);
			
			Assert.AreEqual(1, call.Arguments.Count());
			Assert.IsInstanceOf(typeof(NamedArgument), call.Arguments.ElementAt(0));
			Assert.AreEqual("foo", ((NamedArgument)call.Arguments.ElementAt(0)).Name);
			Assert.IsInstanceOf(typeof(NumberLiteral), ((NamedArgument)call.Arguments.ElementAt(0)).Value);
		}
		
		[Test]
		public void MultipleNamedArgumentFunctionCall()
		{
			var module = Load("const name = f(foo: 1, bar: bam);");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(FunctionCallExpression), expression);
			var call = (FunctionCallExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), call.Value);
			Assert.AreEqual("f", ((VariableReference)call.Value).Variable);
			
			Assert.AreEqual(2, call.Arguments.Count());
			
			Assert.IsInstanceOf(typeof(NamedArgument), call.Arguments.ElementAt(0));
			Assert.AreEqual("foo", ((NamedArgument)call.Arguments.ElementAt(0)).Name);
			Assert.IsInstanceOf(typeof(NumberLiteral), ((NamedArgument)call.Arguments.ElementAt(0)).Value);
			
			Assert.IsInstanceOf(typeof(NamedArgument), call.Arguments.ElementAt(1));
			Assert.AreEqual("bar", ((NamedArgument)call.Arguments.ElementAt(1)).Name);
			Assert.IsInstanceOf(typeof(VariableReference), ((NamedArgument)call.Arguments.ElementAt(1)).Value);
		}
		
		[Test]
		public void MixedArgumentFunctionCall()
		{
			var module = Load("const name = f(1, bar: bam);");
			var expression = module.Declarations[0].Value;
			
			Assert.IsInstanceOf(typeof(FunctionCallExpression), expression);
			var call = (FunctionCallExpression)expression;

			Assert.IsInstanceOf(typeof(VariableReference), call.Value);
			Assert.AreEqual("f", ((VariableReference)call.Value).Variable);
			
			Assert.AreEqual(2, call.Arguments.Count());
			
			Assert.IsInstanceOf(typeof(PositionalArgument), call.Arguments.ElementAt(0));
			Assert.IsInstanceOf(typeof(NumberLiteral), ((PositionalArgument)call.Arguments.ElementAt(0)).Value);
			
			Assert.IsInstanceOf(typeof(NamedArgument), call.Arguments.ElementAt(1));
			Assert.AreEqual("bar", ((NamedArgument)call.Arguments.ElementAt(1)).Name);
			Assert.IsInstanceOf(typeof(VariableReference), ((NamedArgument)call.Arguments.ElementAt(1)).Value);
		}
	}
}

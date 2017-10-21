﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using PsiCompiler.Grammar;

namespace PsiCompiler.Test
{
	[TestFixture]
	public class Test_AST_UnaryExpressions : Test_AST_Base
	{
		[Test]
		public void UnaryOperatorExpression_Plus()
		{
			var module = Load("const name = + 10;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(UnaryOperation), expression);
			var op = (UnaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(NumberLiteral), op.Operand);
			Assert.AreEqual("10", ((NumberLiteral)op.Operand).Value);
		}

		[Test]
		public void UnaryOperatorExpression_Minus()
		{
			var module = Load("const name = - 10;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(UnaryOperation), expression);
			var op = (UnaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(NumberLiteral), op.Operand);
			Assert.AreEqual("10", ((NumberLiteral)op.Operand).Value);
		}

		[Test]
		public void UnaryOperatorExpression_Invert()
		{
			var module = Load("const name = ~ 10;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(UnaryOperation), expression);
			var op = (UnaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Invert, op.Operator);
			Assert.IsInstanceOf(typeof(NumberLiteral), op.Operand);
			Assert.AreEqual("10", ((NumberLiteral)op.Operand).Value);
		}

		[Test]
		public void UnaryOperatorExpression_New()
		{
			var module = Load("const name = new 10;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(UnaryOperation), expression);
			var op = (UnaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.New, op.Operator);
			Assert.IsInstanceOf(typeof(NumberLiteral), op.Operand);
			Assert.AreEqual("10", ((NumberLiteral)op.Operand).Value);
		}


	}
}


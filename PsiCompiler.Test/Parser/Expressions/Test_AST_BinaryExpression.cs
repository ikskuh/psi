﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Psi.Compiler.Grammar;

namespace Psi.Compiler.Test
{
	[TestFixture]
	public class Test_AST_BinaryExpressions : Test_AST_Base
	{
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight()
		{
			var module = Load("const name = a >>>= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft()
		{
			var module = Load("const name = a <<= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight()
		{
			var module = Load("const name = a >>= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus()
		{
			var module = Load("const name = a += b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus()
		{
			var module = Load("const name = a -= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat()
		{
			var module = Load("const name = a --= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply()
		{
			var module = Load("const name = a *= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide()
		{
			var module = Load("const name = a /= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo()
		{
			var module = Load("const name = a %= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate()
		{
			var module = Load("const name = a **= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd()
		{
			var module = Load("const name = a &= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr()
		{
			var module = Load("const name = a |= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor()
		{
			var module = Load("const name = a ^= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign()
		{
			var module = Load("const name = a = b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign()
		{
			var module = Load("const name = a := b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or()
		{
			var module = Load("const name = a | b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor()
		{
			var module = Load("const name = a ^ b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_And()
		{
			var module = Load("const name = a & b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals()
		{
			var module = Load("const name = a == b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals()
		{
			var module = Load("const name = a != b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual()
		{
			var module = Load("const name = a <= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual()
		{
			var module = Load("const name = a >= b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less()
		{
			var module = Load("const name = a < b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_More()
		{
			var module = Load("const name = a > b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward()
		{
			var module = Load("const name = a -> b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward()
		{
			var module = Load("const name = a <- b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus()
		{
			var module = Load("const name = a + b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus()
		{
			var module = Load("const name = a - b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat()
		{
			var module = Load("const name = a -- b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Multiply()
		{
			var module = Load("const name = a * b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Multiply, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Divide()
		{
			var module = Load("const name = a / b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Divide, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Modulo()
		{
			var module = Load("const name = a % b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Modulo, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_Exponentiate()
		{
			var module = Load("const name = a ** b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Exponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_ShiftLeft()
		{
			var module = Load("const name = a << b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.ShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_ShiftRight()
		{
			var module = Load("const name = a >> b;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.ShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(VariableReference), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(VariableReference), op.RightHandSide);
			
			Assert.AreEqual("a", ((VariableReference)op.LeftHandSide).Variable);
			Assert.AreEqual("b", ((VariableReference)op.RightHandSide).Variable);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Or()
		{
			var module = Load("const name = a | b >>>= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Or()
		{
			var module = Load("const name = a | b <<= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Or()
		{
			var module = Load("const name = a | b >>= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Or()
		{
			var module = Load("const name = a | b += c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Or()
		{
			var module = Load("const name = a | b -= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Or()
		{
			var module = Load("const name = a | b --= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Or()
		{
			var module = Load("const name = a | b *= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Or()
		{
			var module = Load("const name = a | b /= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Or()
		{
			var module = Load("const name = a | b %= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Or()
		{
			var module = Load("const name = a | b **= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Or()
		{
			var module = Load("const name = a | b &= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Or()
		{
			var module = Load("const name = a | b |= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Or()
		{
			var module = Load("const name = a | b ^= c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Or()
		{
			var module = Load("const name = a | b = c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Or()
		{
			var module = Load("const name = a | b := c | d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Or, lhs.Operator);
			Assert.AreEqual(PsiOperator.Or, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Xor()
		{
			var module = Load("const name = a ^ b >>>= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Xor()
		{
			var module = Load("const name = a ^ b <<= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Xor()
		{
			var module = Load("const name = a ^ b >>= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Xor()
		{
			var module = Load("const name = a ^ b += c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Xor()
		{
			var module = Load("const name = a ^ b -= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Xor()
		{
			var module = Load("const name = a ^ b --= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Xor()
		{
			var module = Load("const name = a ^ b *= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Xor()
		{
			var module = Load("const name = a ^ b /= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Xor()
		{
			var module = Load("const name = a ^ b %= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Xor()
		{
			var module = Load("const name = a ^ b **= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Xor()
		{
			var module = Load("const name = a ^ b &= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Xor()
		{
			var module = Load("const name = a ^ b |= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Xor()
		{
			var module = Load("const name = a ^ b ^= c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Xor()
		{
			var module = Load("const name = a ^ b = c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Xor()
		{
			var module = Load("const name = a ^ b := c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_And()
		{
			var module = Load("const name = a & b >>>= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_And()
		{
			var module = Load("const name = a & b <<= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_And()
		{
			var module = Load("const name = a & b >>= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_And()
		{
			var module = Load("const name = a & b += c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_And()
		{
			var module = Load("const name = a & b -= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_And()
		{
			var module = Load("const name = a & b --= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_And()
		{
			var module = Load("const name = a & b *= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_And()
		{
			var module = Load("const name = a & b /= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_And()
		{
			var module = Load("const name = a & b %= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_And()
		{
			var module = Load("const name = a & b **= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_And()
		{
			var module = Load("const name = a & b &= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_And()
		{
			var module = Load("const name = a & b |= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_And()
		{
			var module = Load("const name = a & b ^= c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_And()
		{
			var module = Load("const name = a & b = c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_And()
		{
			var module = Load("const name = a & b := c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Equals()
		{
			var module = Load("const name = a == b >>>= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_NotEquals()
		{
			var module = Load("const name = a != b >>>= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Equals()
		{
			var module = Load("const name = a == b <<= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_NotEquals()
		{
			var module = Load("const name = a != b <<= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Equals()
		{
			var module = Load("const name = a == b >>= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_NotEquals()
		{
			var module = Load("const name = a != b >>= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Equals()
		{
			var module = Load("const name = a == b += c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_NotEquals()
		{
			var module = Load("const name = a != b += c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Equals()
		{
			var module = Load("const name = a == b -= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_NotEquals()
		{
			var module = Load("const name = a != b -= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Equals()
		{
			var module = Load("const name = a == b --= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_NotEquals()
		{
			var module = Load("const name = a != b --= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Equals()
		{
			var module = Load("const name = a == b *= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_NotEquals()
		{
			var module = Load("const name = a != b *= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Equals()
		{
			var module = Load("const name = a == b /= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_NotEquals()
		{
			var module = Load("const name = a != b /= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Equals()
		{
			var module = Load("const name = a == b %= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_NotEquals()
		{
			var module = Load("const name = a != b %= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Equals()
		{
			var module = Load("const name = a == b **= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_NotEquals()
		{
			var module = Load("const name = a != b **= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Equals()
		{
			var module = Load("const name = a == b &= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_NotEquals()
		{
			var module = Load("const name = a != b &= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Equals()
		{
			var module = Load("const name = a == b |= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_NotEquals()
		{
			var module = Load("const name = a != b |= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Equals()
		{
			var module = Load("const name = a == b ^= c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_NotEquals()
		{
			var module = Load("const name = a != b ^= c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Equals()
		{
			var module = Load("const name = a == b = c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_NotEquals()
		{
			var module = Load("const name = a != b = c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Equals()
		{
			var module = Load("const name = a == b := c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_NotEquals()
		{
			var module = Load("const name = a != b := c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_LessOrEqual()
		{
			var module = Load("const name = a <= b >>>= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_MoreOrEqual()
		{
			var module = Load("const name = a >= b >>>= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Less()
		{
			var module = Load("const name = a < b >>>= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_More()
		{
			var module = Load("const name = a > b >>>= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_LessOrEqual()
		{
			var module = Load("const name = a <= b <<= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_MoreOrEqual()
		{
			var module = Load("const name = a >= b <<= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Less()
		{
			var module = Load("const name = a < b <<= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_More()
		{
			var module = Load("const name = a > b <<= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_LessOrEqual()
		{
			var module = Load("const name = a <= b >>= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_MoreOrEqual()
		{
			var module = Load("const name = a >= b >>= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Less()
		{
			var module = Load("const name = a < b >>= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_More()
		{
			var module = Load("const name = a > b >>= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_LessOrEqual()
		{
			var module = Load("const name = a <= b += c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_MoreOrEqual()
		{
			var module = Load("const name = a >= b += c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Less()
		{
			var module = Load("const name = a < b += c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_More()
		{
			var module = Load("const name = a > b += c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_LessOrEqual()
		{
			var module = Load("const name = a <= b -= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_MoreOrEqual()
		{
			var module = Load("const name = a >= b -= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Less()
		{
			var module = Load("const name = a < b -= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_More()
		{
			var module = Load("const name = a > b -= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_LessOrEqual()
		{
			var module = Load("const name = a <= b --= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_MoreOrEqual()
		{
			var module = Load("const name = a >= b --= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Less()
		{
			var module = Load("const name = a < b --= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_More()
		{
			var module = Load("const name = a > b --= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_LessOrEqual()
		{
			var module = Load("const name = a <= b *= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_MoreOrEqual()
		{
			var module = Load("const name = a >= b *= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Less()
		{
			var module = Load("const name = a < b *= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_More()
		{
			var module = Load("const name = a > b *= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_LessOrEqual()
		{
			var module = Load("const name = a <= b /= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_MoreOrEqual()
		{
			var module = Load("const name = a >= b /= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Less()
		{
			var module = Load("const name = a < b /= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_More()
		{
			var module = Load("const name = a > b /= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_LessOrEqual()
		{
			var module = Load("const name = a <= b %= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_MoreOrEqual()
		{
			var module = Load("const name = a >= b %= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Less()
		{
			var module = Load("const name = a < b %= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_More()
		{
			var module = Load("const name = a > b %= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_LessOrEqual()
		{
			var module = Load("const name = a <= b **= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_MoreOrEqual()
		{
			var module = Load("const name = a >= b **= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Less()
		{
			var module = Load("const name = a < b **= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_More()
		{
			var module = Load("const name = a > b **= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_LessOrEqual()
		{
			var module = Load("const name = a <= b &= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_MoreOrEqual()
		{
			var module = Load("const name = a >= b &= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Less()
		{
			var module = Load("const name = a < b &= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_More()
		{
			var module = Load("const name = a > b &= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_LessOrEqual()
		{
			var module = Load("const name = a <= b |= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_MoreOrEqual()
		{
			var module = Load("const name = a >= b |= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Less()
		{
			var module = Load("const name = a < b |= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_More()
		{
			var module = Load("const name = a > b |= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_LessOrEqual()
		{
			var module = Load("const name = a <= b ^= c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_MoreOrEqual()
		{
			var module = Load("const name = a >= b ^= c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Less()
		{
			var module = Load("const name = a < b ^= c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_More()
		{
			var module = Load("const name = a > b ^= c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_LessOrEqual()
		{
			var module = Load("const name = a <= b = c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_MoreOrEqual()
		{
			var module = Load("const name = a >= b = c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Less()
		{
			var module = Load("const name = a < b = c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_More()
		{
			var module = Load("const name = a > b = c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_LessOrEqual()
		{
			var module = Load("const name = a <= b := c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_MoreOrEqual()
		{
			var module = Load("const name = a >= b := c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Less()
		{
			var module = Load("const name = a < b := c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_More()
		{
			var module = Load("const name = a > b := c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Forward()
		{
			var module = Load("const name = a -> b >>>= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Backward()
		{
			var module = Load("const name = a <- b >>>= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Forward()
		{
			var module = Load("const name = a -> b <<= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Backward()
		{
			var module = Load("const name = a <- b <<= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Forward()
		{
			var module = Load("const name = a -> b >>= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Backward()
		{
			var module = Load("const name = a <- b >>= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Forward()
		{
			var module = Load("const name = a -> b += c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Backward()
		{
			var module = Load("const name = a <- b += c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Forward()
		{
			var module = Load("const name = a -> b -= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Backward()
		{
			var module = Load("const name = a <- b -= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Forward()
		{
			var module = Load("const name = a -> b --= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Backward()
		{
			var module = Load("const name = a <- b --= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Forward()
		{
			var module = Load("const name = a -> b *= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Backward()
		{
			var module = Load("const name = a <- b *= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Forward()
		{
			var module = Load("const name = a -> b /= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Backward()
		{
			var module = Load("const name = a <- b /= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Forward()
		{
			var module = Load("const name = a -> b %= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Backward()
		{
			var module = Load("const name = a <- b %= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Forward()
		{
			var module = Load("const name = a -> b **= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Backward()
		{
			var module = Load("const name = a <- b **= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Forward()
		{
			var module = Load("const name = a -> b &= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Backward()
		{
			var module = Load("const name = a <- b &= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Forward()
		{
			var module = Load("const name = a -> b |= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Backward()
		{
			var module = Load("const name = a <- b |= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Forward()
		{
			var module = Load("const name = a -> b ^= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Backward()
		{
			var module = Load("const name = a <- b ^= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Forward()
		{
			var module = Load("const name = a -> b = c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Backward()
		{
			var module = Load("const name = a <- b = c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Forward()
		{
			var module = Load("const name = a -> b := c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Backward()
		{
			var module = Load("const name = a <- b := c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Plus()
		{
			var module = Load("const name = a + b >>>= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Minus()
		{
			var module = Load("const name = a - b >>>= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Concat()
		{
			var module = Load("const name = a -- b >>>= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Plus()
		{
			var module = Load("const name = a + b <<= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Minus()
		{
			var module = Load("const name = a - b <<= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Concat()
		{
			var module = Load("const name = a -- b <<= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Plus()
		{
			var module = Load("const name = a + b >>= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Minus()
		{
			var module = Load("const name = a - b >>= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Concat()
		{
			var module = Load("const name = a -- b >>= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Plus()
		{
			var module = Load("const name = a + b += c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Minus()
		{
			var module = Load("const name = a - b += c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Concat()
		{
			var module = Load("const name = a -- b += c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Plus()
		{
			var module = Load("const name = a + b -= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Minus()
		{
			var module = Load("const name = a - b -= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Concat()
		{
			var module = Load("const name = a -- b -= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Plus()
		{
			var module = Load("const name = a + b --= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Minus()
		{
			var module = Load("const name = a - b --= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Concat()
		{
			var module = Load("const name = a -- b --= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Plus()
		{
			var module = Load("const name = a + b *= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Minus()
		{
			var module = Load("const name = a - b *= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Concat()
		{
			var module = Load("const name = a -- b *= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Plus()
		{
			var module = Load("const name = a + b /= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Minus()
		{
			var module = Load("const name = a - b /= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Concat()
		{
			var module = Load("const name = a -- b /= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Plus()
		{
			var module = Load("const name = a + b %= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Minus()
		{
			var module = Load("const name = a - b %= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Concat()
		{
			var module = Load("const name = a -- b %= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Plus()
		{
			var module = Load("const name = a + b **= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Minus()
		{
			var module = Load("const name = a - b **= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Concat()
		{
			var module = Load("const name = a -- b **= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Plus()
		{
			var module = Load("const name = a + b &= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Minus()
		{
			var module = Load("const name = a - b &= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Concat()
		{
			var module = Load("const name = a -- b &= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Plus()
		{
			var module = Load("const name = a + b |= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Minus()
		{
			var module = Load("const name = a - b |= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Concat()
		{
			var module = Load("const name = a -- b |= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Plus()
		{
			var module = Load("const name = a + b ^= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Minus()
		{
			var module = Load("const name = a - b ^= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Concat()
		{
			var module = Load("const name = a -- b ^= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Plus()
		{
			var module = Load("const name = a + b = c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Minus()
		{
			var module = Load("const name = a - b = c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Concat()
		{
			var module = Load("const name = a -- b = c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Plus()
		{
			var module = Load("const name = a + b := c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Minus()
		{
			var module = Load("const name = a - b := c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Concat()
		{
			var module = Load("const name = a -- b := c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Multiply()
		{
			var module = Load("const name = a * b >>>= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Divide()
		{
			var module = Load("const name = a / b >>>= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Modulo()
		{
			var module = Load("const name = a % b >>>= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Multiply()
		{
			var module = Load("const name = a * b <<= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Divide()
		{
			var module = Load("const name = a / b <<= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Modulo()
		{
			var module = Load("const name = a % b <<= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Multiply()
		{
			var module = Load("const name = a * b >>= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Divide()
		{
			var module = Load("const name = a / b >>= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Modulo()
		{
			var module = Load("const name = a % b >>= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Multiply()
		{
			var module = Load("const name = a * b += c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Divide()
		{
			var module = Load("const name = a / b += c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Modulo()
		{
			var module = Load("const name = a % b += c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Multiply()
		{
			var module = Load("const name = a * b -= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Divide()
		{
			var module = Load("const name = a / b -= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Modulo()
		{
			var module = Load("const name = a % b -= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Multiply()
		{
			var module = Load("const name = a * b --= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Divide()
		{
			var module = Load("const name = a / b --= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Modulo()
		{
			var module = Load("const name = a % b --= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Multiply()
		{
			var module = Load("const name = a * b *= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Divide()
		{
			var module = Load("const name = a / b *= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Modulo()
		{
			var module = Load("const name = a % b *= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Multiply()
		{
			var module = Load("const name = a * b /= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Divide()
		{
			var module = Load("const name = a / b /= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Modulo()
		{
			var module = Load("const name = a % b /= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Multiply()
		{
			var module = Load("const name = a * b %= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Divide()
		{
			var module = Load("const name = a / b %= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Modulo()
		{
			var module = Load("const name = a % b %= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Multiply()
		{
			var module = Load("const name = a * b **= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Divide()
		{
			var module = Load("const name = a / b **= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Modulo()
		{
			var module = Load("const name = a % b **= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Multiply()
		{
			var module = Load("const name = a * b &= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Divide()
		{
			var module = Load("const name = a / b &= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Modulo()
		{
			var module = Load("const name = a % b &= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Multiply()
		{
			var module = Load("const name = a * b |= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Divide()
		{
			var module = Load("const name = a / b |= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Modulo()
		{
			var module = Load("const name = a % b |= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Multiply()
		{
			var module = Load("const name = a * b ^= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Divide()
		{
			var module = Load("const name = a / b ^= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Modulo()
		{
			var module = Load("const name = a % b ^= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Multiply()
		{
			var module = Load("const name = a * b = c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Divide()
		{
			var module = Load("const name = a / b = c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Modulo()
		{
			var module = Load("const name = a % b = c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Multiply()
		{
			var module = Load("const name = a * b := c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Divide()
		{
			var module = Load("const name = a / b := c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Modulo()
		{
			var module = Load("const name = a % b := c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_Exponentiate()
		{
			var module = Load("const name = a ** b >>>= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_Exponentiate()
		{
			var module = Load("const name = a ** b <<= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_Exponentiate()
		{
			var module = Load("const name = a ** b >>= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_Exponentiate()
		{
			var module = Load("const name = a ** b += c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_Exponentiate()
		{
			var module = Load("const name = a ** b -= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_Exponentiate()
		{
			var module = Load("const name = a ** b --= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_Exponentiate()
		{
			var module = Load("const name = a ** b *= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_Exponentiate()
		{
			var module = Load("const name = a ** b /= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_Exponentiate()
		{
			var module = Load("const name = a ** b %= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_Exponentiate()
		{
			var module = Load("const name = a ** b **= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_Exponentiate()
		{
			var module = Load("const name = a ** b &= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_Exponentiate()
		{
			var module = Load("const name = a ** b |= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_Exponentiate()
		{
			var module = Load("const name = a ** b ^= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_Exponentiate()
		{
			var module = Load("const name = a ** b = c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_Exponentiate()
		{
			var module = Load("const name = a ** b := c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b >>>= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_ShiftLeft()
		{
			var module = Load("const name = a << b >>>= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackArithmeticShiftRight_ShiftRight()
		{
			var module = Load("const name = a >> b >>>= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackArithmeticShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b <<= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_ShiftLeft()
		{
			var module = Load("const name = a << b <<= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftLeft_ShiftRight()
		{
			var module = Load("const name = a >> b <<= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftLeft, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b >>= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_ShiftLeft()
		{
			var module = Load("const name = a << b >>= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackShiftRight_ShiftRight()
		{
			var module = Load("const name = a >> b >>= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackShiftRight, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b += c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_ShiftLeft()
		{
			var module = Load("const name = a << b += c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackPlus_ShiftRight()
		{
			var module = Load("const name = a >> b += c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackPlus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b -= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_ShiftLeft()
		{
			var module = Load("const name = a << b -= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMinus_ShiftRight()
		{
			var module = Load("const name = a >> b -= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMinus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b --= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_ShiftLeft()
		{
			var module = Load("const name = a << b --= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackConcat_ShiftRight()
		{
			var module = Load("const name = a >> b --= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackConcat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b *= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_ShiftLeft()
		{
			var module = Load("const name = a << b *= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackMultiply_ShiftRight()
		{
			var module = Load("const name = a >> b *= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackMultiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b /= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_ShiftLeft()
		{
			var module = Load("const name = a << b /= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackDivide_ShiftRight()
		{
			var module = Load("const name = a >> b /= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackDivide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b %= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_ShiftLeft()
		{
			var module = Load("const name = a << b %= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackModulo_ShiftRight()
		{
			var module = Load("const name = a >> b %= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackModulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b **= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_ShiftLeft()
		{
			var module = Load("const name = a << b **= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackExponentiate_ShiftRight()
		{
			var module = Load("const name = a >> b **= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackExponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b &= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_ShiftLeft()
		{
			var module = Load("const name = a << b &= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackAnd_ShiftRight()
		{
			var module = Load("const name = a >> b &= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackAnd, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b |= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_ShiftLeft()
		{
			var module = Load("const name = a << b |= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackOr_ShiftRight()
		{
			var module = Load("const name = a >> b |= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackOr, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b ^= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_ShiftLeft()
		{
			var module = Load("const name = a << b ^= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_WritebackXor_ShiftRight()
		{
			var module = Load("const name = a >> b ^= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.WritebackXor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b = c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_ShiftLeft()
		{
			var module = Load("const name = a << b = c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_CopyAssign_ShiftRight()
		{
			var module = Load("const name = a >> b = c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.CopyAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b := c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_ShiftLeft()
		{
			var module = Load("const name = a << b := c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_SemanticAssign_ShiftRight()
		{
			var module = Load("const name = a >> b := c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.SemanticAssign, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Xor()
		{
			var module = Load("const name = a ^ b | c ^ d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Xor, lhs.Operator);
			Assert.AreEqual(PsiOperator.Xor, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_And()
		{
			var module = Load("const name = a & b | c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Equals()
		{
			var module = Load("const name = a == b | c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_NotEquals()
		{
			var module = Load("const name = a != b | c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_LessOrEqual()
		{
			var module = Load("const name = a <= b | c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_MoreOrEqual()
		{
			var module = Load("const name = a >= b | c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Less()
		{
			var module = Load("const name = a < b | c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_More()
		{
			var module = Load("const name = a > b | c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Forward()
		{
			var module = Load("const name = a -> b | c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Backward()
		{
			var module = Load("const name = a <- b | c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Plus()
		{
			var module = Load("const name = a + b | c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Minus()
		{
			var module = Load("const name = a - b | c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Concat()
		{
			var module = Load("const name = a -- b | c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Multiply()
		{
			var module = Load("const name = a * b | c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Divide()
		{
			var module = Load("const name = a / b | c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Modulo()
		{
			var module = Load("const name = a % b | c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_Exponentiate()
		{
			var module = Load("const name = a ** b | c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b | c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_ShiftLeft()
		{
			var module = Load("const name = a << b | c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Or_ShiftRight()
		{
			var module = Load("const name = a >> b | c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Or, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_And()
		{
			var module = Load("const name = a & b ^ c & d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.And, lhs.Operator);
			Assert.AreEqual(PsiOperator.And, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Equals()
		{
			var module = Load("const name = a == b ^ c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_NotEquals()
		{
			var module = Load("const name = a != b ^ c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_LessOrEqual()
		{
			var module = Load("const name = a <= b ^ c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_MoreOrEqual()
		{
			var module = Load("const name = a >= b ^ c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Less()
		{
			var module = Load("const name = a < b ^ c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_More()
		{
			var module = Load("const name = a > b ^ c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Forward()
		{
			var module = Load("const name = a -> b ^ c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Backward()
		{
			var module = Load("const name = a <- b ^ c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Plus()
		{
			var module = Load("const name = a + b ^ c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Minus()
		{
			var module = Load("const name = a - b ^ c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Concat()
		{
			var module = Load("const name = a -- b ^ c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Multiply()
		{
			var module = Load("const name = a * b ^ c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Divide()
		{
			var module = Load("const name = a / b ^ c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Modulo()
		{
			var module = Load("const name = a % b ^ c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_Exponentiate()
		{
			var module = Load("const name = a ** b ^ c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b ^ c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_ShiftLeft()
		{
			var module = Load("const name = a << b ^ c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Xor_ShiftRight()
		{
			var module = Load("const name = a >> b ^ c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Xor, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Equals()
		{
			var module = Load("const name = a == b & c == d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Equals, lhs.Operator);
			Assert.AreEqual(PsiOperator.Equals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_NotEquals()
		{
			var module = Load("const name = a != b & c != d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.NotEquals, lhs.Operator);
			Assert.AreEqual(PsiOperator.NotEquals, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_LessOrEqual()
		{
			var module = Load("const name = a <= b & c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_MoreOrEqual()
		{
			var module = Load("const name = a >= b & c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Less()
		{
			var module = Load("const name = a < b & c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_More()
		{
			var module = Load("const name = a > b & c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Forward()
		{
			var module = Load("const name = a -> b & c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Backward()
		{
			var module = Load("const name = a <- b & c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Plus()
		{
			var module = Load("const name = a + b & c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Minus()
		{
			var module = Load("const name = a - b & c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Concat()
		{
			var module = Load("const name = a -- b & c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Multiply()
		{
			var module = Load("const name = a * b & c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Divide()
		{
			var module = Load("const name = a / b & c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Modulo()
		{
			var module = Load("const name = a % b & c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_Exponentiate()
		{
			var module = Load("const name = a ** b & c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b & c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_ShiftLeft()
		{
			var module = Load("const name = a << b & c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_And_ShiftRight()
		{
			var module = Load("const name = a >> b & c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.And, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_LessOrEqual()
		{
			var module = Load("const name = a <= b == c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_MoreOrEqual()
		{
			var module = Load("const name = a >= b == c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Less()
		{
			var module = Load("const name = a < b == c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_More()
		{
			var module = Load("const name = a > b == c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_LessOrEqual()
		{
			var module = Load("const name = a <= b != c <= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.LessOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.LessOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_MoreOrEqual()
		{
			var module = Load("const name = a >= b != c >= d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.MoreOrEqual, lhs.Operator);
			Assert.AreEqual(PsiOperator.MoreOrEqual, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Less()
		{
			var module = Load("const name = a < b != c < d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Less, lhs.Operator);
			Assert.AreEqual(PsiOperator.Less, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_More()
		{
			var module = Load("const name = a > b != c > d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.More, lhs.Operator);
			Assert.AreEqual(PsiOperator.More, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Forward()
		{
			var module = Load("const name = a -> b == c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Backward()
		{
			var module = Load("const name = a <- b == c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Forward()
		{
			var module = Load("const name = a -> b != c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Backward()
		{
			var module = Load("const name = a <- b != c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Plus()
		{
			var module = Load("const name = a + b == c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Minus()
		{
			var module = Load("const name = a - b == c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Concat()
		{
			var module = Load("const name = a -- b == c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Plus()
		{
			var module = Load("const name = a + b != c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Minus()
		{
			var module = Load("const name = a - b != c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Concat()
		{
			var module = Load("const name = a -- b != c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Multiply()
		{
			var module = Load("const name = a * b == c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Divide()
		{
			var module = Load("const name = a / b == c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Modulo()
		{
			var module = Load("const name = a % b == c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Multiply()
		{
			var module = Load("const name = a * b != c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Divide()
		{
			var module = Load("const name = a / b != c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Modulo()
		{
			var module = Load("const name = a % b != c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_Exponentiate()
		{
			var module = Load("const name = a ** b == c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_Exponentiate()
		{
			var module = Load("const name = a ** b != c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b == c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_ShiftLeft()
		{
			var module = Load("const name = a << b == c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Equals_ShiftRight()
		{
			var module = Load("const name = a >> b == c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Equals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b != c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_ShiftLeft()
		{
			var module = Load("const name = a << b != c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_NotEquals_ShiftRight()
		{
			var module = Load("const name = a >> b != c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.NotEquals, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Forward()
		{
			var module = Load("const name = a -> b <= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Backward()
		{
			var module = Load("const name = a <- b <= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Forward()
		{
			var module = Load("const name = a -> b >= c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Backward()
		{
			var module = Load("const name = a <- b >= c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Forward()
		{
			var module = Load("const name = a -> b < c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Backward()
		{
			var module = Load("const name = a <- b < c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Forward()
		{
			var module = Load("const name = a -> b > c -> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Forward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Forward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Backward()
		{
			var module = Load("const name = a <- b > c <- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Backward, lhs.Operator);
			Assert.AreEqual(PsiOperator.Backward, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Plus()
		{
			var module = Load("const name = a + b <= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Minus()
		{
			var module = Load("const name = a - b <= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Concat()
		{
			var module = Load("const name = a -- b <= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Plus()
		{
			var module = Load("const name = a + b >= c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Minus()
		{
			var module = Load("const name = a - b >= c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Concat()
		{
			var module = Load("const name = a -- b >= c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Plus()
		{
			var module = Load("const name = a + b < c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Minus()
		{
			var module = Load("const name = a - b < c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Concat()
		{
			var module = Load("const name = a -- b < c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Plus()
		{
			var module = Load("const name = a + b > c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Minus()
		{
			var module = Load("const name = a - b > c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Concat()
		{
			var module = Load("const name = a -- b > c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Multiply()
		{
			var module = Load("const name = a * b <= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Divide()
		{
			var module = Load("const name = a / b <= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Modulo()
		{
			var module = Load("const name = a % b <= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Multiply()
		{
			var module = Load("const name = a * b >= c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Divide()
		{
			var module = Load("const name = a / b >= c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Modulo()
		{
			var module = Load("const name = a % b >= c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Multiply()
		{
			var module = Load("const name = a * b < c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Divide()
		{
			var module = Load("const name = a / b < c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Modulo()
		{
			var module = Load("const name = a % b < c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Multiply()
		{
			var module = Load("const name = a * b > c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Divide()
		{
			var module = Load("const name = a / b > c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Modulo()
		{
			var module = Load("const name = a % b > c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_Exponentiate()
		{
			var module = Load("const name = a ** b <= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_Exponentiate()
		{
			var module = Load("const name = a ** b >= c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_Exponentiate()
		{
			var module = Load("const name = a ** b < c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_Exponentiate()
		{
			var module = Load("const name = a ** b > c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b <= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_ShiftLeft()
		{
			var module = Load("const name = a << b <= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_LessOrEqual_ShiftRight()
		{
			var module = Load("const name = a >> b <= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.LessOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b >= c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_ShiftLeft()
		{
			var module = Load("const name = a << b >= c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_MoreOrEqual_ShiftRight()
		{
			var module = Load("const name = a >> b >= c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.MoreOrEqual, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b < c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_ShiftLeft()
		{
			var module = Load("const name = a << b < c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Less_ShiftRight()
		{
			var module = Load("const name = a >> b < c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Less, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b > c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_ShiftLeft()
		{
			var module = Load("const name = a << b > c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_More_ShiftRight()
		{
			var module = Load("const name = a >> b > c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.More, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Plus()
		{
			var module = Load("const name = a + b -> c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Minus()
		{
			var module = Load("const name = a - b -> c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Concat()
		{
			var module = Load("const name = a -- b -> c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Plus()
		{
			var module = Load("const name = a + b <- c + d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Plus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Plus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Minus()
		{
			var module = Load("const name = a - b <- c - d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Minus, lhs.Operator);
			Assert.AreEqual(PsiOperator.Minus, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Concat()
		{
			var module = Load("const name = a -- b <- c -- d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Concat, lhs.Operator);
			Assert.AreEqual(PsiOperator.Concat, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Multiply()
		{
			var module = Load("const name = a * b -> c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Divide()
		{
			var module = Load("const name = a / b -> c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Modulo()
		{
			var module = Load("const name = a % b -> c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Multiply()
		{
			var module = Load("const name = a * b <- c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Divide()
		{
			var module = Load("const name = a / b <- c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Modulo()
		{
			var module = Load("const name = a % b <- c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_Exponentiate()
		{
			var module = Load("const name = a ** b -> c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_Exponentiate()
		{
			var module = Load("const name = a ** b <- c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b -> c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_ShiftLeft()
		{
			var module = Load("const name = a << b -> c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Forward_ShiftRight()
		{
			var module = Load("const name = a >> b -> c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Forward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b <- c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_ShiftLeft()
		{
			var module = Load("const name = a << b <- c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Backward_ShiftRight()
		{
			var module = Load("const name = a >> b <- c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Backward, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_Multiply()
		{
			var module = Load("const name = a * b + c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_Divide()
		{
			var module = Load("const name = a / b + c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_Modulo()
		{
			var module = Load("const name = a % b + c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_Multiply()
		{
			var module = Load("const name = a * b - c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_Divide()
		{
			var module = Load("const name = a / b - c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_Modulo()
		{
			var module = Load("const name = a % b - c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_Multiply()
		{
			var module = Load("const name = a * b -- c * d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Multiply, lhs.Operator);
			Assert.AreEqual(PsiOperator.Multiply, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_Divide()
		{
			var module = Load("const name = a / b -- c / d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Divide, lhs.Operator);
			Assert.AreEqual(PsiOperator.Divide, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_Modulo()
		{
			var module = Load("const name = a % b -- c % d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Modulo, lhs.Operator);
			Assert.AreEqual(PsiOperator.Modulo, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_Exponentiate()
		{
			var module = Load("const name = a ** b + c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_Exponentiate()
		{
			var module = Load("const name = a ** b - c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_Exponentiate()
		{
			var module = Load("const name = a ** b -- c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b + c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_ShiftLeft()
		{
			var module = Load("const name = a << b + c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Plus_ShiftRight()
		{
			var module = Load("const name = a >> b + c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Plus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b - c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_ShiftLeft()
		{
			var module = Load("const name = a << b - c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Minus_ShiftRight()
		{
			var module = Load("const name = a >> b - c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Minus, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b -- c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_ShiftLeft()
		{
			var module = Load("const name = a << b -- c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Concat_ShiftRight()
		{
			var module = Load("const name = a >> b -- c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Concat, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Multiply_Exponentiate()
		{
			var module = Load("const name = a ** b * c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Multiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Divide_Exponentiate()
		{
			var module = Load("const name = a ** b / c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Divide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Modulo_Exponentiate()
		{
			var module = Load("const name = a ** b % c ** d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Modulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.Exponentiate, lhs.Operator);
			Assert.AreEqual(PsiOperator.Exponentiate, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Multiply_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b * c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Multiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Multiply_ShiftLeft()
		{
			var module = Load("const name = a << b * c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Multiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Multiply_ShiftRight()
		{
			var module = Load("const name = a >> b * c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Multiply, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Divide_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b / c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Divide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Divide_ShiftLeft()
		{
			var module = Load("const name = a << b / c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Divide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Divide_ShiftRight()
		{
			var module = Load("const name = a >> b / c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Divide, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Modulo_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b % c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Modulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Modulo_ShiftLeft()
		{
			var module = Load("const name = a << b % c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Modulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Modulo_ShiftRight()
		{
			var module = Load("const name = a >> b % c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Modulo, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Exponentiate_ArithmeticShiftRight()
		{
			var module = Load("const name = a >>> b ** c >>> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Exponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ArithmeticShiftRight, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Exponentiate_ShiftLeft()
		{
			var module = Load("const name = a << b ** c << d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Exponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftLeft, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftLeft, rhs.Operator);
		}
		
		[Test]
		public void BinaryOperatorExpression_Exponentiate_ShiftRight()
		{
			var module = Load("const name = a >> b ** c >> d;");
			var expression = module.Declarations[0].Value;

			Assert.IsInstanceOf(typeof(BinaryOperation), expression);
			var op = (BinaryOperation)expression;
			
			Assert.AreEqual(PsiOperator.Exponentiate, op.Operator);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.LeftHandSide);
			Assert.IsInstanceOf(typeof(BinaryOperation), op.RightHandSide);

			var lhs = (BinaryOperation)op.LeftHandSide;
			var rhs = (BinaryOperation)op.RightHandSide;

			Assert.AreEqual(PsiOperator.ShiftRight, lhs.Operator);
			Assert.AreEqual(PsiOperator.ShiftRight, rhs.Operator);
		}
		

	}
}


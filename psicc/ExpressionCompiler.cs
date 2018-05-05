using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LLVMSharp;
using Psi.Compiler.Intermediate;

using Type = Psi.Compiler.Intermediate.Type;

namespace Psi.Compiler.Codegen
{
    internal class ExpressionCompiler : IExpressionVisitor
    {
        private readonly CodeGenerator codegen;
        private readonly LLVMBuilderRef builder;
        private readonly LLVMValueRef function;

        public ExpressionCompiler(CodeGenerator codegen, LLVMBuilderRef builder, LLVMValueRef function)
        {
            this.codegen = codegen;
            this.builder = builder;
            this.function = function;
        }

        public LLVMValueRef Compile(Expression expression) => expression.Visit(this);

        LLVMValueRef IExpressionVisitor.Visit(ArrayExpression exp)
        {
            throw new NotImplementedException();
        }

        LLVMValueRef IExpressionVisitor.Visit(FunctionLiteral exp)
        {
            return codegen.GetFunctionPointer(exp.Value);
        }

        LLVMValueRef IExpressionVisitor.Visit(SymbolReference exp)
        {
            var target = exp.Symbol;
            switch(target.Kind)
            {
                case SymbolKind.Builtin:
                case SymbolKind.Extern:
                case SymbolKind.Global:
                    return codegen.GetGlobalVariable(exp.Symbol);
                case SymbolKind.Local:
                    throw new NotImplementedException();
                case SymbolKind.Parameter:
                    return LLVM.GetParam(function, (uint)exp.Symbol.ParameterIndex);
                default:
                    throw new NotImplementedException();
            }
        }

        LLVMValueRef IExpressionVisitor.Visit(FunctionCall exp)
        {
            var args = exp.Arguments.Select(a => Compile(a)).ToArray();

            var fun = Compile(exp.Functor);

            return LLVM.BuildCall(builder, fun, args, exp.Type!= Type.VoidType ? "funcall" : "");
        }

        LLVMValueRef IExpressionVisitor.Visit(Literal<bool> exp) => LLVM.ConstInt(LLVM.Int1Type(), exp.Value ? 1ul : 0ul, false);

        LLVMValueRef IExpressionVisitor.Visit(Literal<byte> exp) => LLVM.ConstInt(LLVM.Int8Type(), exp.Value, false);

        LLVMValueRef IExpressionVisitor.Visit(Literal<int> exp) => LLVM.ConstInt(LLVM.Int32Type(), (ulong)exp.Value, false);

        LLVMValueRef IExpressionVisitor.Visit(Literal<long> exp) => LLVM.ConstInt(LLVM.Int64Type(), (ulong)exp.Value, true);

        LLVMValueRef IExpressionVisitor.Visit(Literal<ulong> exp) => LLVM.ConstInt(LLVM.Int64Type(), exp.Value, true);

        LLVMValueRef IExpressionVisitor.Visit(Literal<string> exp)
        {
            var raw = Encoding.UTF32.GetBytes(exp.Value);
            var utf32 = new int[raw.Length / 4];
            Buffer.BlockCopy(raw, 0, utf32, 0, raw.Length);

            return LLVM.ConstArray(LLVM.Int32Type(), utf32.Select(i => LLVM.ConstInt(LLVM.Int32Type(), (ulong)i, false)).ToArray());
        }

        LLVMValueRef IExpressionVisitor.Visit(Literal<double> exp) => LLVM.ConstReal(LLVM.DoubleType(), exp.Value);

        LLVMValueRef IExpressionVisitor.Visit<T>(Literal<T> invalid) => throw new NotImplementedException();
    }
}
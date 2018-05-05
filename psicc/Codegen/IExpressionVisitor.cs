using LLVMSharp;
using Psi.Compiler.Intermediate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psi.Compiler.Codegen
{
    public interface IExpressionVisitor
    {
        LLVMValueRef Visit<T>(Literal<T> invalid);

        LLVMValueRef Visit(Literal<bool> exp);   // std.bool
        LLVMValueRef Visit(Literal<byte> exp);   // std.byte
        LLVMValueRef Visit(Literal<int> exp);    // std.char
        LLVMValueRef Visit(Literal<long> exp);   // std.int
        LLVMValueRef Visit(Literal<ulong> exp);  // std.uint
        LLVMValueRef Visit(Literal<string> exp); // std.string
        LLVMValueRef Visit(Literal<double> exp); // std.real

        LLVMValueRef Visit(ArrayExpression exp);
        LLVMValueRef Visit(FunctionLiteral exp);
        LLVMValueRef Visit(SymbolReference exp);
        LLVMValueRef Visit(FunctionCall exp);
    }
}

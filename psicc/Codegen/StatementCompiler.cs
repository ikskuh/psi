using System;
using LLVMSharp;
using Psi.Compiler.Intermediate;

namespace Psi.Compiler.Codegen
{
    internal class StatementCompiler : IStatementVisitor
    {
        private readonly CodeGenerator codegen;
        private readonly LLVMValueRef function;
        private readonly LLVMBuilderRef builder;

        public StatementCompiler(CodeGenerator codegen, LLVMValueRef function, LLVMBuilderRef builder)
        {
            this.codegen = codegen;
            this.function = function;
            this.builder = builder;
        }

        public void Compile(Statement stmt)
        {
            stmt.Visit(this);
        }

        void IStatementVisitor.Visit(Block stmt)
        {
            foreach(var sub in stmt.Statements)
            {
                sub.Visit(this);
            }
        }

        void IStatementVisitor.Visit(ExpressionStatement stmt)
        {
            var compiler = new ExpressionCompiler(codegen, builder, function);
            var result = compiler.Compile(stmt.Expression);

            // discard: result
        }

        void IStatementVisitor.Visit(ReturnStatement stmt)
        {
            if (stmt.Result == null)
                LLVM.BuildRetVoid(builder);
        }

        void IStatementVisitor.Visit(WhileLoop stmt)
        {
            throw new NotImplementedException();
        }
    }
}
using Psi.Compiler.Intermediate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psi.Compiler.Codegen
{
    public interface IStatementVisitor
    {
        void Visit(Block stmt);
        void Visit(ExpressionStatement stmt);
        void Visit(ReturnStatement stmt);
        void Visit(WhileLoop stmt);
    }
}

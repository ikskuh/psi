using Psi.Compiler.Intermediate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psi.Compiler.Codegen
{
    public interface ITypeVisitor
    {
        void Visit(FunctionType type);
        void Visit(RecordType type);
        void Visit(BuiltinType type);
        void Visit(EnumType type);
        void Visit(ReferenceType type);
        void Visit(ArrayType type);
    }
}

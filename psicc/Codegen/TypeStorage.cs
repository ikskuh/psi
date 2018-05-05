using LLVMSharp;
using Psi.Compiler.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = Psi.Compiler.Intermediate.Type;

namespace Psi.Compiler.Codegen
{
    public sealed class TypeStorage : ITypeVisitor
    {
        private readonly Dictionary<Type, LLVMTypeRef> cache = new Dictionary<Type, LLVMTypeRef>();

        public LLVMTypeRef Get(Type type)
        {
            if (cache.TryGetValue(type, out var llvmtype))
                return llvmtype;
            type.Visit(this);
            llvmtype = cache[type];
            if (llvmtype.Pointer == IntPtr.Zero)
                throw new InvalidOperationException("Tried to access an invalid type!");
            return llvmtype;
        }

        public LLVMTypeRef GetForFunction(FunctionType type)
        {
            var returnType = Get(type.ReturnType);
            var @params = type.Parameters.Select(p => Get(p.Type)).ToArray();

            // HACK: function types are implemented as function pointers
            // TODO: function types should be of a closure type
            return LLVM.FunctionType(returnType, @params, false);
        }

        void ITypeVisitor.Visit(FunctionType type) => cache[type] = LLVM.PointerType(GetForFunction(type), 0);

        void ITypeVisitor.Visit(RecordType type)
        {
            throw new NotImplementedException();
        }

        void ITypeVisitor.Visit(BuiltinType type) => cache[type] = type.LLVMType;

        void ITypeVisitor.Visit(EnumType type) => cache[type] = LLVM.Int32Type();

        void ITypeVisitor.Visit(ReferenceType type) => cache[type] = LLVM.PointerType(Get(type.ObjectType), 0);

        void ITypeVisitor.Visit(ArrayType type)
        {
            if (type.Dimensions != 1)
                throw new NotSupportedException("Multidimensional arrays are not supported yet!");
            // HACK: PSI ARRAYS ARE NOT ACTUALLY STD::ARRAY<T,1024> BUT MORE SOMETHING LIKE STD::VECTOR<T>
            cache[type] = LLVM.ArrayType(Get(type.ElementType), 1024);
        }
    }
}
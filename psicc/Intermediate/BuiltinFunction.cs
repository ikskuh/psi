using LLVMSharp;
using System;

namespace Psi.Compiler.Intermediate
{
    public sealed class BuiltinFunction : Function
    {
        private readonly LLVMValueRef function;

        public BuiltinFunction(FunctionType type)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public BuiltinFunction(FunctionType type, LLVMValueRef function) : this(type)
        {
            this.function = function;
        }

        public override FunctionType Type { get; }

        public LLVMValueRef Function
        {
            get
            {
                if (this.function.Pointer == IntPtr.Zero)
                    throw new NotImplementedException("This builtin function is not implemented yet!");
                return this.function;
            }
        }
    }
}
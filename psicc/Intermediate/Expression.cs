using System;

namespace Psi.Compiler.Intermediate
{
    public abstract class Expression
    {
        public abstract Type Type { get; }

        public abstract LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor);
    }

    public sealed class FunctionLiteral : Expression
    {
        Function value;

        public FunctionLiteral(FunctionType type)
        {
            this.Type = type;
        }

        public FunctionLiteral(Function fun) : this(fun.Type)
        {
            this.value = fun;
        }

        public override Type Type { get; }

        public Function Value
        {
            get { return value; }
            set
            {
                if (value == null)
                {
                    this.value = null;
                }
                if (value.Type.Equals(this.Type) == false)
                    throw new InvalidOperationException();
                this.value = value;
            }
        }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public class Literal<T> : Expression
    {
        protected Literal(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            this.Value = value;
            this.Type = TypeMapper.Get<T>();
        }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);

        public override Type Type { get; }

        public T Value { get; }
    }

    public sealed class BoolLiteral : Literal<bool>
    {
        public BoolLiteral(bool v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class ByteLiteral : Literal<byte>
    {
        public ByteLiteral(byte v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class CharLiteral : Literal<int>
    {
        public CharLiteral(int v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class IntLiteral : Literal<long>
    {
        public IntLiteral(long v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class UIntLiteral : Literal<ulong>
    {
        public UIntLiteral(ulong v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class RealLiteral : Literal<double>
    {
        public RealLiteral(double v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class StringLiteral : Literal<string>
    {
        public StringLiteral(string v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }


    public sealed class TypeLiteral : Literal<Type>
    {
        public TypeLiteral(Type v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public sealed class ModuleLiteral : Literal<Module>
    {
        public ModuleLiteral(Module v) : base(v) { }

        public override LLVMSharp.LLVMValueRef Visit(Psi.Compiler.Codegen.IExpressionVisitor visitor) => visitor.Visit(this);
    }
}
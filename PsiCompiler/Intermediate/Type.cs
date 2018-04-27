
using System;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public abstract class Type : IEquatable<Type>
    {
        /// <summary>
        /// A type that marks a non-value
        /// </summary>
        public static readonly BuiltinType VoidType = new BuiltinType("void");

        /// <summary>
        /// A marker type that marks "unknown" types that have to be deduced
        /// </summary>
        public static readonly Type UnknownType = new BuiltinType("?");

        /// <summary>
        /// The type that represents a Psi type.
        /// </summary>
        public static readonly BuiltinType MetaType = new BuiltinType("type");

        /// <summary>
        /// The type that represents a module.
        /// </summary>
        public static readonly BuiltinType ModuleType = new BuiltinType("module");

        public override int GetHashCode() => base.GetHashCode();

        public override bool Equals(object obj) => Equals(obj as Type);

        public bool Equals(Type other)
        {
            if (other == null)
                return false;
            if (other.GetType() != this.GetType()) // Types have strong equality!
                return false;
            return this.TypeEquals(other);
        }

        protected abstract ITypeSignature CreateSignature();

        /// <summary>
        /// Compares the two types for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <remarks>other is certainly of the same type as `this`.</remarks> 
        /// <returns></returns>
        protected abstract bool TypeEquals(Type other);

        public ITypeSignature Signature => this.CreateSignature();
    }

    public sealed class BuiltinType : Type, ITypeSignature
    {
        public static readonly EnumType Boolean = new EnumType(new[] { "false", "true" });
        public static readonly BuiltinType Byte = new BuiltinType("byte");
        public static readonly BuiltinType Integer = new BuiltinType("int");
        public static readonly BuiltinType UnsignedInteger = new BuiltinType("uint");
        public static readonly BuiltinType Real = new BuiltinType("real");
        public static readonly BuiltinType Character = new BuiltinType("char");
        public static readonly ArrayType String = new ArrayType { ElementType = Character, Dimensions = 1 };

        public BuiltinType(string name)
        {
            this.Name = name;
        }

        protected override bool TypeEquals(Type other) => object.ReferenceEquals(this, other);

        public string Name { get; }

        public override string ToString() => "builtin:" + this.Name;

        protected override ITypeSignature CreateSignature() => this;

        public bool Equals(ITypeSignature sig) => this.Equals(sig as Type);
    }

    public sealed class EnumType : Type, ITypeSignature
    {
        private string[] items;

        public EnumType(IReadOnlyList<string> items)
        {
            this.items = items.ToArray();
        }

        protected override bool TypeEquals(Type other)
        {
            return Enumerable.SequenceEqual(this.items, ((EnumType)other).items);
        }

        public override int GetHashCode() => this.items.Select(x => x.GetHashCode()).Aggregate(0, (a, b) => a ^ b);

        public IReadOnlyList<string> Members => this.items;

        public override string ToString() => "enum(" + string.Join(",", this.items) + ")";

        protected override ITypeSignature CreateSignature() => this;

        public bool Equals(ITypeSignature sig) => this.Equals(sig as Type);
    }

    public sealed class RecordType : Type, ITypeSignature
    {
        public IList<RecordMember> Members { get; set; }

        protected override bool TypeEquals(Type _other)
        {
            RecordType other = (RecordType)_other;
            return this.Members.All(m => other.Members.Contains(m))
                && other.Members.All(m => this.Members.Contains(m));
        }

        public override int GetHashCode() => this.Members.Select(x => x.GetHashCode()).Aggregate(0, (a, b) => a ^ b);

        public override string ToString() => "record(" + string.Join(", ", Members.Select(m => $"{m.Name} : {m.Type}")) + ")";

        protected override ITypeSignature CreateSignature() => this;

        public bool Equals(ITypeSignature sig) => this.Equals(sig as Type);
    }

    public sealed class ArrayType : Type, ITypeSignature
    {
        public Type ElementType { get; set; }

        public int Dimensions { get; set; } = 1;

        public override int GetHashCode() => ElementType.GetHashCode();

        protected override bool TypeEquals(Type other)
        {
            var at = (ArrayType)other;
            return this.Dimensions == at.Dimensions && ElementType.Equals(at.ElementType);
        }

        protected override ITypeSignature CreateSignature() => this;

        public bool Equals(ITypeSignature sig) => this.Equals(sig as Type);
    }

    public sealed class ReferenceType : Type, ITypeSignature
    {
        public Type ObjectType { get; set; }

        public override int GetHashCode() => -this.ObjectType.GetHashCode();

        protected override bool TypeEquals(Type other) => object.Equals(ObjectType, ((ReferenceType)other).ObjectType);

        protected override ITypeSignature CreateSignature() => this;

        public bool Equals(ITypeSignature sig) => this.Equals(sig as Type);
    }

    public sealed class FunctionType : Type
    {
        public Type ReturnType { get; set; }

        public Parameter[] Parameters { get; set; }

        public FunctionType()
        {

        }

        public FunctionType(Type returnType, params Type[] @params)
        {
            this.ReturnType = returnType;
            this.Parameters = @params.Select((a, i) => new Parameter(this, $"p{i + 1}", i) { Type = a }).ToArray();
        }

        protected override bool TypeEquals(Type other)
        {
            var ft = (FunctionType)other;
            if (!object.Equals(ReturnType, ft.ReturnType))
                return false;
            return Enumerable.SequenceEqual(this.Parameters, ft.Parameters);
        }

        public override int GetHashCode() => this.ReturnType.GetHashCode() ^ this.Parameters.Select(x => x.GetHashCode()).Aggregate(0, (a, b) => a ^ b);


        public static FunctionType CreateUnaryOperator(Type allType) => CreateUnaryOperator(allType, allType);

        public static FunctionType CreateUnaryOperator(Type returnType, Type paramType, ParameterFlags paramFlags = ParameterFlags.In)
        {
            var fun = new FunctionType
            {
                ReturnType = returnType ?? throw new ArgumentNullException(nameof(ReturnType))
            };
            fun.Parameters = new Parameter[]
            {
                new Parameter(fun, "operand", 0)
                {
                    Flags = paramFlags,
                    Type = paramType ?? throw new ArgumentNullException(nameof(paramType)),
                    Initializer = null,
                },
            };
            return fun;
        }

        public static FunctionType CreateBinaryOperator(Type allType) => CreateBinaryOperator(allType, allType, allType);

        public static FunctionType CreateBinaryOperator(Type returnType, Type paramType) => CreateBinaryOperator(returnType, paramType, paramType);

        public static FunctionType CreateBinaryOperator(Type returnType, Type leftType, Type rightType, ParameterFlags lhsFlags = ParameterFlags.In, ParameterFlags rhsFlags = ParameterFlags.In)
        {
            var fun = new FunctionType
            {
                ReturnType = returnType ?? throw new ArgumentNullException(nameof(ReturnType))
            };
            fun.Parameters = new Parameter[]
            {
                new Parameter(fun, "lhs", 0)
                {
                    Flags = lhsFlags,
                    Type = leftType ?? throw new ArgumentNullException(nameof(leftType)),
                    Initializer = null,
                },
                new Parameter(fun, "rhs", 1)
                {
                    Flags = rhsFlags,
                    Type = rightType ?? throw new ArgumentNullException(nameof(rightType)),
                    Initializer = null,
                }
            };
            return fun;
        }

        protected override ITypeSignature CreateSignature() => new FunctionSignature(this);
    }

    /// <summary>
    /// Implements parameter list matching, but ignores return type.
    /// </summary>
    public sealed class FunctionSignature : ITypeSignature, IEquatable<FunctionSignature>
    {
        private FunctionType functionType;

        public FunctionSignature(FunctionType functionType)
        {
            this.functionType = functionType ?? throw new ArgumentNullException(nameof(functionType));
        }

        public override bool Equals(object obj) => Equals(obj as FunctionSignature);

        public bool Equals(ITypeSignature obj) => Equals(obj as FunctionSignature);

        public bool Equals(FunctionSignature other)
        {
            if (other == null)
                return false;
            return Enumerable.SequenceEqual(this.functionType.Parameters, other.functionType.Parameters, new ParSigComparer());
        }

        public override int GetHashCode() => this.functionType.Parameters.Select(x => x.GetHashCode()).Aggregate(0, (a, b) => a ^ b);

        public IReadOnlyList<Parameter> Parameters => this.functionType.Parameters;

        private class ParSigComparer : IEqualityComparer<Parameter>
        {
            public bool Equals(Parameter x, Parameter y)
            {
                if ((x == null) || (y == null))
                    return false; // Parameters should not be null!
                return object.Equals(x.Position, y.Position)
                    && object.Equals(x.Type, y.Type);
            }

            public int GetHashCode(Parameter obj) => obj.Position.GetHashCode() ^ (obj.Type?.GetHashCode() ?? 0);
        }
    }
}
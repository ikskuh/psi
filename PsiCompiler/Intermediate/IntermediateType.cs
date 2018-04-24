
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public abstract class Type
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
    }

    public sealed class BuiltinType : Type
    {
        public BuiltinType(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public override string ToString() => "builtin:" + this.Name;
    }

    public sealed class EnumType : Type
    {
        private string[] items;

        public EnumType(IReadOnlyList<string> items)
        {
            this.items = items.ToArray();
        }

        public IReadOnlyList<string> Members => this.items;

        public override string ToString() => "enum(" + string.Join(",", this.items) + ")";
    }

    public sealed class RecordType : Type
    {
        public IList<RecordMember> Members { get; set; }
    }

    public sealed class ArrayType : Type
    {
        public Type ElementType { get; set; }

        public int Dimensions { get; set; } = 1;
    }

    public sealed class ReferenceType : Type
    {
        public Type ObjectType { get; set; }
    }

    public sealed class FunctionType : Type
    {
        public Type ReturnType { get; set; }

        public IList<Parameter> Parameters { get; set; }
    }
}
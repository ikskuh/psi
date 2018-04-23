
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public abstract class IntermediateType
    {
        /// <summary>
        /// A type that marks a non-value
        /// </summary>
        public static readonly BuiltinType VoidType = new BuiltinType();

        /// <summary>
        /// A marker type that marks "unknown" types that have to be deduced
        /// </summary>
        public static readonly IntermediateType UnknownType = new BuiltinType();

        /// <summary>
        /// The type that represents a Psi type.
        /// </summary>
        public static readonly BuiltinType MetaType = new BuiltinType();
    }

    public sealed class BuiltinType : IntermediateType
    {

    }

    public sealed class EnumType : IntermediateType
    {
        private string[] items;

        public EnumType(IReadOnlyList<string> items)
        {
            this.items = items.ToArray();
        }

        public IReadOnlyList<string> Members => this.items;

        public override string ToString() => "enum(" + string.Join(",", this.items) + ")";
    }

    public sealed class RecordType : IntermediateType
    {
        public IList<RecordMember> Members { get; set; } = new List<RecordMember>();
    }
}
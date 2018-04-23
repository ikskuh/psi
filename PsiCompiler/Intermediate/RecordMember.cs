using System;

namespace Psi.Compiler.Intermediate
{
    public class RecordMember
    {
        public RecordMember(RecordType type, string name)
        {
            this.Owner = type ?? throw new ArgumentNullException(nameof(type));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public RecordType Owner { get; }

        public string Name { get; }

        public IntermediateType Type { get; set; }

        public Expression Initializer { get; set; }
    }
}
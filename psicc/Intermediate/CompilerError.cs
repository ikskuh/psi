using System;

namespace Psi.Compiler.Intermediate
{
    public class CompilerError : Exception
    {
        public static readonly CompilerError None = null;

        public CompilerError(string description) : base(description)
        {
            this.Description = description;
        }

        public string Description { get; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
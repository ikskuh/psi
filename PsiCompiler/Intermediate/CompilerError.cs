namespace Psi.Compiler.Intermediate
{
    public class CompilerError
    {
        public static readonly CompilerError None = null;

        public CompilerError(string description)
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
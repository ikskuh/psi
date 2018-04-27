namespace Psi.Compiler.Intermediate
{
    public sealed class ReturnStatement : Statement
    {
        public Expression Result { get; set; }
    }
}
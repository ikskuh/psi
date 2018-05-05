namespace Psi.Compiler.Intermediate
{
    public sealed class ReturnStatement : Statement
    {
        public Expression Result { get; set; }

        public override void Visit(Codegen.IStatementVisitor visitor) => visitor.Visit(this);
    }
}
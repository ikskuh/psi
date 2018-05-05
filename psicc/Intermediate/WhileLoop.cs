namespace Psi.Compiler.Intermediate
{
    public sealed class WhileLoop : Statement
    {
        public Expression Condition { get; set; }

        public Statement Body { get; set; }

        public override void Visit(Codegen.IStatementVisitor visitor) => visitor.Visit(this);
    }
}
namespace Psi.Compiler.Intermediate
{
    public abstract class Statement
    {
        public abstract void Visit(Codegen.IStatementVisitor visitor);
    }
}
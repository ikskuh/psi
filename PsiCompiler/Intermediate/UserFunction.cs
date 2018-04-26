namespace Psi.Compiler.Intermediate
{
    public sealed class UserFunction : Function
    {
        public UserFunction(FunctionType type)
        {
            this.Type = type;
        }

        public StackableScope Scope { get; } = new StackableScope();

        public override FunctionType Type { get; }

        public Statement Body { get; set; }
    }
}
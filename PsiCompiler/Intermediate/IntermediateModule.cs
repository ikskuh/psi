namespace Psi.Compiler
{
	public class IntermediateModule : Scope
	{
		public IntermediateModule(string name)
		{
			this.Name = name.NotNull();
		}
	
		public string Name { get; }
	}
}
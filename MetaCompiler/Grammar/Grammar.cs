using System.Collections.Generic;
namespace MetaCompiler
{
	public class Grammar
	{
		public ICollection<Rule> Rules { get; } = new List<Rule>();
	}
}
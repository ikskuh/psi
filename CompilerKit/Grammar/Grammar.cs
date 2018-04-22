using System.Collections.Generic;
namespace CompilerKit
{
	public class Grammar
	{
		public ICollection<Rule> Rules { get; } = new List<Rule>();
	}
}
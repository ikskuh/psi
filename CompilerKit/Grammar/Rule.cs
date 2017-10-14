using System;
namespace CompilerKit
{
	public sealed class Rule
	{
		internal CodeLocation Location { get; set; }
	
		public string Name { get; set; }
		
		public Syntax Syntax { get; set; }
	}
}

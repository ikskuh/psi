using System.Collections.Generic;
namespace CompilerKit
{
	public abstract class Syntax
	{
		public bool IsGroup { get; set; } = false;
		
		/// <summary>
		/// Flatten this syntax into a list of all children and itself
		/// </summary>
		/// <returns>The flatten.</returns>
		public abstract IEnumerable<Syntax> Flatten();
		
		public abstract string ToGrammarCode();
		
		public override string ToString()
		{
			var text = this.ToGrammarCode();
			if(IsGroup)
				return "( " + text + " )";
			else
				return text;
		}
	}
}
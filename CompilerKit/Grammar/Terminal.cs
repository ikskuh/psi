using System;
using System.Text.RegularExpressions;
namespace CompilerKit
{
	public sealed class Terminal : Syntax
	{
		public Terminal(string name, Regex pattern) : this(name)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentOutOfRangeException(nameof(name));
			this.Pattern = pattern;
		}
	
		public Terminal(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentOutOfRangeException(nameof(name));
			this.Name = name;
		}
		
		public string Name { get; set; }
		
		public Regex Pattern { get; set; }
		
		public override System.Collections.Generic.IEnumerable<Syntax> Flatten() => new Syntax[] { this };
		
		public override string ToGrammarCode() => string.Format("\"{0}\"", Name);
	}
}

using System;
namespace MetaCompiler
{
	public sealed class RuleReference : Syntax
	{
		public RuleReference(string token)
		{
			if(string.IsNullOrWhiteSpace(token))
				throw new ArgumentOutOfRangeException(nameof(token));
			this.Rule = token;
		}
		
		public string Rule { get; }
		
		public override System.Collections.Generic.IEnumerable<Syntax> Flatten() => new Syntax[] { this };
		
		public override string ToGrammarCode() => string.Format("<{0}>", Rule);
	}
}

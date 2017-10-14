using System;
namespace CompilerKit
{
	public class Optional : Syntax
	{
		public Optional(Syntax body)
		{
			if(body == null) 
				throw new ArgumentNullException(nameof(body));
			this.Body = body;
		}
		
		public Syntax Body { get; }
		
		public override System.Collections.Generic.IEnumerable<Syntax> Flatten()
		{
			yield return this;
			foreach(var child in this.Body.Flatten()) yield return child;
		}
		
		public override string ToGrammarCode() => string.Format("[ {0} ]",  Body);
	}
}

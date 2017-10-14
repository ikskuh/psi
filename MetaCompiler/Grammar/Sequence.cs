using System;
namespace MetaCompiler
{
	public class Sequence : Syntax
	{
		public Sequence(Syntax first, Syntax second)
		{
			if(first == null) 
				throw new ArgumentNullException(nameof(first));
			if(second == null) 
				throw new ArgumentNullException(nameof(second));
			this.First = first;
			this.Second = second;
		}
		
		public Syntax First { get; }
		
		public Syntax Second { get; }
		
		public override System.Collections.Generic.IEnumerable<Syntax> Flatten()
		{
			yield return this;
			foreach(var child in this.First.Flatten()) yield return child;
			foreach(var child in this.Second.Flatten()) yield return child;
		}
		
		public override string ToGrammarCode() => string.Format("{0} {1}", First, Second);
	}
}

using System;
using System.Collections.Generic;
namespace midend
{
	public sealed class Module
	{
		public Dictionary<Signature, Variable> Variables { get; } = new Dictionary<Signature, Variable>();
		
		
		public List<Assertion> Assertions { get; } = new List<Assertion>();
	}
}

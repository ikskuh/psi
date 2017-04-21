using System;
using System.Collections.Generic;
namespace midend
{
	public sealed class Module : Scope
	{
		public Module(Scope parent = null) : base(parent)
		{
		
		}
	
		public List<Assertion> Assertions { get; } = new List<Assertion>();
	}
}

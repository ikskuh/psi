using System;
using System.Collections.Generic;
namespace midend
{
	public sealed class Module : Scope
	{
		public Module() : base(null)
		{
		
		}
	
		public List<Assertion> Assertions { get; } = new List<Assertion>();
	}
}

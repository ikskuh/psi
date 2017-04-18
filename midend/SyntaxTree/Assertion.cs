using System;
namespace midend
{
	public sealed class Assertion
	{
		/// <summary>
		/// Gets or sets the expression, that must evaluate to true.
		/// </summary>
		/// <value>The claim.</value>
		public Expression Claim { get; set;}	
	}
}

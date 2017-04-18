using System;
namespace midend
{
	/// <summary>
	/// A boolean type that can only be true or false,
	/// </summary>
	public sealed class BooleanType : CType
	{
		public static readonly CType Instance = new BooleanType();
	
		public static readonly CValue True = new CValue(Instance, true);
		public static readonly CValue False = new CValue(Instance, false);
		
		private BooleanType()
		{
			
		}
		
		public override string ToString() => "bool";
	}
}

using System;
namespace midend
{
	/// <summary>
	/// A boolean type that can only be true or false,
	/// </summary>
	public sealed class BooleanType : CType
	{
		public static readonly CType Instance;
		public static readonly CValue True;
		public static readonly CValue False;
		
		static BooleanType()
		{
			Instance = new BooleanType();
			True = new CValue(Instance, true);
			False = new CValue(Instance, false);
		}
		
		private BooleanType()
		{
			
		}
		
		public override bool IsAllowedValue(object value) => value is bool;
		
		public override string ToString() => "bool";
	}
}

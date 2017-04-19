using System;
namespace midend
{
	public sealed class TypeType : CType
	{
		public static readonly CType Instance = new TypeType ();
		
		private TypeType()
		{
		
		}
		
		public override bool IsAllowedValue(object value) => value is CType;
		
		public override string ToString() => "type";
	}
}

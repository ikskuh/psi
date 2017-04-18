using System;
namespace midend
{
	public sealed class StringType : CType
	{
		public static readonly StringType Instance = new StringType();
		
		private StringType()
		{
			
		}
		
		public override string ToString() => "string";
	}
}

using System;
namespace midend
{
	public sealed class ModuleType : CType
	{
		public static readonly ModuleType Instance = new ModuleType();
		
		private ModuleType()
		{
			
		}
		
		public override bool IsAllowedValue(object value) => value is Module;
		
		public override string ToString() => "module";
	}
}

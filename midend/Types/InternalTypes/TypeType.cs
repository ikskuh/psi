using System;
namespace midend
{
	public sealed class TypeType : CType
	{
		public static readonly CType Instance = new TypeType();

		private TypeType()
		{
			
		}
		
		public override Field GetField(string name)
		{
			var fld = base.GetField(name);
			if(fld != null) return fld;
			switch(name)
			{
				case "name": return new TypeNameField();
				default: return null;
			}
		}
		
		public override Field GetInstanceField(CValue instance, string name)
		{
			return instance.Get<CType>().GetTypeField(name);
		}
		
		public override bool IsAllowedValue(object value) => value is CType;

		public override string ToString() => "type";
	}
}

using System;
namespace midend
{
	public sealed class CharacterType : CType
	{
		public static readonly CharacterType Instance = new CharacterType();
		
		private CharacterType()
		{
		
		}
		
		public override bool IsAllowedValue(object value) => (value is ulong) || (value is char);
		
		public override string ToString() => "char";
	}
}

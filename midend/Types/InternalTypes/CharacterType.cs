using System;
namespace midend
{
	public sealed class CharacterType : CType
	{
		public static readonly CharacterType Instance = new CharacterType();
		
		private CharacterType()
		{
		}
		
		public override string ToString() => "char";
	}
}

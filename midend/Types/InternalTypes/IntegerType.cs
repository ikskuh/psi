using System;
using System.Numerics;
namespace midend
{
	public sealed class IntegerType : CType
	{
		public static readonly IntegerType Instance = new IntegerType();
	
		private IntegerType() { }

		public override string ToString() => "int";
		
		public override bool IsAllowedValue(object value) => value is BigInteger;
	}

	public enum IntegerOverflowBehaviour
	{
		Failing = 0,
		Clamping = 1,
		Wrapping = 2,
	}
}

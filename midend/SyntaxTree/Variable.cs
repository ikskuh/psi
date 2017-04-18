using System;
namespace midend
{
	public sealed class Variable
	{
		public CType Type { get; set; }

		public Expression InitialValue { get; set; }

		public bool IsConst { get; set; }
		
		public bool IsExported { get; set; }
	}
}

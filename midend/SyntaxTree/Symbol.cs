using System;
namespace midend
{
	public sealed class Symbol
	{
		private readonly Signature name;

		public Symbol(Signature name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name));
			this.name = name;
		}
		
		public Symbol(string name, CType type) : this(new Signature(name, type)) { }
		
		public Signature Name => this.name;
	
		public CType Type => this.Name.Type;

		public Expression InitialValue { get; set; }

		public bool IsConst { get; set; }
		
		public bool IsExported { get; set; }
	}
}

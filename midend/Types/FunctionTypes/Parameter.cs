using System;
namespace midend
{
	public sealed class Parameter
	{
		private readonly string name;
		private readonly CType type;
		private readonly CValue defaultValue;

		public Parameter(string name, CType type, CValue defaultValue = null)
		{
			Signature.ValidateIdentifier(name);
			if (type == null) throw new ArgumentNullException(nameof(type));
			this.name = name;
			this.type = type;
			this.defaultValue = defaultValue;
		}
		
		public string Name => this.name;

		public CType Type => this.type;

		public CValue DefaultValue => this.defaultValue;
	}
}

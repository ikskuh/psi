using System;
namespace midend
{
	public sealed class Symbol
	{
		private readonly Signature name;
		private Expression initialValue;

		public Symbol(Signature name)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name));
			this.name = name;
		}

		public Symbol(string name, CType type) : this(new Signature(name, type)) { }

		public Signature Name => this.name;

		public CType Type => this.Name.Type;

		public Expression InitialValue
		{
			get { return this.initialValue; }
			set
			{
				if(value != null)
				{
					if(this.Type.CanBeAssignedFrom(value.Type) == false)
						throw new InvalidOperationException("Type assignment is not valid!");
				}
				this.initialValue = value;
			}
		}

		public bool IsConst { get; set; }

		public bool IsExported { get; set; }

		public bool HasStaticValue => (this.IsConst && (this.InitialValue?.IsConstant ?? false));
	}
}

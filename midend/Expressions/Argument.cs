using System;
namespace midend
{
	public abstract class Argument
	{
		private readonly Expression value;

		protected Argument(Expression value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			this.value = value;
		}

		public Expression Value => this.value;
	}

	public sealed class NamedArgument : Argument
	{
		private readonly string name;

		public NamedArgument(string name, Expression value) : base(value)
		{
			Signature.ValidateIdentifier(name);
			this.name = name;
		}

		public string Name => this.name;
	}

	public sealed class PositionalArgument : Argument
	{
		private readonly int index;

		public PositionalArgument(int index, Expression value) : base(value)
		{
			if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
			this.index = index;
		}

		public int Index => this.index;
	}
}

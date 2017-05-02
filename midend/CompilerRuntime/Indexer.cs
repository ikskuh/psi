using System;
namespace midend
{
	public abstract class Indexer
	{
		public abstract CType SubscriptType { get; }
	}

	public sealed class ArrayIndexer : Indexer
	{
		private readonly ArrayType type;

		public ArrayIndexer(ArrayType type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			this.type = type;
		}

		public override CType SubscriptType => this.type.ElementType;
	}
}
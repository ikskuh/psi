using System;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public sealed class ArrayIndexExpression : Expression
	{
		private readonly Indexer indexer;
		private readonly Expression[] indexes;
		private readonly Expression value;


		public ArrayIndexExpression(Expression value, Expression[] indexes)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (indexes == null) throw new ArgumentNullException(nameof(value));

			this.value = value;
			this.indexes = indexes;
			this.indexer = this.value.Type.GetIndexer(this.indexes.Select(i => i.Type).ToArray());
			if (this.indexer == null)
				throw new InvalidOperationException("An indexer with the given indices does not exist.");
		}

		public Expression Value => this.value;

		public IReadOnlyList<Expression> Indexes => this.indexes;
		
		public Indexer Indexer => this.indexer;

		public override CType Type => this.indexer.SubscriptType;

		public override CValue Evaluate(EvaluationContext context)
		{
			throw new NotImplementedException();
		}
	}
}

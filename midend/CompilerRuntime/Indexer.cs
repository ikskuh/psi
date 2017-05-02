using System;
using System.Numerics;
namespace midend
{
	public abstract class Indexer
	{
		public abstract CType SubscriptType { get; }

		public virtual bool IsCompileTimeEvaluatable => false;

		public virtual CValue Evaluate(EvaluationContext context, CValue value, CValue[] indices)
		{
			throw new NotSupportedException();
		}
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

		public override bool IsCompileTimeEvaluatable => true;
		
		public override CValue Evaluate(EvaluationContext context, CValue value, CValue[] indices)
		{
			if(indices.Length != 1) throw new InvalidOperationException("Array indexing with more than one index!");
			var array = (CArray)value.Value;
			var index = (BigInteger)indices[0].Value;
			return array[(int)index];
		}
	}
}
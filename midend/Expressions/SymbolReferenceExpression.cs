using System;
namespace midend
{
	/// <summary>
	/// An expression that references a symbol
	/// </summary>
	public sealed class SymbolReferenceExpression : Expression
	{
		private readonly Symbol symbol;

		public SymbolReferenceExpression(Symbol sym)
		{
			if(sym == null) throw new ArgumentNullException(nameof(sym));
			this.symbol = sym;
		}
		
		// TODO: Implement this
		// public override bool IsConstant => this.symbol.IsConst;

		public override CType Type => this.symbol.Type;

		public override CValue Evaluate(EvaluationContext context)
		{
			// TODO: Implement compile time symbol evaluation
			throw new NotImplementedException();
		}
	}
}

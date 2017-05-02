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
		
		public override bool IsConstant => this.symbol.IsConst && this.symbol.HasStaticValue;

		public override CType Type => this.symbol.Type;

		public override CValue Evaluate(EvaluationContext context)
		{
			return this.symbol.InitialValue.Evaluate(context);
		}
		
		public override string ToString() => this.symbol.Name.Name;
	}
}

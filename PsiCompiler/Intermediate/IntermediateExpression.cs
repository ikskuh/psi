using System;
using System.Collections.Generic;
using System.Linq;
namespace Psi.Compiler
{
	public class IntermediateExpression
	{
		public Scope Scope { get; set; }

		public PsiType Type { get; set; }

		public bool IsComplete { get; set; }

		public virtual void Update(ExpressionContext ctx)
		{
			throw new NotSupportedException(this.GetType().Name + " is not supported right now.");
		}

		public virtual void Compile()
		{
			throw new NotSupportedException(this.GetType().Name + " is not supported right now.");
		}
	}

	public sealed class ExpressionContext
	{
		public IReadOnlyCollection<PsiType> TypeHints { get; set; } = new List<PsiType>();
	}

	public sealed class SymbolReference : IntermediateExpression
	{
		public SymbolReference(string name)
		{
			this.Name = name.NotNull();
		}

		public override void Update(ExpressionContext ctx)
		{
			if (this.Scope == null)
				throw new InvalidOperationException();

			var matches = this.Scope.Symbols
				.Where(s => (s.Key.Name == this.Name))
				//.Where(s => (ctx.TypeHints.Count == 0) || ctx.TypeHints.Contains(s.Key.Type))
				.ToArray();
			if (matches.Length == 0)
				return;
			if (matches.Length > 1)
				throw new InvalidOperationException("!");

			this.Symbol = matches[0].Value;
			this.Type = this.Symbol.Type;
			this.IsComplete = true;
		}

		public Symbol Symbol { get; set; }

		public string Name { get; set; }
	}

	public sealed class Literal : IntermediateExpression
	{
		private readonly PsiType[] possibleTypes;
		private readonly string value;

		public Literal(PsiType[] possibleTypes, string value)
		{
			this.possibleTypes = possibleTypes.NotNull();
			this.value = value.NotNull();
		}

		public override void Update(ExpressionContext ctx)
		{
			if (this.possibleTypes.Length == 1)
			{
				this.Type = this.possibleTypes[0];
				this.IsComplete = true;
			}
			else
			{
				if (ctx.TypeHints.Count == 0)
					throw new InvalidOperationException("!");
				
				this.Type = ctx.TypeHints.Intersect(this.possibleTypes).SingleOrDefault();
				if (this.Type != null)
					this.IsComplete = true;
			}
		}
	}
}
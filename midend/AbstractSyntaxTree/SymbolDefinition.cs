using System;
namespace midend
{
	public sealed class SymbolDefinition
	{
		private readonly Module targetModule;
		private readonly AbstractSyntaxTree.VariableDeclaration declaration;

		public SymbolDefinition(Module targetModule, AbstractSyntaxTree.VariableDeclaration variable)
		{
			if (targetModule == null) throw new ArgumentNullException(nameof(targetModule));
			if (variable == null) throw new ArgumentNullException(nameof(declaration));

			this.targetModule = targetModule;
			this.declaration = variable;

			Signature.ValidateIdentifier(this.declaration.Name);

			if (this.declaration.Type == null && this.declaration.Value == null)
				throw new ArgumentException("abstractType or abstractValue or both must be given.");

			if (this.declaration.IsGeneric)
				throw new NotSupportedException("Generic symbols are not supported yet!");
		}

		/// <summary>
		/// Tries to resolve the type of this definition.
		/// Modifies Type when successful.
		/// </summary>
		public void TryResolveType()
		{
			if (this.Type != null)
				throw new InvalidOperationException("Type was already resolved!");
			// TODO: Try resolve the type of this definition via the value!
			if (this.declaration.Type == null)
			{
				this.Type = this.Value?.Type;
			}
			else
			{
				this.Type = this.declaration.Type.TryResolve(this.targetModule.Scope);
			}
		}

		public bool TryCreateValue()
		{
			if (this.InitialValue == null)
				throw new InvalidOperationException("Cannot create value of non-existent prototype!");

			this.Value = this.InitialValue.TryResolve(this.targetModule.Scope);


			return (this.Value != null);
		}

		/// <summary>
		/// Creates and registers the symbol defined here.
		/// </summary>
		/// <returns>The symbol.</returns>
		/// <remarks>Does not create the initial value of this definition!</remarks>
		public Symbol CreateSymbol()
		{
			if (this.Symbol != null)
				throw new InvalidOperationException("The symbol was already created!");
			if (this.Type == null)
				throw new InvalidOperationException("The symbol definition requires a type!");
			this.Symbol = new Symbol(this.Name, this.Type)
			{
				IsConst = this.declaration.IsConstant,
				IsExported = this.declaration.IsExported,
			};
			this.targetModule.Scope.AddSymbol(this.Symbol);
			return this.Symbol;
		}

		public AbstractSyntaxTree.AbstractExpression InitialValue => this.declaration.Value;

		public string Name => this.declaration.Name;

		public Scope TargetScope => this.targetModule.Scope;

		public CType Type { get; set; }

		public Expression Value { get; set; }

		public Symbol Symbol { get; private set; }

		public bool CanCreateSymbol => (this.Type != null);

		// TODO: Resolve this!
		public bool CanCreateValue => (this.InitialValue != null);
	}
}

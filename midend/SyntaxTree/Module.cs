using System;
using System.Collections.Generic;
namespace midend
{
	public sealed class Module
	{
		private readonly string name;
		private readonly Module parent;
		private readonly Scope scope;
		private readonly Dictionary<string, Module> subModules = new Dictionary<string, Module>();
		private readonly List<Assertion> assertions = new List<Assertion>();


		/// <summary>
		/// Creates the root module that does not contain any superior scopes or modules.
		/// </summary>
		internal Module()
		{
			this.name = "[::]";
			this.parent = null;
			this.scope = new Scope(null);
		}

		public Module(string name, Module parent)
		{
			Signature.ValidateIdentifier(name);
			this.name = name;
			this.parent = parent;
			this.scope = new Scope(this.parent?.Scope);
		}

		public Assertion AddAssertion(Expression claim)
		{
			var assert = new Assertion(this, claim);
			this.assertions.Add(assert);
			return assert;
		}

		public Module GetSubModule(string name, bool autoCreate = false)
		{
			Module module;
			if (this.subModules.TryGetValue(name, out module))
				return module;
			if (autoCreate == false)
				throw new ArgumentOutOfRangeException(nameof(name), "The given module does not exist!");
			else
				return this.AddSubModule(name);
		}

		public Module AddSubModule(string name)
		{
			var module = new Module(name, this);

			this.scope.AddSymbol(new Symbol(name, CTypes.Module)
			{
				IsConst = true,
				IsExported = true,
				InitialValue = Expression.Constant(module),
			});

			this.subModules.Add(name, module);

			return module;
		}

		public Scope Scope => this.scope;

		public IReadOnlyList<Assertion> Assertions => this.assertions;

		public IReadOnlyDictionary<string, Module> SubModules => this.subModules;

		public string Name => this.name;

		public override string ToString()
		{
			if (this.parent == null)
				return this.name;
			else
				return this.parent.name + "." + this.name;
		}
	}
}

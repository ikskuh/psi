using System;
namespace midend
{
	public sealed class Assertion
	{
		private readonly Module module;
		private readonly Expression claim;

		public Assertion(Module module, Expression claim)
		{
			if (module == null) throw new ArgumentNullException(nameof(module));
			if (claim == null) throw new ArgumentNullException(nameof(claim));
			this.module = module;
			this.claim = claim;
			if (this.claim.Type != CTypes.Boolean)
				throw new InvalidOperationException("Assertion is not of boolean type!");
		}

		public bool Validate(bool throwOnFailure = true)
		{
			var value = this.claim.Execute();
			var result = value.Get<bool>();
			if (throwOnFailure && (result == false))
				throw new InvalidOperationException("Assertion has failed!");
			return result;
		}
		
		public Module Module => this.module;
		
		public Expression Claim => this.claim;
	}
}

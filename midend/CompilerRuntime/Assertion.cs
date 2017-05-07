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

		public void Validate()
		{
			var value = this.claim.Execute();
			if (value.Get<bool>() == false)
				throw new InvalidOperationException("Assertion is not boolean or it has failed!");
		}
	}
}

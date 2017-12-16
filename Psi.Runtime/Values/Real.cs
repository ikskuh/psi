using System;
namespace Psi.Runtime
{
	public sealed class Real : Value, IPrimitiveValue<double>
	{
		private readonly double value;

		public Real(double value) : base(RealType.Instance)
		{
			this.value = value;
		}

		public static implicit operator double(Real i) => i.value;

		public static implicit operator Real(double i) => new Real(i);

		public double Value => this.value;

		public override string ToString() => value.ToString();
	}
}

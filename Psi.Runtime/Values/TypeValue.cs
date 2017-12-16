using System;
namespace Psi.Runtime
{
	public sealed class TypeValue : Value, IPrimitiveValue<Type>
	{
		private readonly Type value;

		public TypeValue(Type value) : base(IntegerType.Instance)
		{
			this.value = value;
		}

		public static implicit operator Type(TypeValue i) => i.value;

		public static implicit operator TypeValue(Type i) => new TypeValue(i);

		public Type Value => this.value;

		public override string ToString() => value.ToString();
	}
}

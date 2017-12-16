using System;
namespace Psi.Runtime
{
	public interface IPrimitiveValue<T> where T : IEquatable<T>
	{
		T Value { get; }
	}
}
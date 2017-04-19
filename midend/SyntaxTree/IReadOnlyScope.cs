using System.Collections.Generic;
namespace midend
{
	public interface IReadOnlyScope
	{
		Symbol this[Signature name] { get; }
		
		IEnumerable<Signature> Locals { get; }
	}
}
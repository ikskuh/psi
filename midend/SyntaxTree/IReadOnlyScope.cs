using System.Collections.Generic;
namespace midend
{
	public interface IReadOnlyScope
	{
		Symbol this[Signature name] { get; }
		
		Symbol this[string name, CType type] { get; }
		
		IEnumerable<Signature> Locals { get; }
	}
}
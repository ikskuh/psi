using Psi.Runtime;

namespace Psi.Compiler.Resolvation
{
	public interface IResolvationResult
	{
		bool IsEvaluatable { get; }
		
		Value Evaluate(ExecutionContext ctx);
	
		Runtime.Type Type { get; }
	}
}
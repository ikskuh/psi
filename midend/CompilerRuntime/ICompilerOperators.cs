using System;
namespace midend
{
	public delegate CValue BinaryCompilerOperator(CValue lhs, CValue rhs);
	
	public delegate CValue UnaryCompilerOperator(CValue lhs);
	
	public delegate CValue FunctionCallCompilerOperator(params CValue[] args);

	public interface ICompilerOperators
	{
		BinaryCompilerOperator Addition { get; }
		BinaryCompilerOperator Subtraction { get; }
		BinaryCompilerOperator Multiplication { get; }
		BinaryCompilerOperator Division { get; }
		BinaryCompilerOperator EuclideanDivision { get; }
		
		BinaryCompilerOperator LessThan { get; }
		BinaryCompilerOperator LessEqual { get; }
		BinaryCompilerOperator GreaterThan { get; }
		BinaryCompilerOperator GreaterEquals { get; }
		BinaryCompilerOperator Equals { get; }
		BinaryCompilerOperator Differs { get; }
		
		BinaryCompilerOperator Arrow { get; }
		BinaryCompilerOperator Assignment { get; }
		BinaryCompilerOperator Concatenate { get; }
		
		UnaryCompilerOperator Plus { get; }
		UnaryCompilerOperator Minus { get; }
		UnaryCompilerOperator Not { get; }
	}
}

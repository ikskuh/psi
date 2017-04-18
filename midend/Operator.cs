namespace midend.AbstractSyntaxTree
{
	using System.Xml.Serialization;

	public enum OperatorType
	{
		[XmlEnum("unary")] Unary,
		[XmlEnum("binary")] Binary,
		[XmlEnum("special")] Special,
	}

	public enum Operator
	{
		// TODO: Add all operators!
		[XmlEnum("+")] Add,
		[XmlEnum("-")] Sub,
		[XmlEnum("*")] Times,
		[XmlEnum("/")] Divide,
		[XmlEnum("%")] Modulo,
		[XmlEnum("**")] Exponentiate,
		
		[XmlEnum("~")] Invert,
		[XmlEnum("&")] And,
		[XmlEnum("|")] Or,
		[XmlEnum("^")] Xor,
		
		[XmlEnum("<<")] ShiftLeft,
		[XmlEnum(">>")] ShiftRight,
		
		[XmlEnum("->")] Arrow,
		[XmlEnum("--")] Concatenate,
		
		[XmlEnum("==")] Equals,
		[XmlEnum("!=")] Inequals,
		[XmlEnum(">")] Greater,
		[XmlEnum("<")] Less,
		[XmlEnum(">=")] GreaterEquals,
		[XmlEnum("<=")] LessEquals,
		
		[XmlEnum("=")] Assignment,
		
		[XmlEnum("+=")] AssignmentAdd,
		[XmlEnum("-=")] AssignmentSubtraction,
		[XmlEnum("*=")] AssignmentMultiplication,
		[XmlEnum("/=")] AssignmentDivision,
		[XmlEnum("%=")] AssignmentModulo,
		[XmlEnum("|=")] AssignmentOr,
		[XmlEnum("&=")] AssignmentAnd,
		[XmlEnum("^=")] AssignmentXor,
		[XmlEnum("--=")] AssignmentConcat,
		[XmlEnum(":=")] AddressAssignment,
		
		// Special operators
		[XmlEnum("()")] FunctionCall,
		[XmlEnum("[]")] Indexer,
	}
}
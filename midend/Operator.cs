namespace midend.AbstractSyntaxTree
{
	using System.Xml.Serialization;

	public enum Operator
	{
		// TODO: Add all operators!
		[XmlEnum("+")] Add,
		[XmlEnum("-")] Sub,
		[XmlEnum("*")] Times,
		[XmlEnum("/")] Divide,
		[XmlEnum("%")] Modulo,
		
		[XmlEnum("=")] Assignment,
		[XmlEnum("->")] Arrow,
		
		[XmlEnum("==")] Equals,
		[XmlEnum("!=")] Inequals,
		[XmlEnum(">")] Greater,
		[XmlEnum("<")] Less,
		[XmlEnum(">=")] GreaterEquals,
		[XmlEnum("<=")] LessEquals,
	}
}
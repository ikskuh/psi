using System;
using System.IO;
using System.Xml.Serialization;
namespace midend
{
	using midend.AbstractSyntaxTree;

	public static class AST
	{
		public static Program Load(TextReader reader)
		{
			var ser = new XmlSerializer(typeof(Program));
			ser.UnknownElement += (s,e) =>
			{
				Console.Error.WriteLine("Unknown node: {0}.{1}", e.ObjectBeingDeserialized.GetType().Name, e.Element.Name);
			};
			return (Program)ser.Deserialize(reader);
		}

		public static void Store(TextWriter writer, Program root)
		{
			var ser = new XmlSerializer(typeof(Program));
			ser.Serialize(writer, root);
		}
	}

	namespace AbstractSyntaxTree
	{
		using System.Xml.Serialization;

		[XmlRoot("program")]
		public sealed class Program
		{
			[XmlElement("import")]
			public Import[] Imports { get; set; }

			[XmlElement("vardecl")]
			public VariableDeclaration[] Variables { get; set; }
		}

		public sealed class Param
		{
			[XmlElement("name")]
			public string Name { get; set; }
			
			[XmlElement("type")]
			public AbstractType Type { get; set; }
		}

		public sealed class Import
		{
			[XmlElement("module")]
			public ObjectName Module { get; set; }

			[XmlElement("alias")]
			public string Alias { get; set; }
		}

		public sealed class VariableDeclaration
		{
			[XmlElement("type")]
			public AbstractType Type { get; set; }

			[XmlElement("value")]
			public AbstractExpression Value { get; set; }

			[XmlElement("name")]
			public string Name { get; set; }

			[XmlElement("isConst")]
			public bool IsConstant { get; set; }

			[XmlElement("isExported")]
			public bool IsExported { get; set; }

			[XmlElement("isGeneric")]
			public bool IsGeneric { get; set; }

			// TODO: Implement generic declarations!
		}

		#region Types

		[XmlInclude(typeof(TypeReference))]
		[XmlInclude(typeof(TypeFunction))]
		public abstract class AbstractType
		{

		}

		public sealed class TypeReference : AbstractType
		{
			[XmlElement("name")]
			public ObjectName Name { get; set; }
			
			[XmlArray("args"), XmlArrayItem("expression")]
			public AbstractExpression[] Arguments { get; set; }
		}

		public sealed class TypeFunction : AbstractType
		{
			[XmlArray("params"), XmlArrayItem("param")]
			public Param[] Parameters { get; set; }
			
			[XmlElement("returntype")]
			public AbstractType ReturnType { get; set; }
			
			[XmlArray("restrictions"), XmlArrayItem("expression")]
			public AbstractExpression[] Restrictions { get; set; }
		}
		
		#endregion

		#region Expression

		[XmlInclude(typeof(ExpressionNumber))]
		[XmlInclude(typeof(ExpressionString))]
		[XmlInclude(typeof(ExpressionBinaryOperator))]
		[XmlInclude(typeof(ExpressionUnaryOperator))]
		[XmlInclude(typeof(ExpressionSymbol))]
		[XmlInclude(typeof(ExpressionFunction))]
		[XmlInclude(typeof(ExpressionIndex))]
		public abstract class AbstractExpression
		{
			
		}

		public sealed class ExpressionNumber : AbstractExpression
		{
			[XmlElement("value")]
			public string Value { get; set; }
		}

		public sealed class ExpressionString : AbstractExpression
		{
			[XmlElement("value")]
			public string Value { get; set; }
		}
		
		public sealed class ExpressionSymbol : AbstractExpression
		{
			[XmlElement("name")]
			public string Symbol { get; set; }
		}

		public sealed class ExpressionBinaryOperator : AbstractExpression
		{
			[XmlElement("lhs")]
			public AbstractExpression LeftHandSide { get; set; }

			[XmlElement("rhs")]
			public AbstractExpression RightHandSide { get; set; }

			[XmlElement("operator")]
			public Operator Operator { get; set; }
		}

		public sealed class ExpressionUnaryOperator : AbstractExpression
		{
			[XmlElement("value")]
			public AbstractExpression Value { get; set; }

			[XmlElement("operator")]
			public Operator Operator { get; set; }
		}
		
		public sealed class ExpressionFunction : AbstractExpression
		{
			[XmlElement("signature")]
			public TypeFunction Signature { get; set; }
			
			[XmlElement("body")]
			public AbstractInstruction Body { get; set; }
		}
		
		public sealed class ExpressionIndex : AbstractExpression
		{
			[XmlElement("value")]
			public AbstractExpression Value { get; set; }
			
			[XmlElement("index")]
			public AbstractIndex Index { get; set; }	
		}
		
		#endregion
		
		#region Indices
		
		[XmlInclude(typeof(IndexArray))]
		[XmlInclude(typeof(IndexField))]
		[XmlInclude(typeof(IndexMeta))]
		[XmlInclude(typeof(IndexCall))]
		public abstract class AbstractIndex 
		{
		
		}
		
		public sealed class IndexArray : AbstractIndex
		{
		
		}
		
		public sealed class IndexField : AbstractIndex
		{
			[XmlElement("field")]
			public string Field { get; set; }
		}
		
		public sealed class IndexMeta : AbstractIndex
		{
			[XmlElement("field")]
			public string Field { get; set; }
		}
		
		public sealed class IndexCall : AbstractIndex
		{
			[XmlArray("arguments"), XmlArrayItem("argument")]
			public AbstractArgument[] Arguments { get; set; }
		}
		
		[XmlInclude(typeof(ArgumentPositional))]
		[XmlInclude(typeof(ArgumentNamed))]
		public abstract class AbstractArgument
		{
			[XmlElement("value")]
			public AbstractExpression Value { get; set; }
		}
		
		public sealed class ArgumentPositional : AbstractArgument
		{
			[XmlElement("position")]
			public int Position { get; set; }
		}
		
		public sealed class ArgumentNamed : AbstractArgument
		{
			[XmlElement("name")]
			public string Name { get; set; }
		}
		
		#endregion
		
		#region Instructions
		
		[XmlInclude(typeof(InstructionBody))]
		[XmlInclude(typeof(InstructionExpression))]
		[XmlInclude(typeof(InstructionConditional))]
		[XmlInclude(typeof(InstructionReturn))]
		[XmlInclude(typeof(InstructionFor))]
		public abstract class AbstractInstruction
		{
		
		}
		
		public sealed class InstructionBody : AbstractInstruction
		{
			[XmlElement("instruction")]
			public AbstractInstruction[] Instructions { get; set; }

			[XmlElement("vardecl")]
			public VariableDeclaration[] Variables { get; set; }
		}
		
		public sealed class InstructionExpression : AbstractInstruction
		{
			[XmlElement("expression")]
			public AbstractExpression Expression { get; set; }
		}
		
		public sealed class InstructionConditional : AbstractInstruction
		{
			[XmlElement("condition")]
			public AbstractExpression Condition { get; set; }
			
			[XmlElement("positive")]
			public AbstractInstruction Positive { get; set; }
			
			[XmlElement("negative")]
			public AbstractInstruction Negative { get; set; }
		}

		public sealed class InstructionReturn : AbstractInstruction
		{
			[XmlElement("expression")]
			public AbstractExpression Value { get; set; }
		}

		public sealed class InstructionFor : AbstractInstruction
		{
			[XmlElement("variable")]
			public string Variable { get; set; }
		
			[XmlElement("expression")]
			public AbstractExpression Value { get; set; }
			
			[XmlElement("vartype")]
			public AbstractType Type { get; set; }
			
			[XmlElement("body")]
			public AbstractInstruction Body { get; set; }
		}

		#endregion
	}
}

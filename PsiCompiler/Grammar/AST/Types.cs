using System;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Grammar
{

	public abstract class AstType
	{
		public virtual PsiType CreateIntermediate()
		{
			throw new NotSupportedException();
		}
	}

	public sealed class LiteralType : AstType
	{
		public LiteralType(PsiType type)
		{
			this.Type = type;
		}
		
		public override PsiType CreateIntermediate() => this.Type;

		public PsiType Type { get; }
		
		public override string ToString() => this.Type.ToString();
	}

	public sealed class NamedTypeLiteral : AstType
	{
		public NamedTypeLiteral(CompoundName name)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			this.Name = name;
		}
		
		public override PsiType CreateIntermediate() => new NamedType(this);
	
		public CompoundName Name { get; }
		
		public override string ToString() => this.Name.ToString();
	}

	public sealed class FunctionTypeLiteral : AstType
	{
		public FunctionTypeLiteral(IEnumerable<Parameter> parameters, AstType returnType)
		{
			this.Parameters = parameters.ToArray();
			this.ReturnType = returnType;
		}
		
		public override PsiType CreateIntermediate() => new FunctionType(this);

		public IReadOnlyList<Parameter> Parameters { get; }

		public AstType ReturnType { get; }

		public override string ToString() => string.Format("fn({0}) -> {1}", string.Join(", ", Parameters), ReturnType);
	}

	public sealed class Parameter
	{
		public Parameter(ParameterFlags prefix, string name, AstType type, Expression value)
		{
			this.Prefix = prefix;
			this.Name = name.NotNull();
			this.Type = type;
			this.Value = value;
		}

		public string Name { get; }

		public AstType Type { get; }

		public Expression Value { get; }

		public ParameterFlags Prefix { get; }

		public override string ToString() => string.Format("{0} {1} : {2} = {3}", Prefix, Name, Type, Value);
	}


	[Flags]
	public enum ParameterFlags
	{
		None = 0,
		In = 1,
		Out = 2,
		InOut = In | Out,
		This = 4,
		Lazy = 8
	}


	public sealed class EnumTypeLiteral : AstType
	{
		public EnumTypeLiteral(IEnumerable<string> items)
		{
			this.Items = items.ToArray();
			if (this.Items.Distinct().Count() != this.Items.Count)
				throw new InvalidOperationException("Enums allow no duplicates!");
		}
		
		public override PsiType CreateIntermediate()
		{
			return new EnumType(this.Items.ToArray());
		}

		public IReadOnlyList<string> Items { get; }

		public override string ToString() => string.Format("enum({0})", string.Join(", ", Items));
	}

	public sealed class TypedEnumTypeLiteral : AstType
	{
		public TypedEnumTypeLiteral(AstType type, IEnumerable<Declaration> items)
		{
			this.Type = type.NotNull();
			this.Items = items.NotNull().ToArray();
			if (this.Items.Any(i => !i.IsField || i.IsConst || i.IsExported || i.Type != PsiParser.Undefined))
				throw new InvalidOperationException();
		}

		public AstType Type { get; }

		public IReadOnlyList<Declaration> Items { get; }

		public override string ToString() => string.Format("enum<{0}>({1})", Type, string.Join(", ", Items));
	}

	public sealed class ReferenceTypeLiteral : AstType
	{
		public ReferenceTypeLiteral(AstType objectType)
		{
			this.ObjectType = objectType.NotNull();
		}
		
		public override PsiType CreateIntermediate() => new ReferenceType(this);

		public AstType ObjectType { get; }

		public override string ToString() => string.Format("ref<{0}>", ObjectType);

	}

	public sealed class ArrayTypeLiteral : AstType
	{
		public ArrayTypeLiteral(AstType objectType, int dimensions)
		{
			if (dimensions <= 0)
				throw new ArgumentOutOfRangeException(nameof(dimensions));
			this.Dimensions = dimensions;
			this.ElementType = objectType.NotNull();
		}
		
		public override PsiType CreateIntermediate() => new ArrayType(this);

		public AstType ElementType { get; }

		public int Dimensions { get; }

		public override string ToString() => string.Format("array<{0},{1}>", ElementType, Dimensions);

	}

	public sealed class RecordTypeLiteral : AstType
	{
		public RecordTypeLiteral(IEnumerable<Declaration> fields)
		{
			this.Fields = fields.ToArray();
		}
		
		public override PsiType CreateIntermediate() => new RecordType(this);

		public IReadOnlyList<Declaration> Fields { get; }

		public override string ToString() => string.Format("record({0})", string.Join(", ", Fields));
	}
}

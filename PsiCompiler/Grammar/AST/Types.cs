using System;
using System.Collections.Generic;
using System.Linq;
using Psi.Compiler.Resolvation;
using Psi.Runtime;

namespace Psi.Compiler.Grammar
{
	using Type = Psi.Runtime.Type;

	public abstract class AstType
	{
		public virtual IEnumerable<Type> Resolve(ResolvationContext ctx)
		{
			throw new NotImplementedException(this.GetType().Name + " requires an implementation!" );
		}
	}

	public sealed class LiteralType : AstType
	{
		public LiteralType(Type type)
		{
			this.Type = type;
		}

		public override IEnumerable<Type> Resolve(ResolvationContext ctx)
		{
			yield return this.Type;
		}

		public Type Type { get; }
		
		public override string ToString() => this.Type.ToString();
	}

	public sealed class NamedTypeLiteral : AstType
	{
		public NamedTypeLiteral(CompoundName name)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			this.Name = name;
		}
		
		public override IEnumerable<Type> Resolve(ResolvationContext ctx)
		{
			for(int i = 0; i < this.Name.Count - 1; i++)
			{
				if(ctx.Modules.ContainsKey(this.Name[i]) == false)
					return new Type[0];
				ctx = ctx.Modules[this.Name[i]];
			}
			var name = this.Name.Last();
			if(ctx.Types.ContainsKey(name))
				return new [] { ctx.Types[name].Type };
			else
				return new Type[0];
		}
	
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

		public override IEnumerable<Type> Resolve(ResolvationContext ctx)
		{
			var paramlists = this.Parameters.Select(p => p.Resolve(ctx).ToArray()).ToArray().Permutate().ToList();
			var results = this.ReturnType.Resolve(ctx).ToArray();
			if (results.Length == 0 || paramlists.Count == 0)
				return new Type[0];
			if (results.Length != 1)
				throw new InvalidOperationException("Non-distinct return type!");
			if (paramlists.Count != 1)
				throw new InvalidOperationException("Non-distinct parameter list!");

			return new[]
			{
				new FunctionType(
					results[0],
					paramlists[0])
			};
		}

		public IReadOnlyList<Parameter> Parameters { get; }

		public AstType ReturnType { get; }

		public override string ToString() => string.Format("fn({0}) -> {1}", string.Join(", ", Parameters), ReturnType);
	}

	public sealed class Parameter
	{
		public Parameter(Psi.Runtime.ParameterFlags prefix, string name, AstType type, Expression value)
		{
			this.Prefix = prefix;
			this.Name = name.NotNull();
			this.Type = type;
			this.Value = value;
		}

		public IEnumerable<Psi.Runtime.Parameter> Resolve(ResolvationContext ctx)
		{
			var types = this.Type.Resolve(ctx).ToArray();
			if (this.Value != null)
				throw new NotSupportedException("Default arguments are not supported yet!");
			foreach (var type in types)
				yield return new Psi.Runtime.Parameter(this.Name, type);
		}

		public string Name { get; }

		public AstType Type { get; }

		public Expression Value { get; }

		public Psi.Runtime.ParameterFlags Prefix { get; }

		public override string ToString() => string.Format("{0} {1} : {2} = {3}", Prefix, Name, Type, Value);
	}



	public sealed class EnumTypeLiteral : AstType
	{
		public EnumTypeLiteral(IEnumerable<string> items)
		{
			this.Items = items.ToArray();
			if (this.Items.Distinct().Count() != this.Items.Count)
				throw new InvalidOperationException("Enums allow no duplicates!");
		}

		public override IEnumerable<Type> Resolve(ResolvationContext ctx)
		{
			yield return new EnumType(this.Items.ToArray());
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
			this.ObjectType = objectType.NotNull();
		}

		public override IEnumerable<Type> Resolve(ResolvationContext ctx)
		{
			foreach(var elem in this.ObjectType.Resolve(ctx))
				yield return new ArrayType(elem, this.Dimensions);
		}

		public AstType ObjectType { get; }

		public int Dimensions { get; }

		public override string ToString() => string.Format("array<{0},{1}>", ObjectType, Dimensions);

	}

	public sealed class RecordTypeLiteral : AstType
	{
		public RecordTypeLiteral(IEnumerable<Declaration> fields)
		{
			this.Fields = fields.ToArray();
		}

		public IReadOnlyList<Declaration> Fields { get; }

		public override string ToString() => string.Format("record({0})", string.Join(", ", Fields));
	}
}

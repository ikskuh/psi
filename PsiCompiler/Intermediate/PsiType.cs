using System;
using System.Linq;
using System.Collections.Generic;
namespace Psi.Compiler
{
	public class PsiType
	{
		public static PsiType Void => VoidType.Instance;
		public static PsiType Integer => IntegerType.Instance;
		public static PsiType Real => RealType.Instance;
		public static PsiType Character => CharacterType.Instance;
		public static PsiType Boolean => BooleanType.Instance;
		public static PsiType Type => PsiTypeType.Instance;
		public static PsiType String { get; } = new ArrayType(CharacterType.Instance, 1);
	
		public string Name { get; set; }
		
		public bool IsComplete { get; protected set; }
		
		public bool IsExported { get; set; }
		
		public virtual void Update(Scope scope)
		{
			throw new NotSupportedException(this.GetType().Name + " is not supported yet!");
		}
		
		/// <summary>
		/// Remove all NamedType References
		/// </summary>
		public virtual PsiType Compact() => this;
		
		public override string ToString() => string.Format("{0} {1}", this.Name ?? "<unnamed>", this.IsComplete ? "y" : "n");
	}
	
	// for real builtins, but also for non-typed enums
	public abstract class BuiltinType : PsiType
	{
		protected BuiltinType()
		{
			this.IsComplete = true;
		}
		
		public override void Update(Scope scope)
		{
			throw new NotSupportedException("Builtin types are not updateable.");
		}
	}
	
	public class NamedType : PsiType
	{
		private readonly Grammar.NamedTypeLiteral literal;
		
		public NamedType(Grammar.NamedTypeLiteral literal)
		{
			this.literal = literal.NotNull();
		}
		
		public override void Update(Scope scope)
		{
			var name = this.literal.Name;
			
			for(int i = 0; i < (name.Count - 1); i++)
				scope = scope.Modules[name[i]];
			
			this.ReferencedType = scope.Types[name.Identifier];
			if(this.ReferencedType == null)
				return;
			
			if(this.ReferencedType.IsComplete == false)
				return;
			
			this.IsComplete = true;
		}
		
		public override PsiType Compact() => this.ReferencedType.Compact();
		
		public PsiType ReferencedType { get; private set; }
		
		public override string ToString() => this.literal.Name.ToString();
	}
	
	public class RecordType : PsiType
	{
		// TODO: Implement field default values
	
		private readonly Grammar.RecordTypeLiteral literal;
		
		public RecordType(Grammar.RecordTypeLiteral literal)
		{
			this.literal = literal.NotNull();
			this.Fields = literal.Fields.Select(f => new Field { Name = f.Name, Type = f.Type.CreateIntermediate() }).ToArray();
		}
		
		public override void Update(Scope scope)
		{
			foreach(var fld in this.Fields)
			{
				if(fld.Type.IsComplete)
					continue;
				fld.Type.Update(scope);
			}
			if(this.Fields.Any(f => !f.Type.IsComplete))
				return;
			this.IsComplete = true;
		}
		
		public IReadOnlyList<Field> Fields { get; }
		
		public override string ToString() => "record(" + string.Join(",",Fields) + ")";
		
		public sealed class Field
		{
			public PsiType Type { get; set; }
			
			public string Name { get; set; }
			
			// TODO: Implement field default values
			
			public override string ToString() => Name + " : " + Type;
		}
		
	}
	
	public class ReferenceType : PsiType
	{
		private readonly Grammar.ReferenceTypeLiteral literal;
		
		public ReferenceType(Grammar.ReferenceTypeLiteral literal)
		{
			this.literal = literal.NotNull();
			this.ReferencedType = this.literal.ObjectType.CreateIntermediate();
		}
		
		public override void Update(Scope scope)
		{
			if(!this.ReferencedType.IsComplete)
				this.ReferencedType.Update(scope);
			this.IsComplete = this.ReferencedType.IsComplete;
		}
		
		public PsiType ReferencedType { get; set; }
		
		public override string ToString() => "ref<" + ReferencedType + ">";
	}
	
	public class ArrayType : PsiType
	{
		public ArrayType(PsiType elementType, int dimensions)
		{
			if(elementType == null) throw new ArgumentNullException(nameof(elementType));
			if(dimensions <= 0) throw new ArgumentOutOfRangeException(nameof(dimensions));
			this.ElementType = elementType;
			this.Dimensions = dimensions;
			this.IsComplete = true;
		}
		
		private readonly Grammar.ArrayTypeLiteral literal;
		
		public ArrayType(Grammar.ArrayTypeLiteral literal)
		{
			this.literal = literal.NotNull();
			this.Dimensions = this.literal.Dimensions;
			this.ElementType = this.literal.ElementType.CreateIntermediate();
			this.IsComplete = this.ElementType.IsComplete;
		}
		
		public override void Update(Scope scope)
		{
			this.ElementType.Update(scope);
			this.IsComplete = this.ElementType.IsComplete;
		}
		
		public int Dimensions { get; private set; }
		
		public PsiType ElementType { get; private set; }
		
		public override string ToString() => "array<" + ElementType + "," + Dimensions + ">";
	}
	
	public class FunctionType : PsiType
	{
		private readonly Grammar.FunctionTypeLiteral literal;
		
		public FunctionType(Grammar.FunctionTypeLiteral literal)
		{
			this.literal = literal.NotNull();
			this.ReturnType = literal.ReturnType.CreateIntermediate();
			this.Parameters = literal.Parameters.Select(p => new Parameter { Name = p.Name, Type = p.Type.CreateIntermediate() }).ToArray();
		}
		
		public override void Update(Scope scope)
		{
			if(!this.ReturnType.IsComplete)
				this.ReturnType.Update(scope);
			foreach(var p in this.Parameters)
			{
				if(p.Type.IsComplete)
					continue;
				p.Type.Update(scope);
			}
			
			this.IsComplete = this.ReturnType.IsComplete && this.Parameters.All(p => p.Type.IsComplete);
		}
		
		public PsiType ReturnType { get; }
		
		public IReadOnlyList<Parameter> Parameters { get; }
		
		public override string ToString() => "fn(" + string.Join(",",Parameters) + ") -> " + ReturnType;
		
		public sealed class Parameter
		{
			public PsiType Type { get; set; }
			
			public string Name { get; set; }
			
			// TODO: Implement default values
			
			public override string ToString() => Name + " : " + Type;
		}
	}
	
	public class EnumType : PsiType
	{
		public EnumType(IEnumerable<string> items)
		{
			this.Items = items.Distinct().ToArray();
			this.IsComplete = true;
		}
		
		public IReadOnlyList<string> Items { get; }
		
		public override string ToString() => "enum(" + string.Join(",",Items) + ")";
	}
}
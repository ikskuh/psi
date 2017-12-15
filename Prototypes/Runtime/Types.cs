using System;
using System.Collections.Generic;
using System.Linq;
namespace Runtime
{
	// Type prototype
	public sealed class BooleanType : Type
	{
		public static Type Instance { get; } = new BooleanType();
		
		private BooleanType() { }
	}
	
	public sealed class IntegerType : Type
	{
		public static Type Instance { get; } = new IntegerType();
		
		private IntegerType() { }
	}
	
	public sealed class CharacterType : Type
	{
		public static Type Instance { get; } = new CharacterType();
		
		private CharacterType() { }
	}
	
	public sealed class ArrayType : Type
	{
		public ArrayType(Type elementType) : this(elementType, 1)
		{
		
		}
	
		public ArrayType(Type elementType, int dims)
		{
			if(elementType == null) throw new ArgumentNullException(nameof(elementType));
			if(dims < 1) throw new ArgumentOutOfRangeException(nameof(dims));
			this.ElementType = elementType;
			this.Dimensions = dims;
		}
		
		public Type ElementType { get; }
		
		public int Dimensions { get; }
	}
	
	// Type prototype
	public sealed class FunctionType : Type
	{		
		public FunctionType() : this(VoidType.Instance)
		{
			
		}
		
		public FunctionType(params Parameter[] @params) : this(VoidType.Instance, @params)
		{
			
		}
		
		public FunctionType(Type returnType, params Parameter[] @params)
		{
			if(returnType == null) throw new ArgumentNullException(nameof(returnType));
			if(@params ==null) throw new ArgumentNullException(nameof(@params));
			this.ReturnType = returnType;
			this.Parameters = @params.ToArray();
		}
	
		public IReadOnlyList<Parameter> Parameters { get; }
		
		public Type ReturnType { get; }
	}
	
	public sealed class VoidType : Type
	{
		public static Type Instance { get; } = new VoidType();
		
		private VoidType() { }
	}
	
	public sealed class Parameter
	{
		public Parameter(string name, Type type) : this(name, type, ParameterFlags.In)
		{
			
		}
	
		public Parameter(string name, Type type,  ParameterFlags flags)
		{
			if(name == null) throw new ArgumentNullException(nameof(name));
			if(type == null) throw new ArgumentNullException(nameof(type));
		
			this.Name = name;
			this.Type = type;
			this.Flags = flags;
		}
		
		public string Name { get; }
		
		public Type Type { get; }
		
		public ParameterFlags Flags { get; }
		
		public override string ToString() => $"{Flags} {Name} : {Type}";
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
}

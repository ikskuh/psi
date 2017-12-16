using System;
using System.Collections.Generic;
using System.Linq;
namespace Psi.Runtime
{

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
			if (returnType == null) throw new ArgumentNullException(nameof(returnType));
			if (@params == null) throw new ArgumentNullException(nameof(@params));
			this.ReturnType = returnType;
			this.Parameters = @params.ToArray();
		}
		
		public override bool Equals(Type other)
		{
			var fun = other as FunctionType;
			return Enumerable.SequenceEqual(this.Parameters, fun?.Parameters)
				&& object.Equals(this.ReturnType, fun?.ReturnType);
		}

		public override int GetHashCode() => (0x05 << 24) | (0xFFFFFF & ((this.Parameters.Select(p => p.GetHashCode()).Aggregate(0, (a,b) => a^b) >> 8) ^ this.ReturnType.GetHashCode()));

		public IReadOnlyList<Parameter> Parameters { get; }

		public Type ReturnType { get; }
	}

	public sealed class Parameter : IEquatable<Parameter>
	{
		public Parameter(string name, Type type) : this(name, type, ParameterFlags.In)
		{

		}

		public Parameter(string name, Type type, ParameterFlags flags)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (type == null) throw new ArgumentNullException(nameof(type));

			this.Name = name;
			this.Type = type;
			this.Flags = flags;
		}
		
		public override bool Equals(object obj) => this.Equals(obj as Parameter);

		public bool Equals(Parameter other)
		{
			return object.Equals(this.Name, other?.Name)
				&& object.Equals(this.Type, other?.Type)
				&& object.Equals(Filter(this.Flags), Filter(other?.Flags));
		}
		
		public override int GetHashCode() => this.Name.GetHashCode() << 3 ^ this.Type.GetHashCode() ^ Filter(this.Flags).GetHashCode();
		
		private static ParameterFlags? Filter(ParameterFlags? flags) => (flags != null) ? Filter(flags.Value) : flags;
		
		private static ParameterFlags Filter(ParameterFlags flags)
		{
			return (flags & ~ParameterFlags.This);
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

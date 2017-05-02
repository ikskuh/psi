using System;

namespace midend
{
	/// <summary>
	/// An abstract psi language type.
	/// </summary>
	public abstract class CType
	{
		protected CType()
		{

		}
		
		public virtual bool IsAllowedValue(object value)
		{
			// Basic semantics, should be implemented by each subclass
			return (value != null);
		}

		public bool CanBeAssignedFrom(CType type) => type.CanBeAssignedTo(this);
		
		public virtual bool CanBeAssignedTo(CType type)
		{
			// By default, allow no coalescing
			return this.Equals(type);
		}
		
		public Indexer GetIndexer(params CType[] types)
		{
			return null;
		}
		
		public virtual Field GetField(string name)
		{
			Signature.ValidateIdentifier(name);
			return null;
		}
		
		public virtual Field GetMetaField(string name)
		{
			Signature.ValidateIdentifier(name);
			switch(name)
			{
				case "type": return new ConstantField(CTypes.Type, this);
			}
			return null;
		}
	}

	public static class CTypes
	{
		private sealed class VoidType : CType { }

		/// <summary>
		/// The type that marks an invalid type.
		/// </summary>
		public static readonly CType Void = new VoidType();

		/// <summary>
		/// The basic string type that can be used for text operations.
		/// </summary>
		public static readonly CType String = StringType.Instance;

		/// <summary>
		/// The type that is used for referencing system types.
		/// </summary>
		public static readonly CType Type = TypeType.Instance;

		/// <summary>
		/// The type that is used for referencing modules.
		/// </summary>
		public static readonly CType Module = ModuleType.Instance;

		/// <summary>
		/// The type that is used for referencing system types.
		/// </summary>
		public static readonly CType Boolean = BooleanType.Instance;

		/// <summary>
		/// The type that is used for referencing system types.
		/// </summary>
		public static readonly CType Char = CharacterType.Instance;
	}
}
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

		public virtual Indexer GetIndexer(params CType[] types)
		{
			return null;
		}

		/// <summary>
		/// Gets a value field.
		/// </summary>
		/// <returns>The field.</returns>
		/// <param name="name">Name.</param>
		public virtual Field GetField(string name)
		{
			Signature.ValidateIdentifier(name);
			switch(name)
			{
				default: return null;
			}
		}

		/// <summary>
		/// Gets a meta field.
		/// </summary>
		/// <returns>The meta field.</returns>
		/// <param name="name">Name.</param>
		public virtual Field GetMetaField(string name)
		{
			Signature.ValidateIdentifier(name);
			switch (name)
			{
				case "type": return new ConstantField(CTypes.Type, this);
				default: return null;
			}
		}

		/// <summary>
		/// Gets a field that is only available on compile-time values.
		/// </summary>
		/// <returns>The instance field.</returns>
		/// <param name="instance">Instance.</param>
		/// <param name="name">Name.</param>
		public virtual Field GetInstanceField(CValue instance, string name)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Gets a field that is available on a system.type instance of this type.
		/// </summary>
		/// <returns>The type field.</returns>
		/// <param name="name">Name.</param>
		public virtual Field GetTypeField(string name)
		{
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
		/// A type that can only be true or false.
		/// </summary>
		public static readonly CType Boolean = BooleanType.Instance;

		/// <summary>
		/// A type that stores a single text character.
		/// </summary>
		public static readonly CType Char = CharacterType.Instance;

		/// <summary>
		/// A type that can contain integer numbers.
		/// </summary>
		public static readonly CType Integer = IntegerType.Instance;
	}
}
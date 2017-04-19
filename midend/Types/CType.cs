﻿using System;

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


		public virtual ICompilerOperators CompileTimeOperators { get; } = null;

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
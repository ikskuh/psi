namespace midend
{
	/// <summary>
	/// An abstract psi language type.
	/// </summary>
	public abstract class CType
	{
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

		protected CType()
		{
			
		}
		
		public virtual ICompilerOperators CompileTimeOperators { get; } = null;

		private sealed class VoidType : CType
		{

		}
	}
}
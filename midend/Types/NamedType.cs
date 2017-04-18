using System;
namespace midend
{
	/// <summary>
	/// A named type that serves as an alias for another type.
	/// </summary>
	public sealed class NamedType : CType
	{
		private readonly string name;
		private readonly CType underlyingType;

		public NamedType(string name, CType underlyingType)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name));
			if (underlyingType == null)
				throw new ArgumentNullException(nameof(underlyingType));
			this.name = name;
			this.underlyingType = underlyingType;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(this, obj))
				return true;
			var ntype = obj as NamedType;
			if (ntype == null)
				return false;
			return (ntype.name == this.name)
				&& (ntype.underlyingType == this.underlyingType);
		}
		
		public override int GetHashCode() =>
			this.name.GetHashCode() ^
			this.underlyingType.GetHashCode();

		public string Name => this.name;

		public CType UnderlyingType => this.underlyingType;

		public override string ToString() => string.Format("{0} = {1}", this.name, this.underlyingType);
	}
}

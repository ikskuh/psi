using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace midend
{
	public sealed class Signature : IEquatable<Signature>
	{
		private static readonly Regex patName = new Regex(@"^[A-Za-z_][A-Za-z0-9_]*$", RegexOptions.Compiled);
	
		public static bool IsValidIdentifier(string name) => patName.IsMatch(name);
		
		private readonly string name;
		private readonly CType type;
		
		public Signature(string name, CType type)
		{
			if(name == null) throw new ArgumentNullException(nameof(name));
			if(type == null) throw new ArgumentNullException(nameof(type));
			if(Signature.IsValidIdentifier(name) == false) throw new ArgumentOutOfRangeException($"'{name}' is not a valid identifier!");
			this.name = name;
			this.type = type;
		}
	
		public bool Equals(Signature other)
		{
			if (other == null)
				return false;
			return (this.Name.Equals(other.Name)) 
				&& (this.Type.Equals(other.Type));
		}

		public override bool Equals(object obj) => this.Equals(obj as Signature);

		public override int GetHashCode() => this.Name.GetHashCode() ^ this.Type.GetHashCode();
		
		public override string ToString() => string.Format("{0} : {1}", this.Name, this.Type);

		public string Name => this.name;

		public CType Type => this.type;

	}
}
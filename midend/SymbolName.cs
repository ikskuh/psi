using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace midend
{
	using System;
	using System.Xml;
	using System.Xml.Schema;
	using System.Xml.Serialization;

	/// <summary>
	/// The name of a symbol.
	/// </summary>
	public sealed class SymbolName : IEquatable<SymbolName>
	{
		[XmlElement("string")]
		public string[] path;

		[Obsolete("Only for serialization!", true)]
		public SymbolName() { }

		public SymbolName(params string[] path)
		{
			this.path = path.ToArray();
		}

		public bool Equals(SymbolName other)
		{
			if (Equals(this.path, other.path))
				return true;
			if (other.path == null)
				return false;
			return this.path.SequenceEqual(other.path);
		}

		public override int GetHashCode() => this.path?.Aggregate(0, (a, b) => a ^ b.GetHashCode()) ?? 0;

		public override bool Equals(object obj)
		{
			if (obj?.GetType() != typeof(SymbolName))
				return false;
			return this.Equals((SymbolName)obj);
		}

		public IReadOnlyList<string> Path => this.path;

		public override string ToString() => string.Join(".", this.path);

}
}
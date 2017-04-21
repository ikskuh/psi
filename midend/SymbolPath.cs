using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace midend
{
	using System;
	using System.Collections;
	using System.Xml;
	using System.Xml.Schema;
	using System.Xml.Serialization;

	/// <summary>
	/// The name of a symbol.
	/// </summary>
	public sealed class SymbolPath : IEquatable<SymbolPath>
	{
		[XmlElement("string")]
		public string[] path;

		[Obsolete("Only for serialization!", true)]
		public SymbolPath() { this.path = new string[0]; }

		public SymbolPath(params string[] path)
		{
			this.path = path.ToArray();
		}

		public bool Equals(SymbolPath other)
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
			if (obj?.GetType() != typeof(SymbolPath))
				return false;
			return this.Equals((SymbolPath)obj);
		}

		public IReadOnlyList<string> Path => this.path;

		public string this[int index] => this.path[index];

		/// <summary>
		/// Gets the last portion of this symbol name.
		/// </summary>
		/// <value>The name of the local.</value>
		public string LocalName => this.path[this.path.Length - 1];

		public int Count => this.path.Length;

		public override string ToString() => string.Join(".", this.path);

		// public IEnumerator<string> GetEnumerator() => ((IReadOnlyList<string>)path).GetEnumerator();

		// IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

/*
		[Obsolete("This is only meant for deserialization!", true)]
		public void Add(string value)
		{
			Array.Resize(ref this.path, this.path.Length + 1);
			this.path[this.path.Length - 1] = value;
		}
		*/
	}
}
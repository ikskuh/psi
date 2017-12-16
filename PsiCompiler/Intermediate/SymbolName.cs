namespace Psi.Compiler
{
	using System;
	using Psi.Runtime;
	using Type = Psi.Runtime.Type;

	public sealed class SymbolName : IEquatable<SymbolName>
	{
		private readonly Type type;
		private readonly string id;

		public SymbolName(Type type, string id)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (string.IsNullOrWhiteSpace(id)) throw new ArgumentOutOfRangeException(nameof(id));
			this.type = type;
			this.id = id;
		}
		
		public SymbolName(Type type, PsiOperator op) : this(type, "operator '" + Grammar.Converter.ToString(op) + "'")
		{
			
		}

		public override bool Equals(object obj) => this.Equals(obj as SymbolName);

		public override int GetHashCode() => (this.id.GetHashCode() << 3) ^ this.type.GetHashCode();

		public bool Equals(SymbolName other)
		{
			if (other == null)
				return false;
			return object.Equals(this.id, other.id)
				&& object.Equals(this.type, other.type);
		}

		public override string ToString() => this.id;

		public string ID => this.id;

		public Type Type => this.type;
	}
}
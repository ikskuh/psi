using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace midend
{
	public sealed class Signature : IEquatable<Signature>
	{
		private static readonly Regex patName = new Regex(@"^[A-Za-z_][A-Za-z0-9_]*$", RegexOptions.Compiled);

		public static bool IsValidIdentifier(string name) => patName.IsMatch(name);

		public static void ValidateIdentifier(string name, string paramName = "name")
		{
			if (name == null)
				throw new ArgumentNullException(paramName);
			if (Signature.IsValidIdentifier(name) == false)
				throw new ArgumentOutOfRangeException(paramName, $"'{name}' is not a valid identifier!");
		}

		private readonly string name;
		private readonly Operator op = Operator.Invalid;
		private readonly CType type;

		/// <summary>
		/// Variable signature
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="type">Type.</param>
		public Signature(string name, CType type)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (type == null) throw new ArgumentNullException(nameof(type));
			Signature.ValidateIdentifier(name);
			this.name = name;
			this.type = type;
		}

		/// <summary>
		/// Binary operator signature
		/// </summary>
		/// <param name="op">Op.</param>
		/// <param name="lhs">Lhs.</param>
		/// <param name="rhs">Rhs.</param>
		public Signature(Operator op, CType type)
		{
			if (op == Operator.Invalid) throw new ArgumentOutOfRangeException(nameof(op));
			if (type == null) throw new ArgumentNullException(nameof(type));
			this.op = op;
			this.type = type;
		}

		public bool Equals(Signature other)
		{
			if (other == null)
				return false;
			return Equals(this.Name, other.Name)
				&& Equals(this.Type, other.Type)
				&& Equals(this.Operator, other.Operator);
		}

		public override bool Equals(object obj) => this.Equals(obj as Signature);

		public override int GetHashCode()
		{
			if (this.op != Operator.Invalid)
			{
				return 0x1234567 ^
					this.op.GetHashCode() ^
					this.type.GetHashCode();
			}
			else
			{
				return 0x68765432 ^
					this.Name.GetHashCode() ^ 
					this.Type.GetHashCode();
			}
		}

		public override string ToString() => string.Format("{0} : {1}", this.Name, this.Type);

		public string Name => this.name;

		public CType Type => this.type;

		public Operator Operator => this.op;

		public bool IsOperatorSignature => (this.op != Operator.Invalid);
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public sealed class EnumType : CType
	{
		private readonly List<EnumMember> members;

		public EnumType(ISet<string> members)
		{
			if (members == null) throw new ArgumentNullException(nameof(members));
			this.members = new List<EnumMember>(members.Distinct().Select(m => new EnumMember(this, m)));
		}

		public override bool IsAllowedValue(object value)
		{
			var member = value as EnumMember;
			if (member == null)
				return false;
			return (member.Type == this);
		}

		public override Field GetTypeField(string name)
		{
			var member = this.Members.FirstOrDefault(m => m.Value == name);
			if (member != null)
				return new ConstantField(this, member);
			return base.GetTypeField(name);
		}

		public IReadOnlyCollection<EnumMember> Members => this.members;

		public override string ToString() => string.Format("enum({0})", string.Join(", ", this.Members));
	}

	public sealed class EnumMember
	{
		private readonly EnumType type;
		private readonly string value;

		public EnumMember(EnumType type, string value)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value == null) throw new ArgumentNullException(nameof(value));
			Signature.ValidateIdentifier(value, nameof(value));
			this.type = type;
			this.value = value;
		}

		public EnumType Type => this.type;

		public string Value => this.value;

		public override bool Equals(object obj) => Equals(this.value, (obj as EnumMember)?.value);

		public override int GetHashCode() => this.value.GetHashCode();

		public override string ToString() => this.value;
	}
}

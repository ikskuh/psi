using System;

namespace midend
{
	public sealed class RecordFieldIndex : Field
	{
		private readonly RecordType type;
		private readonly RecordMember member;

		public RecordFieldIndex(RecordType type, RecordMember member)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (member == null) throw new ArgumentNullException(nameof(member));
			this.type = type;
			this.member = member;
		}
		
		public override bool IsCompileTimeEvaluatable => true;

		public override CType Type => this.member.Type;

		public override CValue Evaluate(CValue value, EvaluationContext context)
		{
			var rec = value.Get<Record>();
			return rec[this.member];
		}
	}
}
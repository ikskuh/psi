using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
namespace midend
{
	public sealed class RecordType : CType
	{
		private readonly RecordMember[] indexedMembers;
		private readonly Dictionary<string, RecordMember> members;
		private readonly BuiltinFunction ctor;

		public RecordType(IEnumerable<RecordMember> members)
		{
			if (members == null) throw new ArgumentNullException(nameof(members));
			this.indexedMembers = members.ToArray();
			this.members = members.ToDictionary(m => m.Name);

			var ctorType = new RecordCtorType(this, members);

			this.ctor = new BuiltinFunction(ctorType, this.Construct);
		}

		public override bool IsAllowedValue(object value)
		{
			var record = value as Record;
			if (record == null)
				return false;
			return record.Type.CanBeAssignedTo(this);
		}

		public override Function GetConstructor() => this.ctor;

		private CValue Construct(CValue[] args)
		{
			var value = new Record(this);
			for (int i = 0; i < this.indexedMembers.Length; i++)
			{
				value[this.indexedMembers[i]] = args[i];
			}
			return (CValue)value;
		}

		public override Field GetField(string name)
		{
			RecordMember member;
			if (this.members.TryGetValue(name, out member))
			{
				return new RecordFieldIndex(this, member);
			}
			return base.GetField(name);
		}

		public IReadOnlyDictionary<string, RecordMember> Members => this.members;
		
		public override string ToString() => string.Format(
			"record({0})",
			string.Join<string>(", ", this.members.Select(m => string.Format("{0} : {1}", m.Key, m.Value.Type))));

		private sealed class RecordCtorType : FunctionType
		{
			public RecordCtorType(RecordType type, IEnumerable<RecordMember> members) : base(type, members.Select(m => new Parameter(m.Name, m.Type, m.InitialValue)).ToArray())
			{

			}
		}
	}

	public sealed class RecordMember
	{
		private readonly CType type;
		private readonly string name;
		private readonly CValue value;

		public RecordMember(CType type, string name, CValue initialValue)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (name == null) throw new ArgumentNullException(nameof(name));

			this.type = type;
			this.name = name;
			this.value = initialValue;
			if (this.value != null)
			{
				if (!this.value.Type.CanBeAssignedTo(this.type))
					throw new ArgumentException("initialValue fits not the given type!");
			}
		}

		public CType Type => this.type;

		public string Name => this.name;

		public CValue InitialValue => this.value;
	}
}

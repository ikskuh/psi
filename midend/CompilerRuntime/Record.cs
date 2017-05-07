using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace midend
{
	public sealed class Record : IReadOnlyDictionary<RecordMember, CValue>
	{
		private readonly RecordType type;
		private readonly Dictionary<RecordMember, CValue> fields = new Dictionary<RecordMember, CValue>();

		public Record(RecordType type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			this.type = type;
			foreach (var m in this.type.Members)
			{
				this.fields[m.Value] = CValue.Unassigned;
			}
		}
		
		public override string ToString() => string.Format(
			"({0})",
			string.Join<string>(", ", fields.Select(f => string.Format("{0} = {1}", f.Key.Name, f.Value))));
		
		public RecordType Type => this.type;

		#region IReadOnlyDictionary

		public CValue this[RecordMember key]
		{
			get
			{
				return fields[key];
			}
			set
			{
				if (this.fields.ContainsKey(key) == false)
					throw new ArgumentOutOfRangeException(nameof(key));
				if (value.Type.CanBeAssignedTo(key.Type) == false)
					throw new ArgumentException("Invalid type!");
				this.fields[key] = value;
			}
		}

		public int Count
		{
			get
			{
				return fields.Count;
			}
		}

		public IEnumerable<RecordMember> Keys
		{
			get
			{
				return ((IReadOnlyDictionary<RecordMember, CValue>)fields).Keys;
			}
		}

		public IEnumerable<CValue> Values
		{
			get
			{
				return ((IReadOnlyDictionary<RecordMember, CValue>)fields).Values;
			}
		}

		public bool ContainsKey(RecordMember key)
		{
			return fields.ContainsKey(key);
		}

		public IEnumerator<KeyValuePair<RecordMember, CValue>> GetEnumerator()
		{
			return ((IReadOnlyDictionary<RecordMember, CValue>)fields).GetEnumerator();
		}

		public bool TryGetValue(RecordMember key, out CValue value)
		{
			return fields.TryGetValue(key, out value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyDictionary<RecordMember, CValue>)fields).GetEnumerator();
		}

		#endregion
	}
}

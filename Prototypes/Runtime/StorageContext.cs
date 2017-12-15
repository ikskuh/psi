using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
	public sealed class StorageContext : IReadOnlyList<ValueStore>
	{
		private readonly ValueStore[] fields;

		public StorageContext(int fieldCount)
		{
			this.fields = new ValueStore[fieldCount];
		}
		
		public StorageContext(params ValueStore[] fields)
		{
			this.fields = fields.ToArray();
		}

		public ValueStore this[int idx]
		{
			get { return this.fields[idx]; }
			set { this.fields[idx] = value; }
		}

		public int Count
		{
			get
			{
				return ((IReadOnlyList<ValueStore>)fields).Count;
			}
		}

		public IEnumerator<ValueStore> GetEnumerator()
		{
			return ((IReadOnlyList<ValueStore>)fields).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyList<ValueStore>)fields).GetEnumerator();
		}
	}
}

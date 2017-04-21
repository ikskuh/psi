using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace midend
{
	public sealed class CArray : IReadOnlyList<CValue>
	{
		private readonly ArrayType type;
		private readonly CValue[] values;

		public CArray(ArrayType type, params CValue[] values)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (values == null) throw new ArgumentNullException(nameof(values));

			if (values.All((arg) => arg.Type.CanBeAssignedTo(type.ElementType)) == false)
				throw new ArgumentException("All values must be assignable to the arrays element type!", nameof(values)); ;

			this.type = type;
			this.values = values.ToArray();
		}

		public ArrayType Type => this.type;
		
		public CType ElementType => this.type.ElementType;
		
		public override string ToString() => "[ " + string.Join<CValue>(", ", this.values) + " ]";

		#region IReadOnlyList<CValue>

		public CValue this[int index]
		{
			get
			{
				return ((IReadOnlyList<CValue>)values)[index];
			}
		}

		public int Count
		{
			get
			{
				return ((IReadOnlyList<CValue>)values).Count;
			}
		}

		public IEnumerator<CValue> GetEnumerator()
		{
			return ((IReadOnlyList<CValue>)values).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyList<CValue>)values).GetEnumerator();
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Collections;
namespace Psi.Runtime
{

	public sealed class Array : Value, IList<Value>
	{
		private readonly List<Value> items = new List<Value>();

		public Array(ArrayType type) : base(type)
		{
			if (type.Dimensions != 1) throw new NotSupportedException("Arrays with more than one dimension are not supported yet!");
		}
		
		public Array(ArrayType type, IEnumerable<Value> initial) : this(type)
		{
			foreach(var v in initial)
				this.Add(v);
		}

		public Type ElementType => ((ArrayType)this.Type).ElementType;

		public int Dimensions => ((ArrayType)this.Type).Dimensions;

		public int Count => items.Count;

		public bool IsReadOnly => false;

		public Value this[int index]
		{
			get
			{
				return items[index];
			}

			set
			{
				if (value.Type != this.ElementType)
					throw new InvalidOperationException("Invalid element type!");
				items[index] = value;
			}
		}

		public int IndexOf(Value item)
		{
			return items.IndexOf(item);
		}

		public void Insert(int index, Value item)
		{
			if (item.Type != this.ElementType)
				throw new InvalidOperationException("Invalid element type!");
			items.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			items.RemoveAt(index);
		}

		public void Add(Value item)
		{
			if (item.Type != this.ElementType)
				throw new InvalidOperationException("Invalid element type!");
			items.Add(item);
		}

		public void Clear()
		{
			items.Clear();
		}

		public bool Contains(Value item)
		{
			return items.Contains(item);
		}

		public void CopyTo(Value[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}

		public bool Remove(Value item)
		{
			return items.Remove(item);
		}

		public IEnumerator<Value> GetEnumerator()
		{
			return ((IList<Value>)items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IList<Value>)items).GetEnumerator();
		}
	}
}

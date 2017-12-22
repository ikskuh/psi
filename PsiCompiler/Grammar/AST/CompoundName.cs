using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler
{
	public sealed class CompoundName : IList<string>
	{
		private readonly List<string> components = new List<string>();

		public CompoundName(params string[] text)
		{
			this.components = new List<string>(text);
		}

		public override string ToString() => string.Join(".", this.components);

		public string Identifier => this.Last();

		#region IList<string>

		public string this[int index]
		{
			get
			{
				return components[index];
			}

			set
			{
				components[index] = value;
			}
		}

		public int Count
		{
			get
			{
				return components.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IList<string>)components).IsReadOnly;
			}
		}

		public void Add(string item)
		{
			components.Add(item);
		}

		public void Clear()
		{
			components.Clear();
		}

		public bool Contains(string item)
		{
			return components.Contains(item);
		}

		public void CopyTo(string[] array, int arrayIndex)
		{
			components.CopyTo(array, arrayIndex);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return ((IList<string>)components).GetEnumerator();
		}

		public int IndexOf(string item)
		{
			return components.IndexOf(item);
		}

		public void Insert(int index, string item)
		{
			components.Insert(index, item);
		}

		public bool Remove(string item)
		{
			return components.Remove(item);
		}

		public void RemoveAt(int index)
		{
			components.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IList<string>)components).GetEnumerator();
		}

#endregion
	}
}

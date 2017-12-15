using System;
using System.Collections;
using System.Collections.Generic;

namespace Runtime
{
	public sealed class Void : Value
	{
		public Void() : base(VoidType.Instance) { }

		public override string ToString() => "void";
	}

	public sealed class Boolean : Value
	{
		private readonly bool value;

		public Boolean(bool value) : base(BooleanType.Instance)
		{
			this.value = value;
		}

		public static implicit operator bool(Boolean b) => b.value;

		public static implicit operator Boolean(bool b) => new Boolean(b);

		public bool Value => this.value;

		public override string ToString() => value.ToString();
	}

	public sealed class Integer : Value
	{
		private readonly int value;

		public Integer(int value) : base(IntegerType.Instance)
		{
			this.value = value;
		}

		public static implicit operator int(Integer i) => i.value;

		public static implicit operator Integer(int i) => new Integer(i);

		public int Value => this.value;

		public override string ToString() => value.ToString();
	}

	public sealed class Character : Value
	{
		private readonly int value;

		public Character(char value) : this(char.ConvertToUtf32(value.ToString(), 0))
		{

		}

		public Character(string value) : this(char.ConvertToUtf32(value, 0))
		{

		}

		public Character(int value) : base(CharacterType.Instance)
		{
			this.value = value;
		}

		public static implicit operator string(Character b) => char.ConvertFromUtf32(b.value);

		public static implicit operator Character(string b) => new Character(char.ConvertToUtf32(b, 0));

		public int Value => this.value;

		public override string ToString() => value.ToString();
	}

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

	public sealed class Function : Value
	{
		public Function(FunctionPrototype proto) : this(proto, null)
		{

		}

		public Function(FunctionPrototype proto, StorageContext creationContext) : base(proto.Type)
		{
			if (proto == null) throw new ArgumentNullException(nameof(proto));
			this.Prototype = proto;
			this.CreationContext = creationContext;
		}

		public void Call(StorageContext globals, params ValueStore[] valueStore)
		{
			var stack = this.Prototype.CreateStack();
			for (int i = 0; i < valueStore.Length; i++)
				stack[i] = valueStore[i];

			var context = new ExecutionContext(
				globals,
				stack,
				this.CreationContext);
			this.Prototype.Execute(context);
		}

		public static implicit operator Function(FunctionPrototype proto) => new Function(proto);

		public StorageContext CreationContext { get; }

		public FunctionPrototype Prototype { get; }

	}
}

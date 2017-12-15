using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
	public sealed class ValueStore
	{
		public static ValueStore Null { get; } = new ValueStore();
	
		private Value value;

		private ValueStore()
		{
			this.Type = VoidType.Instance;
		}

		public ValueStore(Type type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));
			if(type is VoidType)
				throw new ArgumentOutOfRangeException(nameof(type), "Void is not a storable type!");
			this.Type = type;
		}
		
		public ValueStore(Value value) : this(value.Type)
		{
			this.Value = value;
		}
		
		public ValueStore(Type type, Value value) : this(type)
		{
			this.Value = value;
		}
		
		/// <summary>
		/// Clone this value store, but only if the store has a valid value.
		/// </summary>
		/// <returns>The clone.</returns>
		public ValueStore Clone()
		{
			var store = new ValueStore(this.Type);
			store.Value = this.Value;
			return store;
		}
		
		public bool IsInitialized => (this.value != null);

		public Type Type { get; }

		public Value Value
		{
			get
			{
				if(this.Type is VoidType) return null;
				if (this.value == null) throw new InvalidOperationException("Access to unitialized variable!");
				return this.value;
			}
			set
			{
				if(this.Type is VoidType) return;
				if (value?.Type != this.Type)
					throw new ArgumentOutOfRangeException(nameof(value));
				this.value = value;
			}
		}

		public override string ToString() => this.value?.ToString() ?? "<nil>";
	}
}

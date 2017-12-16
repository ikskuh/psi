using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psi.Runtime
{
	public abstract class Type : IEquatable<Type>
	{
		public static Type Void => VoidType.Instance;
		public static Type Boolean => BooleanType.Instance;
		public static Type Integer => IntegerType.Instance;
		public static Type Real => RealType.Instance;
		public static Type Character => CharacterType.Instance;
		public static Type PsiType => TypeType.Instance;
		public static ArrayType String { get; } = new ArrayType(CharacterType.Instance);

		public override bool Equals(object obj) => this.Equals(obj as Type);

		public abstract bool Equals(Type other);

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}

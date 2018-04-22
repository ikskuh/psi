using System;
namespace Psi.Compiler
{
	public sealed class VoidType : PsiType
	{
		public static VoidType Instance { get; } = new VoidType();

		private VoidType()
		{
			this.Name = "void";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is VoidType;

		public override int GetHashCode() => 0;
	}

	public sealed class IntegerType : PsiType
	{
		public static IntegerType Instance { get; } = new IntegerType();

		private IntegerType()
		{
			this.Name = "int";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is IntegerType;

		public override int GetHashCode() => 5;
	}

	public sealed class RealType : PsiType
	{
		public static RealType Instance { get; } = new RealType();

		private RealType()
		{
			this.Name = "real";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is RealType;

		public override int GetHashCode() => 4;
	}

	public sealed class CharacterType : PsiType
	{
		public static CharacterType Instance { get; } = new CharacterType();

		private CharacterType()
		{
			this.Name = "char";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is CharacterType;

		public override int GetHashCode() => 3;
	}

	public sealed class BooleanType : PsiType
	{
		public static BooleanType Instance { get; } = new BooleanType();

		private BooleanType()
		{
			this.Name = "bool";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is BooleanType;

		public override int GetHashCode() => 2;
	}

	public sealed class PsiTypeType : PsiType
	{
		public static PsiTypeType Instance { get; } = new PsiTypeType();

		private PsiTypeType()
		{
			this.Name = "type";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is PsiTypeType;

		public override int GetHashCode() => 1;
	}


	public sealed class ByteType : PsiType
	{
		public static ByteType Instance { get; } = new ByteType();

		private ByteType()
		{
			this.Name = "byte";
			this.IsComplete = true;
		}
		
		public override bool TypeEquals(PsiType other) => other is ByteType;

		public override int GetHashCode() => 6;
	}
}

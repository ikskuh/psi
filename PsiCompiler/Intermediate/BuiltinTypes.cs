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
	}

	public sealed class IntegerType : PsiType
	{
		public static IntegerType Instance { get; } = new IntegerType();

		private IntegerType()
		{
			this.Name = "int";
			this.IsComplete = true;
		}
	}

	public sealed class RealType : PsiType
	{
		public static RealType Instance { get; } = new RealType();

		private RealType()
		{
			this.Name = "real";
			this.IsComplete = true;
		}
	}

	public sealed class CharacterType : PsiType
	{
		public static CharacterType Instance { get; } = new CharacterType();

		private CharacterType()
		{
			this.Name = "char";
			this.IsComplete = true;
		}
	}

	public sealed class BooleanType : PsiType
	{
		public static BooleanType Instance { get; } = new BooleanType();

		private BooleanType()
		{
			this.Name = "bool";
			this.IsComplete = true;
		}
	}

	public sealed class PsiTypeType : PsiType
	{
		public static PsiTypeType Instance { get; } = new PsiTypeType();

		private PsiTypeType()
		{
			this.Name = "type";
			this.IsComplete = true;
		}
	}


}

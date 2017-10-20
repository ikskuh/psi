








using System;
using System.IO;
using System.Text.RegularExpressions;
using CompilerKit;

namespace PsiCompiler.Grammar
{
	
	
sealed partial class PsiTokenizer : Tokenizer<PsiTokenType>
{
	public PsiTokenizer(TextReader reader, string fileName) : this(reader, fileName, true)
	{
	
	}

	public PsiTokenizer(TextReader reader, string fileName, bool closeOnDispose) : base(reader, fileName, closeOnDispose)
	{
		this.RegisterToken(PsiTokenType.Comment, new Regex(@"\/\/.*", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.LongComment, new Regex(@"\/\*.*?\*\/", RegexOptions.Compiled|RegexOptions.Singleline));
		this.RegisterToken(PsiTokenType.Whitespace, new Regex(@"\s+", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ENUMVAL, new Regex(@"\:[\w-[\d]]\w*", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.CURLY_O, new Regex(@"\{", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.CURLY_C, new Regex(@"\}", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ROUND_O, new Regex(@"\(", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ROUND_C, new Regex(@"\)", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SQUARE_O, new Regex(@"\[", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SQUARE_C, new Regex(@"\]", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.IMPORT, new Regex(@"\bimport\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.EXPORT, new Regex(@"\bexport\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.MODULE, new Regex(@"\bmodule\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ASSERT, new Regex(@"\bassert\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ERROR, new Regex(@"\berror\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.CONST, new Regex(@"\bconst\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.VAR, new Regex(@"\bvar\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.TYPE, new Regex(@"\btype\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.FN, new Regex(@"\bfn\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.NEW, new Regex(@"\bnew\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.OPERATOR, new Regex(@"\boperator\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ENUM, new Regex(@"\benum\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.RECORD, new Regex(@"\brecord\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.INOUT, new Regex(@"\binout\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.IN, new Regex(@"\bin\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.OUT, new Regex(@"\bout\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.THIS, new Regex(@"\bthis\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.FOR, new Regex(@"\bfor\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WHILE, new Regex(@"\bwhile\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.LOOP, new Regex(@"\bloop\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.UNTIL, new Regex(@"\buntil\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.IF, new Regex(@"\bif\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ELSE, new Regex(@"\belse\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SELECT, new Regex(@"\bselect\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WHEN, new Regex(@"\bwhen\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.OTHERWISE, new Regex(@"\botherwise\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.RESTRICT, new Regex(@"\brestrict\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.BREAK, new Regex(@"\bbreak\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.CONTINUE, new Regex(@"\bcontinue\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.NEXT, new Regex(@"\bnext\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.RETURN, new Regex(@"\breturn\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.GOTO, new Regex(@"\bgoto\b", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_CONCAT, new Regex(@"\-\-\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_PLUS, new Regex(@"\+\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_MINUS, new Regex(@"\-\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_EXP, new Regex(@"\*\*\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_MULT, new Regex(@"\*\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_MOD, new Regex(@"\%\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_DIV, new Regex(@"\/\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_AND, new Regex(@"\&\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_OR, new Regex(@"\|\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_INVERT, new Regex(@"\~\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_XOR, new Regex(@"\^\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_ASR, new Regex(@"\>\>\>\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_SHL, new Regex(@"\<\<\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.WB_SHR, new Regex(@"\>\>\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.MAPSTO, new Regex(@"\=\>", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ASR, new Regex(@"\>\>\>", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SHL, new Regex(@"\<\<", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SHR, new Regex(@"\>\>", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.FORWARD, new Regex(@"\-\>", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.BACKWARD, new Regex(@"\<\-", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.LEQUAL, new Regex(@"\<\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.GEQUAL, new Regex(@"\>\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.EQUAL, new Regex(@"\=\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.NEQUAL, new Regex(@"\!\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.LESS, new Regex(@"\<", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.MORE, new Regex(@"\>", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.IS, new Regex(@"\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.ASSIGN, new Regex(@"\:\=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.CONCAT, new Regex(@"\-\-", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.DOT, new Regex(@"\.", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.META, new Regex(@"\'", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.COMMA, new Regex(@"\,", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.TERMINATOR, new Regex(@"\;", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.COLON, new Regex(@"\:", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.LAMBDA, new Regex(@"\\", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.PLUS, new Regex(@"\+", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.MINUS, new Regex(@"\-", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.EXP, new Regex(@"\*\*", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.MULT, new Regex(@"\*", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.MOD, new Regex(@"\%", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.DIV, new Regex(@"\/", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.AND, new Regex(@"\&", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.OR, new Regex(@"\|", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.INVERT, new Regex(@"\~", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.XOR, new Regex(@"\^", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.NUMBER, new Regex(@"-?\d+(\.\d+)?", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.STRING, new Regex(@""".*?(?<!\\)""", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.IDENT, new Regex(@"[\w-[\d]]\w*", RegexOptions.Compiled));
			
		this.Initialize();
	}

	partial void Initialize();

	protected override Func<string,string> GetPostProcessor(PsiTokenType type)
	{
		switch(type)
		{
			case PsiTokenType.Comment:
				return (text) => null;
			case PsiTokenType.LongComment:
				return (text) => null;
			case PsiTokenType.Whitespace:
				return (text) => null;
			case PsiTokenType.STRING:
				return (text) => text.Substring(1, text.Length - 2);
			case PsiTokenType.ENUMVAL:
				return (text) => text.Substring(1);
			default:
				return (text) => text;
		}
	}
}

}

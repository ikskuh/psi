

namespace PsiCompiler
{
	﻿
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CompilerKit;

public enum PsiTokenType
{
	Number,
	String,
	Module,
	SymBracesOpen,
	SymBracesClose,
	Const,
	Var,
	Identifier,
	SymColon,
	SymEquals,
	SymSemicolon,
	Assert,
	SymAsterisk,
	SymSlash,
	SymPlus,
	SymMinus,
}

	
sealed partial class PsiTokenizer : Tokenizer<PsiTokenType>
{
	public PsiTokenizer(TextReader reader, string fileName) : this(reader, fileName, true)
	{
	
	}

	public PsiTokenizer(TextReader reader, string fileName, bool closeOnDispose) : base(reader, fileName, closeOnDispose)
	{
		this.RegisterToken(PsiTokenType.Number, new Regex(@"-?\d+(\.\d+)?", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.String, new Regex(@""".*?(?<!\\)""", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.Module, new Regex(@"module", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymBracesOpen, new Regex(@"\{", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymBracesClose, new Regex(@"}", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.Const, new Regex(@"const", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.Var, new Regex(@"var", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.Identifier, new Regex(@"identifier", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymColon, new Regex(@":", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymEquals, new Regex(@"=", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymSemicolon, new Regex(@";", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.Assert, new Regex(@"assert", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymAsterisk, new Regex(@"\*", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymSlash, new Regex(@"/", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymPlus, new Regex(@"\+", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.SymMinus, new Regex(@"-", RegexOptions.Compiled));
			
		this.Initialize();
	}

	partial void Initialize();

	protected override Func<string,string> GetPostProcessor(PsiTokenType type)
	{
		switch(type)
		{
			case PsiTokenType.String:
				return (text) => text.Substring(1, text.Length - 2);
			default:
				return (text) => text;
		}
	}
}

	
	﻿
sealed partial class PsiParser : Parser<PsiTokenType>
{
	public PsiParser(PsiTokenizer tokenizer) : base(tokenizer)
	{

	}
}
}

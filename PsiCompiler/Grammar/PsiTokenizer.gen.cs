

namespace CompilerKit
{
	using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CompilerKit;

sealed partial class PsiTokenizer : Tokenizer<PsiTokenType>
{
	public PsiTokenizer(TextReader reader, string fileName) : this(reader, fileName, true)
	{
	
	}

	public PsiTokenizer(TextReader reader, string fileName, bool closeOnDispose) : base(reader, fileName, closeOnDispose)
	{
		this.RegisterToken(PsiTokenType.number, new Regex(@"-?\d+(\.\d+)?", RegexOptions.Compiled));
		this.RegisterToken(PsiTokenType.string, new Regex(@""".*?(?<!\\)""", RegexOptions.Compiled));
			
		this.Initialize();
	}

	partial void Initialize();

	protected override Func<string,string> GetPostProcessor(PsiTokenType type)
	{
		switch(type)
		{
			default:
				return (text) => text;
		}
	}
}

public enum PsiTokenType
{
	number,
	string,
}

}

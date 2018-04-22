
namespace MetaCompiler
{
	using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CompilerKit;

sealed partial class GrammarTokenizer : Tokenizer<GrammarTokenType>
{
	public GrammarTokenizer(TextReader reader, string fileName) : this(reader, fileName, true)
	{
	
	}

	public GrammarTokenizer(TextReader reader, string fileName, bool closeOnDispose) : base(reader, fileName, closeOnDispose)
	{
		this.RegisterToken(GrammarTokenType.Whitespace, new Regex(@"\s+", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.Comment, new Regex(@"#.*", RegexOptions.Compiled|RegexOptions.Singleline));
		this.RegisterToken(GrammarTokenType.RuleName, new Regex(@"\w+", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.RuleReference, new Regex(@"\<\w+\>", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.TerminalReference, new Regex(@""".*?(?<!\\)""", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.ExtTerminalReference, new Regex(@"'.*?(?<!\\)'", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.BeginOfDefinition, new Regex(@"\:\=", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.EndOfDefinition, new Regex(@"\;", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.GroupBegin, new Regex(@"\(", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.GroupEnd, new Regex(@"\)", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.LoopBegin, new Regex(@"\{", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.LoopEnd, new Regex(@"\}", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.OptionalBegin, new Regex(@"\[", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.OptionalEnd, new Regex(@"\]", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.Alternative, new Regex(@"\|", RegexOptions.Compiled));
		this.RegisterToken(GrammarTokenType.Invalid, new Regex(@"\S+", RegexOptions.Compiled));
			
		this.Initialize();
	}

	partial void Initialize();

	protected override Func<string,string> GetPostProcessor(GrammarTokenType type)
	{
		switch(type)
		{
			case GrammarTokenType.RuleReference:
				return (text) => text.Substring(1, text.Length - 2);
			case GrammarTokenType.TerminalReference:
				return (text) => text.Substring(1, text.Length - 2);
			case GrammarTokenType.ExtTerminalReference:
				return (text) => text.Substring(1, text.Length - 2);
			case GrammarTokenType.Whitespace:
				return (text) => null; // discard;
			case GrammarTokenType.Comment:
				return (text) => null; // discard;
			default:
				return (text) => text;
		}
	}
}

public enum GrammarTokenType
{
	Whitespace,
	Comment,
	RuleName,
	RuleReference,
	TerminalReference,
	ExtTerminalReference,
	BeginOfDefinition,
	EndOfDefinition,
	GroupBegin,
	GroupEnd,
	LoopBegin,
	LoopEnd,
	OptionalBegin,
	OptionalEnd,
	Alternative,
	Invalid,
}

}

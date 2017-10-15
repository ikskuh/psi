using System;
using System.Text.RegularExpressions;
using CompilerKit;
namespace CompilerKit
{
	public sealed class GrammarParser : Parser<GrammarTokenType>
	{
		public GrammarParser(GrammarTokenizer tokenizer) : base(tokenizer)
		{

		}

		public Grammar Parse()
		{
			var grammar = new Grammar();

			while (!this.EndOfText)
			{
				var name = this.Read(GrammarTokenType.RuleName);
				this.Read(GrammarTokenType.BeginOfDefinition);

				var syntax = this.ReadSyntax(GrammarTokenType.EndOfDefinition);

				grammar.Rules.Add(new Rule
				{
					Location = name.Location,
					Name = name.Text,
					Syntax = syntax,
				});
			}

			return grammar;
		}

		// read sequences until terminator, consume terminator
		Syntax ReadSyntax(GrammarTokenType terminator)
		{
			AssertMoreText();
			AssertNot(GrammarTokenType.Alternative);
			AssertNot(GrammarTokenType.EndOfDefinition);
			AssertNot(GrammarTokenType.GroupEnd);
			AssertNot(GrammarTokenType.LoopEnd);
			AssertNot(GrammarTokenType.OptionalEnd);

			var token = this.Peek();
			Syntax current;
			switch (token.Type)
			{
				case GrammarTokenType.OptionalBegin:
					current = this.ReadOptional();
					break;
				case GrammarTokenType.GroupBegin:
					current = this.ReadGroup();
					break;
				case GrammarTokenType.LoopBegin:
					current = this.ReadLoop();
					break;
				case GrammarTokenType.RuleReference:
					token = Read(); // consume token here
					current = new RuleReference(token.Text);
					break;
				case GrammarTokenType.TerminalReference:
					token = Read(); // consume token here
					current = new Terminal(token.Text, new Regex(Regex.Escape(token.Text)));
					break;
				case GrammarTokenType.ExtTerminalReference:
					token = Read(); // consume token here
					current = new Terminal(token.Text);
					break;
				default:
					throw new SyntaxErrorException(token.ToError());
			}
			
			token = Peek();
			if(token.Type == terminator)
			{
				Read(terminator);
				return current;
			}
			
			bool isAlternative = (token.Type == GrammarTokenType.Alternative);
			
			if(isAlternative)
				Read(GrammarTokenType.Alternative);
			
			var followup = this.ReadSyntax(terminator);
			
			if(isAlternative)
				return new Alternative(current, followup);
			else
				return new Sequence(current, followup);
		}

		Syntax ReadOptional()
		{
			Read(GrammarTokenType.OptionalBegin);
			return new Optional(this.ReadSyntax(GrammarTokenType.OptionalEnd));
		}

		Syntax ReadGroup()
		{
			Read(GrammarTokenType.GroupBegin);
			var group = this.ReadSyntax(GrammarTokenType.GroupEnd);
			group.IsGroup = true;
			return group;
		}

		Syntax ReadLoop()
		{
			Read(GrammarTokenType.LoopBegin);
			return new Loop(this.ReadSyntax(GrammarTokenType.LoopEnd));
		}
	}
}

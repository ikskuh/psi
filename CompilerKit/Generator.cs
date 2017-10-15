using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualStudio.TextTemplating;
using System.CodeDom.Compiler;
namespace CompilerKit
{
	public static class Generator
	{
		public static CompilerErrorCollection Load(string grammarFile, string tokenFile, out Grammar grammar, out TokenDefinitionFile tokens)
		{
			grammar = null;
			tokens = TokenDefinitionFile.Load(tokenFile);

			try
			{
				using (var fs = File.OpenRead(grammarFile))
				{
					using (var sr = new StreamReader(fs, Encoding.UTF8))
					{
						var tokenizer = new GrammarTokenizer(sr, Path.GetFileName(grammarFile));

						var parser = new GrammarParser(tokenizer);

						grammar = parser.Parse();
					}
				}
			}
			catch (SyntaxErrorException ex)
			{
				Console.Error.WriteLine("Failed to compile grammar:");
				foreach (var error in ex.Errors)
				{
					Console.Error.WriteLine(
						"{1}: {0} - {2}",
						error.Type,
						error.Location,
						error.Message);
				}

				return new CompilerErrorCollection(ex
					.Errors
					.Select(err => new CompilerError(
							err.Location.File,
							err.Location.Line,
							1,
							"Q0001",
							err.Message))
					.ToArray());
			}

			var errors = new CompilerErrorCollection();

			var rules = grammar.Rules.ToArray();
			var names = rules.Select(r => r.Name).Distinct().ToArray();
			var terminals = new Dictionary<string, string>(); // value → key mapping ^^

			if (rules.Length != names.Length)
			{
				Console.Error.WriteLine("The following rules are duplicated:");
				Console.Error.WriteLine(string.Join(", ", rules.GroupBy(r => r.Name).Where(g => g.Count() > 1).Select(g => g.Key)));
			}

			foreach (var rule in rules)
			{
				// Gather a list of all terminals
				foreach (var val in rule.Syntax.Flatten().OfType<Terminal>())
				{
					var key = val.Name;
					if (terminals.ContainsKey(key) == false)
						terminals.Add(key, MakeSafeName(key));
					val.Name = terminals[key];
				}

				// Gather all undefined references
				var undefined = rule.Syntax.Flatten().OfType<RuleReference>().Select(r => r.Rule).Except(names).ToArray();
				if (undefined.Length > 0)
				{
					errors.Add(new CompilerError(
						rule.Location.File,
						rule.Location.Line,
						rule.Location.Column,
						"Q0002",
						$"Rule {rule.Name} references undefined rules: {(string.Join(", ", undefined))}"));
				}
			}

			foreach (var terminal in terminals)
			{
				if (!tokens.ContainsKey(terminal.Value))
				{
					tokens.Add(terminal.Value, new Regex(Regex.Escape(terminal.Key), RegexOptions.Compiled));
				}
			}

			tokens.Serialize(Console.Out);

			return errors;
		}

		public static string Header(string prefix, TokenDefinitionFile source)
		{
			var gen = new HeaderGenerator
			{
				Prefix = prefix,
				Tokens = source,
			};
			return gen.TransformText();
		}

		public static string Tokenizer(string prefix, TokenDefinitionFile source)
		{
			var gen = new TokenizerGenerator
			{
				Prefix = prefix,
				Source = source,
			};
			return gen.TransformText();
		}

		public static string Tokenizer(string prefix, string sourceFile)
		{
			var source = TokenDefinitionFile.Load(sourceFile);
			return Tokenizer(prefix, source);
		}

		public static string Parser(string prefix, Grammar grammar)
		{
			var gen = new ParserGenerator
			{
				Prefix = prefix,
				Grammar = grammar,
			};
			return gen.TransformText();
		}


		static readonly Regex patternSafeName = new Regex(@"[A-Za-z_]\w+", RegexOptions.Compiled);
		static readonly Regex patternSafeNameFix = new Regex(@"[^A-Za-z_]", RegexOptions.Compiled);
		static string MakeSafeName(string key)
		{
			key = key.Substring(0, 1).ToUpper() + key.Substring(1);
			switch (key)
			{
				case "{": return "SymBracesOpen";
				case "}": return "SymBracesClose";
				case "[": return "SymSquareBracketOpen";
				case "]": return "SymSquareBracketClose";
				case "(": return "SymParenthesisOpen";
				case ")": return "SymParenthesisClose";
				case "<": return "SymPointyBracketOpen";
				case ">": return "SymPointyBracketClose";
				case ",": return "SymComma";
				case ".": return "SymDot";
				case "_": return "SymUnderscore";
				case ":": return "SymColon";
				case ";": return "SymSemicolon";
				case "=": return "SymEquals";
				case "!": return "SymExclamation";
				case "?": return "SymQuestion";
				case "+": return "SymPlus";
				case "-": return "SymMinus";
				case "*": return "SymAsterisk";
				case "/": return "SymSlash";
				default:
					if (patternSafeName.IsMatch(key))
						return key;
					return "auto_" + patternSafeNameFix.Replace(key, (match) => $"x{((int)match.Value[0]).ToString()}");
			}
		}


	}

	partial class ParserGenerator
	{
		public string Prefix { get; set; } = "My";
		
		public Grammar Grammar { get; set; } = null;

		public string ParserName => Prefix + "Parser";
		public string TokenType => Prefix + "TokenType";
		public string TokenizerName => Prefix + "Tokenizer";
	}

	partial class HeaderGenerator
	{
		public string Prefix { get; set; } = "My";

		public string ParserName => Prefix + "Parser";
		public string TokenizerName => Prefix + "Tokenizer";
		
		public string TokenType => Prefix + "TokenType";

		public TokenDefinitionFile Tokens { get; set; } = null;
	}

	partial class TokenizerGenerator
	{
		public string Prefix { get; set; } = "My";

		public TokenDefinitionFile Source { get; set; } = null;

		public string TokenizerName => Prefix + "Tokenizer";
		public string TokenType => Prefix + "TokenType";

		private static string MakeEnum(RegexOptions options)
		{
			if (options == RegexOptions.None)
				return "RegexOptions.None";
			return string.Join("|", Enum
				.GetValues(typeof(RegexOptions))
				.Cast<RegexOptions>()
				.Where(o => (o != RegexOptions.None))
				.Where(o => options.HasFlag(o))
				.Select(o => $"RegexOptions.{o}"));
		}
	}
}

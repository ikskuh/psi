using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
namespace CompilerKit
{
	public static class Generator
	{
		public static string Tokenizer(string prefix, string sourceFile)
		{
			var source = TokenDefinitionFile.Load(sourceFile);
			var gen = new TokenizerGenerator
			{
				Prefix = prefix,
				Source = source,
			};
			return gen.TransformText();
		}
	}
	
	partial class TokenizerGenerator
	{
		public string Prefix { get; set; } = "My";
		
		public TokenDefinitionFile Source { get; set; } = null;
		
		public string TokenizerName => Prefix + "Tokenizer";
		public string TokenType     => Prefix + "TokenType";
		
		private static string MakeEnum(RegexOptions options)
		{
			if(options == RegexOptions.None)
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

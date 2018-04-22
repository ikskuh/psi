using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrammarConverter
{
	class MainClass
	{
		private static readonly Dictionary<string, string> tokens = new Dictionary<string, string>()
		{
			{ "ROUND_O",  "(" },
			{ "ROUND_C",  ")" },
			{ "SQUARE_O", "[" },
			{ "SQUARE_C", "]" },
			{ "CURLY_O",  "{" },
			{ "CURLY_C",  "}" },
			
			{ "IMPORT",   "import" },
			{ "EXPORT",   "export" },
			{ "MODULE",   "module" },
			{ "ASSERT",   "assert" },
			{ "ERROR",   "error" },
			{ "CONST",   "const" },
			{ "VAR",   "var" },
			{ "TYPE",   "type" },
			{ "FN",   "fn" },
			{ "NEW",   "new" },
			{ "OPERATOR",   "operator" },
			{ "ENUM",   "enum" },
			{ "RECORD",   "record" },
			{ "REF",   "ref" },
			{ "ARRAY",   "array" },
			
			{ "IN",   "in" },
			{ "INOUT",   "inout" },
			{ "OUT",   "out" },
			{ "THIS",   "this" },
			
			{ "FOR",   "for" },
			{ "WHILE",   "while" },
			{ "LOOP",   "loop" },
			{ "UNTIL",   "until" },
			{ "IF",   "if" },
			{ "ELSE",   "else" },
			{ "SELECT",   "select" },
			{ "WHEN",   "when" },
			{ "OTHERWISE",   "otherwise" },
			{ "RESTRICT",   "restrict" },
			
			{ "BREAK",   "break" },
			{ "CONTINUE",   "continue" },
			{ "FALLTHROUGH",   "fallthrough" },
			{ "RETURN",   "return" },
			{ "GOTO",   "goto" },
			
			{ "WB_CONCAT",   "--=" },
			{ "WB_PLUS",   "+=" },
			{ "WB_MINUS",   "-=" },
			{ "WB_EXP",   "**=" },
			{ "WB_MULT",   "*=" },
			{ "WB_MOD",   "%=" },
			{ "WB_DIV",   "/=" },
			{ "WB_AND",   "&=" },
			{ "WB_OR",   "|=" },
			{ "WB_XOR",   "^=" },
			{ "WB_ASR",   ">>>=" },
			{ "WB_SHL",   "<<=" },
			{ "WB_SHR",   ">>=" },
			{ "MAPSTO",   "=>" },
			{ "ASR",   ">>>" },
			{ "SHL",   "<<" },
			{ "SHR",   ">>" },
			{ "FORWARD",   "->" },
			{ "BACKWARD",   "<-" },
			{ "LEQUAL",   "<=" },
			{ "GEQUAL",   ">=" },
			{ "EQUAL",   "==" },
			{ "NEQUAL",   "!=" },
			{ "LESS",   "<" },
			{ "MORE",   ">" },
			{ "IS",   "=" },
			{ "ASSIGN",   ":=" },
			{ "CONCAT",   "--" },
			{ "DOT",   "." },
			{ "META",   "\\'" },
			{ "COMMA",   "," },
			{ "TERMINATOR",   ";" },
			{ "COLON",   ":" },
			{ "LAMBDA",   "\\\\" },	

			{ "PLUS",   "+" },
			{ "MINUS",   "-" },
			{ "EXP",   "**" },
			{ "MULT",   "*" },
			{ "DIV",   "/" },
			{ "MOD",   "%" },
			
			{ "AND",   "&" },
			{ "XOR",   "^" },
			{ "OR",   "|" },
			{ "INVERT",   "~" },
			
			{ "NUMBER",   @"0x[A-Fa-f0-9]+|\d+(\.\d+)?" },
			
			{ "STRING",   @"""(?:\\""|.)*?""" },
			{ "IDENT",   @"[\w-[\d]]\w*" },
		};
	
		public static void Main(string[] args)
		{
			// this is kinda ugly, but who cares ^^
			var lines = File.ReadAllLines("../../../../PsiCompiler/Grammar/Psi.y");

			lines = lines
				.SkipWhile(a => a != "%%")
				.Skip(1)
				.TakeWhile(a => a != "%%")
				.Select(l => l.Replace("\t", "    "))
				.ToArray();

			var result = new List<string>();

			var good = true;
			foreach (var line in lines)
			{
				if (line.Trim().StartsWith("{"))
				{
					good = false;
					continue;
				}
				if (line.Trim().StartsWith("}"))
				{
					good = true;
					continue;
				}

				if (!good)
					continue;
				
				var output = line;

				var idx = output.IndexOf("{");
				if (idx >= 0)
					output = output.Substring(0, idx);

				output += " "; // apend for replacement
				foreach (var token in tokens)
					output = output.Replace(" " + token.Key + " ", " '" + token.Value + "' ");
				output = output.TrimEnd();
	
				Console.WriteLine(output);
			}
		}
	}
}

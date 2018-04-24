using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using CompilerKit;
using System.Text.RegularExpressions;

namespace MetaCompiler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            throw new NotImplementedException();
        }
    }
    /*
        var grammerFile = "/home/felix/projects/psilang/Documentation/Grammar/psi.grm";
        var tokenFile = "/home/felix/projects/psilang/Documentation/Grammar/psi.tok";

        Grammar grammar = null;

        var tokens = TokenDefinitionFile.Load(tokenFile);

        try
        {
            using (var fs = File.OpenRead(grammerFile))
            {
                using (var sr = new StreamReader(fs, Encoding.UTF8))
                {
                    var tokenizer = new GrammarTokenizer(sr, Path.GetFileName(grammerFile));

                    var parser = new GrammarParser(tokenizer);

                    grammar = parser.Parse();
                }
            }
        }
        catch (SyntaxErrorException ex)
        {
            Console.WriteLine("Failed to compile grammar:");
            foreach (var error in ex.Errors)
            {
                Console.WriteLine(
                    "{1}: {0} - {2}",
                    error.Type,
                    error.Location,
                    error.Message);
            }
            return;
        }

        var rules = grammar.Rules.ToArray();
        var names = rules.Select(r => r.Name).Distinct().ToArray();
        var terminals = new Dictionary<string, string>(); // value → key mapping ^^

        if (rules.Length != names.Length)
        {
            Console.WriteLine("The following rules are duplicated:");
            Console.WriteLine(string.Join(", ", rules.GroupBy(r => r.Name).Where(g => g.Count() > 1).Select(g => g.Key)));
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
                Console.WriteLine(
                    "Rule {0} references undefined rules: {1}",
                    rule.Name,
                    string.Join(", ", undefined));
            }
        }

        Console.WriteLine("Rules:");

        foreach (var rule in rules)
        {
            Console.WriteLine("\t{0} := {1} ;", rule.Name, rule.Syntax);
        }

        Console.WriteLine("Required terminals:");
        Console.WriteLine("\t{0}", string.Join(", ", terminals.Select(t => $"'{t}'")));

        Console.WriteLine("Provided terminals:");
        Console.WriteLine("\t{0}", string.Join(", ", tokens.Select(t => $"'{t.Key}'")));

        foreach (var terminal in terminals)
        {
            if (!tokens.ContainsKey(terminal.Value))
            {
                tokens.Add(terminal.Value, new Regex(Regex.Escape(terminal.Key), RegexOptions.Compiled));
            }
        }

        tokens.Serialize(Console.Out);
    }

    static readonly Regex patternSafeName = new Regex(@"[A-Za-z_]\w+", RegexOptions.Compiled);
    static readonly Regex patternSafeNameFix = new Regex(@"[^A-Za-z_]", RegexOptions.Compiled);
    static string MakeSafeName(string key)
    {
        switch(key)
        {
        case "{": return "sym_cbracket_opem";
        case "}": return "sym_cbracket_close";
        case "[": return "sym_sbracket_open";
        case "]": return "sym_sbracket_close";
        case "(": return "sym_rbracket_open";
        case ")": return "sym_rbracket_close";
        case "<": return "sym_pbracket_open";
        case ">": return "sym_pbracket_close";
        case ",": return "sym_comma";
        case ".": return "sym_dot";
        case "-": return "sym_hyphen";
        case "_": return "sym_underscore";
        case ":": return "sym_colon";
        case ";": return "sym_semicolon";
        case "=": return "sym_equals";
        case "!": return "sym_exclam";
        case "?": return "sym_question";
        default:
            if(patternSafeName.IsMatch(key))
                    return key;
            return "auto_" + patternSafeNameFix.Replace(key, (match) => $"x{((int)match.Value[0]).ToString()}");
        }
    }
}
*/
}

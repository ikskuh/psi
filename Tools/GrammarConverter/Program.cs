using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrammarConverter
{
	class MainClass
	{
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
	
				Console.WriteLine(output);
			}
		}
	}
}

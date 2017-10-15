using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace CompilerKit
{
	public sealed class TokenDefinitionFile : IDictionary<string, Regex>, IReadOnlyDictionary<string, Regex>
	{
		private static readonly string Separator = ":=";
		private static readonly string LineComment = "#";
	
		private readonly Dictionary<string, Regex> tokentypes = new Dictionary<string, Regex>();
		private readonly Dictionary<string, string> postprocess = new Dictionary<string, string>();

		private TokenDefinitionFile()
		{

		}
		
		public void Rename(string old, string @new)
		{
			if(tokentypes.ContainsKey(@new))
				throw new InvalidOperationException();
			if(!tokentypes.ContainsKey(old))
				throw new InvalidOperationException();
			
			tokentypes.Add(@new, tokentypes[@old]);
			tokentypes.Remove(@old);
			
			if(postprocess.ContainsKey(@old))
			{
				postprocess.Add(@new, postprocess[@old]);
				postprocess.Remove(@old);
			}
		}

		public static TokenDefinitionFile Load(string source)
		{
			return Parse(File.ReadAllText(source));
		}

		public static TokenDefinitionFile Parse(string source)
		{
			var file = new TokenDefinitionFile();
			
			var lines = source
				.Split('\n')
				.Where(l => !l.StartsWith(LineComment))
				.Where(l => l.IndexOf(Separator) > 0);
				
			var tokens = lines
				.Where(l => !l.StartsWith("PP("))
				.Select(l =>
				{
					var idx = l.IndexOf(Separator);
					var name = l.Substring(0, idx).Trim();
					var regtext = l.Substring(idx + Separator.Length).Trim();

					var options = name.Split(':');
					name = options[0].Trim();

					var rgxoptions = options
						.Skip(1)
						.Select(o => (RegexOptions)Enum.Parse(typeof(RegexOptions), o, true))
						.Aggregate(RegexOptions.Compiled, (a, b) => a | b);

					// try compile:
					var regex = new Regex(regtext, rgxoptions);

					// regtext = regtext.Replace("\"", "\"\"");
					return Tuple.Create(name, regex);
				});
			foreach (var token in tokens)
				file.tokentypes.Add(token.Item1, token.Item2);

			var ppSteps = lines
				.Where(l => l.StartsWith("PP("))
				.Select(l =>
				{
					var idx = l.IndexOf(Separator);
					var name = l.Substring(3, idx - 3).Trim();
					name = name.Substring(0, name.Length - 1);
					var code = l.Substring(idx + Separator.Length).Trim();
					return Tuple.Create(name, code);
				});
			foreach (var step in ppSteps)
				file.postprocess.Add(step.Item1, step.Item2);

			return file;
		}

		public void Serialize(TextWriter writer)
		{
			foreach(var token in this.tokentypes)
			{
				var options = token.Value.Options;
				options &= ~RegexOptions.Compiled;
				var postfix = "";
				if(options != RegexOptions.None)
				{
					postfix = string.Join(":", Enum
						.GetValues(typeof(RegexOptions))
						.Cast<RegexOptions>()
						.Where(o => (o != RegexOptions.None))
						.Where(o => options.HasFlag(o))
						.Select(o => o.ToString()));
				}
				
				writer.WriteLine("{0}{1} := {2}", token.Key, postfix, token.Value.ToString());
			}
			
			writer.WriteLine();
			
			foreach(var pp in this.postprocess)
			{
				writer.WriteLine("PP({0}) := {1}", pp.Key, pp.Value);
			}
		}

		public IDictionary<string, string> PostProcessings => this.postprocess;

		#region IReadOnlyDictionary<string, Regex>
		public Regex this[string key]
		{
			get
			{
				return tokentypes[key];
			}
		}

		public int Count
		{
			get
			{
				return tokentypes.Count;
			}
		}

		public IEnumerable<string> Keys
		{
			get
			{
				return ((IReadOnlyDictionary<string, Regex>)tokentypes).Keys;
			}
		}

		public IEnumerable<Regex> Values
		{
			get
			{
				return ((IReadOnlyDictionary<string, Regex>)tokentypes).Values;
			}
		}

		ICollection<string> IDictionary<string, Regex>.Keys
		{
			get
			{
				return ((IDictionary<string, Regex>)tokentypes).Keys;
			}
		}

		ICollection<Regex> IDictionary<string, Regex>.Values
		{
			get
			{
				return ((IDictionary<string, Regex>)tokentypes).Values;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IDictionary<string, Regex>)tokentypes).IsReadOnly;
			}
		}

		Regex IDictionary<string, Regex>.this[string key]
		{
			get
			{
				return tokentypes[key];
			}

			set
			{
				tokentypes[key] = value;
			}
		}

		public bool ContainsKey(string key)
		{
			return tokentypes.ContainsKey(key);
		}

		public IEnumerator<KeyValuePair<string, Regex>> GetEnumerator()
		{
			return ((IReadOnlyDictionary<string, Regex>)tokentypes).GetEnumerator();
		}

		public bool TryGetValue(string key, out Regex value)
		{
			return tokentypes.TryGetValue(key, out value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyDictionary<string, Regex>)tokentypes).GetEnumerator();
		}

		public void Add(string key, Regex value)
		{
			tokentypes.Add(key, value);
		}

		public bool Remove(string key)
		{
			return tokentypes.Remove(key);
		}

		public void Add(KeyValuePair<string, Regex> item)
		{
			((IDictionary<string, Regex>)tokentypes).Add(item);
		}

		public void Clear()
		{
			tokentypes.Clear();
		}

		public bool Contains(KeyValuePair<string, Regex> item)
		{
			return ((IDictionary<string, Regex>)tokentypes).Contains(item);
		}

		public void CopyTo(KeyValuePair<string, Regex>[] array, int arrayIndex)
		{
			((IDictionary<string, Regex>)tokentypes).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, Regex> item)
		{
			return ((IDictionary<string, Regex>)tokentypes).Remove(item);
		}
		#endregion
	}
}

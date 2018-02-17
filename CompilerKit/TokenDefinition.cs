using System.Text.RegularExpressions;

namespace CompilerKit
{
	public sealed class TokenDefinition<T>
	{
		public TokenDefinition(T type, Regex regex)
		{
			this.Type = type;
			this.Regex = regex;
		}

		public Regex Regex { get; private set; }
		public T Type { get; private set; }
	}
}
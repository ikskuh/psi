using System;
namespace CompilerKit
{
	public sealed class CodeLocation
	{
		public CodeLocation(int line)
		{
			if (line <= 0)
				throw new ArgumentOutOfRangeException(nameof(line));
			this.File = null;
			this.Line = line;
		}
		
		public CodeLocation(string fileName, int line)
		{
			if (string.IsNullOrWhiteSpace(fileName))
				throw new ArgumentOutOfRangeException(nameof(fileName));
			if (line <= 0)
				throw new ArgumentOutOfRangeException(nameof(line));
			this.File = fileName;
			this.Line = line;
		}

		public string File { get; }

		public int Line { get; }

		public override string ToString() => string.Format(
			"{0}:{1}",
			File ?? "<unknown>",
			Line);

	}
}

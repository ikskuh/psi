using System;
namespace CompilerKit
{
	public sealed class CodeLocation
	{
		public CodeLocation(int line, int column = 1)
		{
			if (line <= 0)
				throw new ArgumentOutOfRangeException(nameof(line));
			if (column <= 0)
				throw new ArgumentOutOfRangeException(nameof(column));
			this.File = null;
			this.Line = line;
			this.Column = column;
		}
		
		public CodeLocation(string fileName, int line, int column = 1) : this(line, column)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentOutOfRangeException(nameof(fileName));
			this.File = fileName;
		}

		public string File { get; }

		public int Line { get; }

		public int Column { get; }

		public override string ToString() => string.Format(
			"{0}:{1}:{2}",
			File ?? "<unknown>",
			Line,
			Column);
	}
}

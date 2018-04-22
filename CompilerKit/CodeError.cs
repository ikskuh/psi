using System;
namespace CompilerKit
{
	public class CodeError
	{
		public CodeError(CodeLocation location, string message) : this(location, message, CodeErrorType.Error)
		{
		
		}
		
		public CodeError(CodeLocation location, string message, CodeErrorType type)
		{
			if (location == null)
				throw new ArgumentNullException(nameof(location));
			if (message == null)
				throw new ArgumentNullException(nameof(message));
			this.Location = location;
			this.Message = message;
			this.Type = type;
		}

		public string Message { get; }

		public CodeLocation Location { get; }

		public CodeErrorType Type { get; }

		public override string ToString() => string.Format(
			"{0}: {1}: {2}",
			Type,
			Location,
			Message);
	}

	public enum CodeErrorType
	{
		Error,
		Warning
	}
}

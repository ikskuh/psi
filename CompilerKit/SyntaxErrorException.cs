using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CompilerKit
{
	[Serializable]
	public sealed class SyntaxErrorException : Exception
	{
		private readonly List<CodeError> errors = new List<CodeError>();
	
		public SyntaxErrorException(CodeError error) : base(error.ToString())
		{
			this.errors.Add(error);
		}

		public SyntaxErrorException(CodeError error, Exception innerException) : base(error.ToString(), innerException)
		{
			this.errors.Add(error);
		}
		
		public SyntaxErrorException(ICollection<CodeError> errors) : base("Multiple syntax errors occurred")
		{
			this.errors.AddRange(errors);
		}

		private SyntaxErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			
		}
		
		public IList<CodeError> Errors => this.errors;
	}
}
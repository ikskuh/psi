using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerKit
{
	public abstract class Parser<T>
	{
		private readonly Tokenizer<T> tokenizer;
		
		private Token<T> lastToken; // for error messages

		public Parser(Tokenizer<T> tokenizer)
		{
			if (tokenizer == null)
				throw new ArgumentNullException(nameof(tokenizer));
			this.tokenizer = tokenizer;
		}

		protected Token<T> Read(T type)
		{
			var token = this.Read();
			if (type.Equals(token.Type) == false)
				throw new SyntaxErrorException(new CodeError(token.Location, $"Expected token of type {type}"));
			return token;
		}
		
		protected void AssertMoreText()
		{
			var token = this.Peek();
			if(token == null)
				throw new SyntaxErrorException(new CodeError(this.lastToken.Location, "Expected more text!"));
		}
		
		protected void AssertNot(T type)
		{
			var token = this.Peek();
			if(token == null)
				return;
			if(Equals(token.Type, type))
				throw new SyntaxErrorException(new CodeError(token.Location, $"Did not expect {type} here."));
		}

		protected Token<T> Peek() => this.tokenizer.Peek();

		protected Token<T> Read()
		{
			this.lastToken = this.Peek();
			return this.tokenizer.Read();
		}

		public bool EndOfText => this.tokenizer.EndOfText;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace CompilerKit
{
	public abstract class Tokenizer<T> : IDisposable
	{
		private readonly List<TokenDefinition<T>> tokenDefs = new List<TokenDefinition<T>>();
		private readonly string fileName;

		private string fulltext;
		private int cursor = 0, lineNo = 1, colNo = 1;
		private Token<T> current;
		private TextReader reader;
		private bool closeOnDispose;

		protected Tokenizer(TextReader reader, string fileName, bool closeOnDispose)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));
			this.reader = reader;
			this.fileName = fileName;
			this.closeOnDispose = closeOnDispose;
		}

		~Tokenizer()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			if (this.closeOnDispose)
				this.reader.Close();
			GC.SuppressFinalize(this);
		}

		protected void RegisterToken(T type, Regex pattern)
		{
			this.tokenDefs.Add(new TokenDefinition<T>(type, pattern));
		}

		private void EnsureReaderIsInitialized()
		{
			if (this.fulltext != null)
				return;
			this.fulltext = "";
			this.ReadNext();
		}

		private void ReadNext()
		{
		skip:
			// Read some text:
			{
				char[] buffer = new char[4096];

				var len = this.reader.Read(buffer, 0, buffer.Length);
				if (len < 0)
					throw new EndOfStreamException("The Tokenizer reached the end of stream.");

				this.fulltext += new string(buffer, 0, len);
			}

			if (this.cursor >= this.fulltext.Length)
			{
				this.current = null;
				return;
			}

			int start = this.cursor;
			foreach (var tokdef in this.tokenDefs)
			{
				var matsch = tokdef.Regex.Match(this.fulltext, start);
				if (matsch.Success == false)
					continue;
				if (matsch.Index != start) // We don't start at the begin of our cursor.
					continue;

				// Post process our recognized token
				var token = this.PostProcess(new Token<T>(
					tokdef.Type,
					matsch.Value,
					new CodeLocation(this.fileName, this.lineNo, this.colNo)));

				for (int i = 0; i < matsch.Length; i++)
				{
					if (this.fulltext[this.cursor] == '\n')
					{
						this.lineNo++;
						this.colNo = 1;
					}
					else
					{
						this.colNo++;
					}
					this.cursor += 1;
				}

				// Restart ReadNext() to skip ignored tokens
				// recursion somehow feels bad here
				if (token == null)
					goto skip;

				this.current = token;
				return;
			}

			throw new InvalidOperationException($"Unexpected symbol {this.fulltext[this.cursor]}");
		}

		public Token<T> Peek()
		{
			this.EnsureReaderIsInitialized();
			return this.current;
		}

		public Token<T> Read()
		{
			this.EnsureReaderIsInitialized();
			var result = this.current;
			this.ReadNext();
			return result;
		}

		private Token<T> PostProcess(Token<T> t)
		{
			var newText = GetPostProcessor(t.Type)(t.Text);
			if (newText == null)
				return null;
			return new Token<T>(
				t.Type,
				newText,
				t.Location);
		}

		protected abstract Func<string, string> GetPostProcessor(T type);

		public bool EndOfText
		{
			get
			{
				this.EnsureReaderIsInitialized();
				return (this.current == null);
			}
		}
	}
}
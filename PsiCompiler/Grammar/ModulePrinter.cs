using System;
using System.IO;
using Psi.Compiler.Grammar;

namespace Psi.Compiler
{
	public sealed class ModulePrinter
	{
		readonly TextWriter writer;

		public ModulePrinter(TextWriter writer)
		{
			this.writer = writer.NotNull();
		}

		public void Print(Module module) => this.Print(module, "");

		private void Print(Module module, string indent)
		{
			writer.WriteLine("{0}'{1}' {{", indent, module.Name?.ToString() ?? "<unnamed>");
			foreach (var sub in module.Submodules)
			{
				this.Print(sub, indent + "\t");
			}
			foreach (var decl in module.Declarations)
			{
				this.Print(decl, indent + "\t");
			}
			foreach (var ass in module.Assertions)
			{
				this.Print(ass, indent + "\t");
			}
			writer.WriteLine("{0}}}", indent);
		}

		private void Print(Assertion ass, string indent)
		{
			writer.Write("{0}assert ", indent);
			this.Print(ass.Expression);
			writer.WriteLine();
		}

		private void Print(Declaration decl, string indent)
		{
			writer.Write(
				"{0}{1}{2} {3} ", 
				indent, 
				decl.IsExported ? "export " : "",
				decl.IsConst ? "const" : "var",
				decl.Name);
			if (decl.Type != null)
			{
				writer.Write(": ");
				this.Print(decl.Type);
				writer.Write(" ");
			}
			if (decl.Value != null)
			{
				writer.Write("= ");
				this.Print(decl.Value);
			}
			writer.WriteLine();
		}

		private void Print(Expression exp)
		{
			writer.Write("{0}", exp);
		}
	}
}

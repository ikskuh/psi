using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiCompiler.Grammar
{
    public abstract class Statement
    {
        sealed class NullStatement : Statement { }

        public static readonly Statement Null = new NullStatement();
    }

    public sealed class Block : Statement, IReadOnlyList<Statement>
    {
        private readonly Statement[] contents;

        public Block(IEnumerable<Statement> contents)
        {
            this.contents = contents.NotNull().ToArray();
        }

        public override string ToString() => string.Format("{{ {0} }}", string.Join(" ", this));

        public Statement this[int index] => ((IReadOnlyList<Statement>)contents)[index];

        public int Count => ((IReadOnlyList<Statement>)contents).Count;

        public IEnumerator<Statement> GetEnumerator()
        {
            return ((IReadOnlyList<Statement>)contents).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyList<Statement>)contents).GetEnumerator();
        }
    }

    public sealed class ExpressionStatement : Statement
    {
        public ExpressionStatement(Expression expr)
        {
            this.Expression = expr.NotNull();
        }

        public Expression Expression { get; }

        public override string ToString() => string.Format("{0} ;", Expression);
    }

    public sealed class FlowBreakStatement : Statement
    {
        public FlowBreakStatement(FlowBreakType type)
        {
            this.Type = type;
        }

        public FlowBreakStatement(FlowBreakType type, Expression value)
        {
            this.Type = type;
            this.Value = value.NotNull();
        }

        public FlowBreakType Type { get; }

        public Expression Value { get; }

        public override string ToString()
        {
            if (this.Value != null)
                return this.Type + " " + Value + ";";
            else
                return this.Type + ";";
        }
    }

    public enum FlowBreakType
    {
        Continue,
        Break,
        Next,
        Goto,
        Return
    }
}

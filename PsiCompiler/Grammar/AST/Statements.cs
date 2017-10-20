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

    public sealed class IfElseStatement : Statement
    {
        public IfElseStatement(Expression condition, Statement trueBody, Statement falseBody)
        {
            this.Condition = condition.NotNull();
            this.TrueBody = trueBody.NotNull();
            this.FalseBody = falseBody;
        }

        public Expression Condition { get;}

        public Statement TrueBody { get; }

        public Statement FalseBody { get; }

        public override string ToString()
        {
            if (FalseBody != null)
                return string.Format("if({0}) {1} else {2}", Condition, TrueBody, FalseBody);
            else
                return string.Format("if({0}) {1}", Condition, TrueBody);
        }
    }

    public sealed class WhileLoopStatement : Statement
    {
        public WhileLoopStatement(Expression condition, Statement body)
        {
            this.Condition = condition.NotNull();
            this.Body = body.NotNull();
        }

        public Expression Condition { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("while({0}) {1}", Condition, Body);
    }

    public sealed class LoopUntilStatement : Statement
    {
        public LoopUntilStatement(Expression condition, Statement body)
        {
            this.Condition = condition.NotNull();
            this.Body = body.NotNull();
        }

        public Expression Condition { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("loop {1} until({0});", Condition, Body);
    }

    public sealed class RestrictStatement : Statement
    {
        public RestrictStatement(IEnumerable<Expression> restrictions, Statement body)
        {
            this.Restrictions = restrictions.NotNull().ToArray();
            this.Body = body.NotNull();
        }

        public IReadOnlyList<Expression> Restrictions { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("restrict({0}) {1}", string.Join(", ", Restrictions), Body);
    }

    public sealed class ForLoopStatement : Statement
    {
        public ForLoopStatement(string variable, Expression source, Statement body)
        {
            this.Variable = variable.NotNull();
            this.Source = source.NotNull();
            this.Body = body.NotNull();
        }

        public string Variable { get; }

        public Expression Source { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("for({0} in {1}) {2}", Variable, Source, Body);
    }

    public sealed class SelectStatement : Statement
    {
        public SelectStatement(Expression selector, IEnumerable<SelectOption> options)
        {
            this.Selector = selector.NotNull();
            this.Options = options.NotNull().ToArray();
        }

        public Expression Selector { get; }

        public IReadOnlyList<SelectOption> Options { get; }

        public override string ToString() => string.Format("select({0}) {{ {1} }}", Selector, string.Join(" ", Options));
    }

    public sealed class SelectOption
    {
        public SelectOption(Block body) // otherwise
        {
            this.Body = body.NotNull();
        }

        public SelectOption(Expression value, Block body) // when
        {
            this.Value = value.NotNull();
            this.Body = body.NotNull();
        }

        public Expression Value { get; }

        public Block Body { get; }

        public override string ToString()
        {
            if (this.Value == null)
                return string.Format("otherwise: {0}", Body);
            else
                return string.Format("when {0}: {1}", Value, Body);
        }
    }
}

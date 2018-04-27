using System;
using CompilerKit;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

namespace Psi.Compiler.Grammar
{
    public abstract class Expression
    {
    }

    public sealed class NumberLiteral : Expression
    {
        public NumberLiteral(string value)
        {
            this.Value = value.NotNull();
        }

        public string Value { get; }

        public override string ToString() => Value;
    }

    public sealed class StringLiteral : Expression
    {
        /// <summary>
        /// Takes an escaped string literal
        /// </summary>
        /// <param name="value">Value.</param>
        public StringLiteral(string value)
        {
            var text = value.NotNull();

            this.Text = PsiString.Unescape(text);
        }

        /// <summary>
        /// Unescaped string literal
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; }

        public override string ToString() => "\"" + Text + "\"";
    }

    public sealed class EnumLiteral : Expression
    {
        public EnumLiteral(string value)
        {
            this.Name = value.NotNull();
        }

        public string Name { get; }

        public override string ToString() => ":" + Name;
    }

    public sealed class VariableReference : Expression
    {
        public VariableReference(string value)
        {
            this.Variable = value.NotNull();
        }

        public string Variable { get; }

        public override string ToString() => Variable;
    }

    public sealed class DotExpression : Expression
    {
        public DotExpression(Expression operand, string field)
        {
            this.Object = operand.NotNull();
            this.FieldName = field.NotNull();
        }

        public string FieldName { get; }
        public Expression Object { get; }

        public override string ToString() => "(" + Object + "." + FieldName + ")";
    }

    public sealed class MetaExpression : Expression
    {
        public MetaExpression(Expression operand, string field)
        {
            this.Object = operand.NotNull();
            this.FieldName = field.NotNull();
        }

        public string FieldName { get; }
        public Expression Object { get; }

        public override string ToString() => "(" + Object + "'" + FieldName + ")";
    }

    public sealed class UnaryOperation : Expression
    {
        public UnaryOperation(PsiOperator @operator, Expression operand)
        {
            this.Operator = @operator;
            this.Operand = operand.NotNull();
        }

        public PsiOperator Operator { get; }

        public Expression Operand { get; }

        public override string ToString() => Operator.ToSyntax() + " " + Operand;
    }

    public sealed class BinaryOperation : Expression
    {
        public BinaryOperation(PsiOperator @operator, Expression lhs, Expression rhs)
        {
            this.Operator = @operator;
            this.LeftHandSide = lhs.NotNull();
            this.RightHandSide = rhs.NotNull();
        }

        public PsiOperator Operator { get; }
        public Expression LeftHandSide { get; }
        public Expression RightHandSide { get; }

        public override string ToString() => "(" + LeftHandSide + " " + Operator.ToSyntax() + " " + RightHandSide + ")";
    }

    public sealed class ArrayIndexingExpression : Expression
    {
        public ArrayIndexingExpression(Expression value, IEnumerable<Expression> indices)
        {
            this.Value = value.NotNull();
            this.Indices = indices.ToArray();
        }

        public Expression Value { get; }

        public IReadOnlyList<Expression> Indices { get; }

        public override string ToString() => string.Format("{0}[{1}]", Value, string.Join(", ", Indices));
    }

    public sealed class FunctionCallExpression : Expression
    {
        public FunctionCallExpression(Expression value, IEnumerable<Argument> args)
        {
            this.Value = value.NotNull();

            var list = args.ToArray();

            var positionals = list.TakeWhile(x => x is PositionalArgument).ToArray();
            var named = list.SkipWhile(x => x is PositionalArgument);
            if (named.Any(a => a is PositionalArgument))
                throw new InvalidOperationException("All named arguments must be defined after the positional arguments!");

            this.PositionalArguments = positionals.Cast<PositionalArgument>().ToArray();
            this.NamedArguments = named.Cast<NamedArgument>().ToArray();

            if (NamedArguments.Select(n => n.Name).Distinct().Count() != NamedArguments.Count)
                throw new InvalidOperationException("Named arguments must be unique!");

            for (int i = 0; i < positionals.Length; i++)
                this.PositionalArguments[i].Position = i;
        }

        public Expression Value { get; }

        public IReadOnlyList<PositionalArgument> PositionalArguments { get; }

        public IReadOnlyList<NamedArgument> NamedArguments { get; }

        public IEnumerable<Argument> Arguments => this.PositionalArguments.Cast<Argument>().Concat(this.NamedArguments);

        public override string ToString() => string.Format("{0}({1})", Value, string.Join(", ", Arguments));
    }

    public abstract class Argument
    {
        protected Argument(Expression value)
        {
            this.Value = value.NotNull();
        }

        public Expression Value { get; }
    }

    public sealed class PositionalArgument : Argument
    {
        public PositionalArgument(Expression value) : base(value)
        {
        }

        public int Position { get; set; } = -1; // initialize to invalid value

        public override string ToString() => this.Value.ToString();
    }

    public sealed class NamedArgument : Argument
    {
        public NamedArgument(string name, Expression value) : base(value)
        {
            this.Name = name.NotNull();
        }

        public string Name { get; }

        public override string ToString() => string.Format("{0}: {1}", this.Name, this.Value);
    }

    public sealed class FunctionLiteral : Expression
    {
        public FunctionLiteral(FunctionTypeLiteral type, Statement body)
        {
            this.Type = type;
            this.Body = body;
        }

        public FunctionTypeLiteral Type { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("{0} => {1}", Type, Body);
    }

    public sealed class LambdaLiteral : Expression
    {
        public LambdaLiteral(IEnumerable<string> parameters, Statement body)
        {
            this.Type = new FunctionTypeLiteral(
                parameters.Select(p => new Parameter(ParameterFlags.None, p, PsiParser.Undefined, null)),
                LiteralType.Unknown);
            this.Body = body;
        }

        public FunctionTypeLiteral Type { get; }

        public Statement Body { get; }

        public override string ToString() => string.Format("{0} => {1}", Type, Body);
    }

    public sealed class ArrayLiteral : Expression
    {
        public ArrayLiteral(IEnumerable<Expression> values)
        {
            this.Values = values.ToArray();
        }

        public IReadOnlyList<Expression> Values { get; }

        public override string ToString() => string.Format("[ {0} ]", string.Join(", ", Values));
    }
}

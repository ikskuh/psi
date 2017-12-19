using System;
using CompilerKit;
using System.Collections.Generic;
using System.Linq;
using Psi.Compiler.Resolvation;
using Psi.Runtime;
using System.Globalization;
using System.Text;

namespace Psi.Compiler.Grammar
{
	public abstract class Expression
	{
		// Expression Types:
		// Call, Literal, Reference

		public virtual IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx) { throw new NotImplementedException(); }
	}

	public sealed class NumberLiteral : Expression
	{
		public NumberLiteral(string value)
		{
			this.Value = value.NotNull();
		}

		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			if (this.Value.StartsWith("0x", StringComparison.Ordinal))
			{
				yield return new Literal(new Integer(Convert.ToInt32(this.Value.Substring(2), 16)));
			}
			else
			{
				// Numbers without dots are integers
				if (this.Value.Contains('.') == false)
					yield return new Literal(new Integer(Convert.ToInt32(this.Value, CultureInfo.InvariantCulture)));

				// but all numbers are doubles
				yield return new Literal(new Real(Convert.ToDouble(this.Value, CultureInfo.InvariantCulture)));
			}
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

		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			var text = new List<Character>();
			for (int i = 0; i < this.Text.Length;)
			{
				var c = char.ConvertToUtf32(this.Text, i);
				text.Add(new Character(c));
				i += char.ConvertFromUtf32(c).Length;
			}
			yield return new Literal(new Runtime.Array(Runtime.Type.String, text));
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

		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			// Return all possible typed enumeration items
			foreach (var sym in ctx.Variables.Where(s => s.Type is TypeType).Where(s => s.KnownValue != null))
			{
				var type = (sym.KnownValue as TypeValue)?.Value as EnumType;
				if (type == null)
					continue;
				if (type.Items.Contains(this.Name))
					yield return new Literal(new EnumItem(type, this.Name));
			}
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

		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			foreach (var sym in ctx.Variables.Where(sym => sym.Name.ID == this.Variable))
				yield return new SymbolReference(sym);
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

		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			var operands = this.Operand.Resolve(ctx).ToArray();
			if (operands.Length == 0)
				yield break;

			var op = this.Operator.ToSymbolName();
			foreach (var operand in operands)
			{
				foreach (var fun in ctx.Variables
					.Where(f => f.Name.ID == op)
					.Where(f => f.Type is FunctionType)
					.Select(f => Tuple.Create(f, f.Type as FunctionType))
					.Where(f => f.Item2.Parameters.Count == 1)
					.Where(f => f.Item2.Parameters[0].Type == operand.Type)
					.Select(f => f.Item1))
				{
					yield return new FunctionCall(new SymbolReference(fun), operand);
				}
			}
		}

		public PsiOperator Operator { get; }

		public Expression Operand { get; }

		public override string ToString() => Converter.ToString(Operator) + " " + Operand;
	}

	public sealed class BinaryOperation : Expression
	{
		public BinaryOperation(PsiOperator @operator, Expression lhs, Expression rhs)
		{
			this.Operator = @operator;
			this.LeftHandSide = lhs.NotNull();
			this.RightHandSide = rhs.NotNull();
		}


		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			var lhss = this.LeftHandSide.Resolve(ctx).ToArray();
			if (lhss.Length == 0)
				yield break;

			var rhss = this.RightHandSide.Resolve(ctx).ToArray();
			if (rhss.Length == 0)
				yield break;

			var op = this.Operator.ToSymbolName();
			foreach (var lhs in lhss)
			{
				foreach (var rhs in rhss)
				{
					foreach (var fun in ctx.Variables
						.Where(f => f.Name.ID == op)
						.Where(f => f.Type is FunctionType)
						.Select(f => Tuple.Create(f, f.Type as FunctionType))
						.Where(f => f.Item2.Parameters.Count == 2)
						.Where(f => f.Item2.Parameters[0].Type == lhs.Type)
						.Where(f => f.Item2.Parameters[1].Type == rhs.Type)
						.Select(f => f.Item1))
					{
						yield return new FunctionCall(new SymbolReference(fun), lhs, rhs);
					}
				}
			}
		}

		public PsiOperator Operator { get; }
		public Expression LeftHandSide { get; }
		public Expression RightHandSide { get; }

		public override string ToString() => "(" + LeftHandSide + " " + Converter.ToString(Operator) + " " + RightHandSide + ")";
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
			
			if(NamedArguments.Select(n => n.Name).Distinct().Count() != NamedArguments.Count)
				throw new InvalidOperationException("Named arguments must be unique!");
		}

		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			var funs = this.Value.Resolve(ctx).ToArray();

			var positionals = Extensions.Permutate(this.PositionalArguments.Select((p, i) => p.Value.Resolve(ctx).Select(x => Tuple.Create(i, x)).ToArray()).ToArray()).ToList();
			var named = Extensions.Permutate(this.NamedArguments.Select(p => p.Value.Resolve(ctx).Select(x => Tuple.Create(p.Name, x)).ToArray()).ToArray()).ToList();

			if (positionals.Count == 0 || named.Count == 0)
				yield break;

			int pcount = this.PositionalArguments.Count + this.NamedArguments.Count;

			// find all functions with matching paremeter list length
			foreach (var fun in funs
				.Where(f => f.Type is FunctionType)
				.Select(f => Tuple.Create(f, f.Type as FunctionType))
				.Where(f => f.Item2.Parameters.Count == pcount)
				.Select(f => f.Item1))
			{
				var type = fun.Type as FunctionType;
				foreach (var list in positionals)
				{
					var @params = new HashSet<Psi.Runtime.Parameter>(type.Parameters);

					// When parameter mismatch, continue
					if (type.Parameters.Zip(list, (a, b) => (a.Type == b.Item2.Type)).All(b => b) == false)
						continue;

					var args = new IResolvationResult[type.Parameters.Count];
					foreach (var a in list)
					{
						args[a.Item1] = a.Item2;
						@params.Remove(type.Parameters[a.Item1]);
					}

					foreach (var nlist in named)
					{
						// Count all mismatching named arguments in nlist with the remaining parameters
						var match = nlist.Count(n => !@params.Any(p => p.Name == n.Item1));
						if (match > 0)
							continue;
						
						foreach(var na in nlist)
						{
							var param = @params.Single(p => (p.Name == na.Item1));
							args[type.Parameters.IndexOf(param)] = na.Item2;
							@params.Remove(param);
						}
						
						foreach(var pa in @params)
						{
							// TODO: Resolve default values here!
							// pa.
						}
						
						// Argument list does not fit current function
						if(@params.Count > 0)
							continue;
						
						if(args.All(a => (a != null)) == false)
							throw new InvalidOperationException("Argument list kinda matched, but isn't filled?!");
						
						yield return new FunctionCall(fun, args);
					}
				}
			}
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
		
		public override IEnumerable<IResolvationResult> Resolve(ResolvationContext ctx)
		{
			throw new NotImplementedException();
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
				parameters.Select(p => new Parameter(Psi.Runtime.ParameterFlags.None, p, PsiParser.Undefined, null)),
				new LiteralType(Psi.Runtime.Type.Void));
			this.Body = body;
		}

		public FunctionTypeLiteral Type { get; }

		public Statement Body { get; }

		public override string ToString() => string.Format("{0} => {1}", Type, Body);
	}

	/*
    public sealed class GenericArgumentsExpression : Expression
    {
        public GenericArgumentsExpression(Expression value, IEnumerable<Expression> arguments)
        {
            this.Value = value.NotNull();
            this.Arguments = arguments.ToArray();
        }

        public Expression Value { get; }

        public IReadOnlyList<Expression> Arguments { get; }

        public override string ToString() => string.Format("{0}<{1}>", Value, string.Join(", ", Arguments));
    }
    */

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

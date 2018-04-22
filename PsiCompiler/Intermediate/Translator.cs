using System;
using System.Linq;
using System.Collections.Generic;
using Psi.Compiler.Grammar;

namespace Psi.Compiler
{
	public class Translator
	{
		private readonly Scope builtins;

		public Translator()
		{
			this.builtins = CreateBuiltins();
		}

		public static void Translate(Translator instance, Psi.Compiler.Grammar.Module module)
		{
			var scope = new Scope(instance.builtins);

			var types = new List<PsiType>();
			foreach (var decl in module.TypeDeclarations)
			{
				var type = decl.Type.CreateIntermediate();
				type.IsExported = decl.IsExported;
				type.Name = decl.Name;
				type.Scope = scope;
				types.Add(type);
				scope.Types.Add(type.Name, type);
			}

			var symbols = new List<Symbol>();
			foreach (var decl in module.Declarations)
			{
				var sym = new Symbol
				{
					IsConst = decl.IsConst,
					IsExported = decl.IsExported,
					Name = decl.Name,
					Scope = scope,
					Type = decl.Type?.CreateIntermediate(),
					Value = decl.Value?.CreateIntermediate(),
				};
				if(sym.Type != null) sym.Type.Scope = scope;
				if(sym.Value != null) sym.Value.Scope = scope;
				
				if(sym.Type == null && sym.Value == null)
					throw new NotSupportedException("Undefined symbol!");
				
				if (sym.Type != null)
					types.Add(sym.Type);
				symbols.Add(sym);
			}

			int completed;
			int temp = 0;
			do
			{
				foreach (var type in types)
				{
					if (type.IsComplete)
						continue;
					type.Update(scope);
				}
				completed = temp;
				temp = types.Count(t => t.IsComplete);
			} while (temp > completed);

			if (completed != types.Count)
			{
				Console.WriteLine("Incomplete types:");
				foreach (var type in types.Where(t => !t.IsComplete))
					Console.WriteLine("{0}", type.Name);
				throw new InvalidOperationException("Could not resolve all types!");
			}

			foreach (var sym in symbols.Where(s => (s.Type != null) && (s.Value == null)).ToList())
			{
				scope.Symbols.Add(new SymbolName(sym.Type, sym.Name), sym);
			}
			
			symbols.RemoveAll(s => (s.Value == null));

			temp = 0;
			do
			{
				foreach (var sym in symbols)
				{
					if (sym.Type != null && sym.Type.IsComplete == false)
						throw new InvalidOperationException("!");
					if(sym.Value.IsComplete)
						continue;
						
					var ctx = new ExpressionContext();
					if(sym.Type != null)
						ctx.TypeHints = new [] { sym.Type };
					
					sym.Value.Update(ctx);
					
					if(sym.Value.IsComplete == false)
						continue;
					
					if(sym.Type != null)
					{
						if(sym.Type != sym.Value.Type)
							throw new InvalidOperationException("!!");
					}
					else
					{
						sym.Type = sym.Value.Type;
					}
					scope.Symbols.Add(new SymbolName(sym.Type, sym.Name), sym);
				}
				completed = temp;
				temp = symbols.Count(t => t.Value.IsComplete);
			} while (temp > completed);
			
			if(symbols.Any(s => (s.Type == null)))
				throw new InvalidOperationException("Not all symbols have types!");
			if(symbols.Any(s => (s.Value != null) && (s.Value.IsComplete == false)))
			{
				Console.WriteLine("Incomplete symbols:");
				foreach (var type in symbols.Where(t => !t.IsComplete))
					Console.WriteLine("{0}", type.Name);
				throw new InvalidOperationException("Not all symbol values were resolved!");
			}

			Console.WriteLine("Done.");
		}

		static Scope CreateBuiltins()
		{
			var scope = new Scope();
			// var vars = scope.Variabels;
			var types = scope.Types;

			var std = new IntermediateModule("std");

			scope.Modules.Add("std", std);

			var @void = PsiType.Void;
			var @int = PsiType.Integer;
			var @bool = PsiType.Boolean;
			var @char = PsiType.Character;
			var @type = PsiType.Type;
			var @string = PsiType.String;
			var @real = PsiType.Real;
			var @byte = PsiType.Byte;
			var @binary = PsiType.Binary;

			types.Add("void", @void);
			types.Add("int", @int);
			types.Add("real", @real);
			types.Add("bool", @bool);
			types.Add("char", @char);
			types.Add("string", @string);
			types.Add("byte", @byte);
			types.Add("binary", @binary);

			std.Types.Add("void", @void);
			std.Types.Add("int", @int);
			std.Types.Add("real", @real);
			std.Types.Add("bool", @bool);
			std.Types.Add("char", @char);
			std.Types.Add("string", @string);
			std.Types.Add("type", @type);
			std.Types.Add("byte", @byte);
			std.Types.Add("binary", @binary);

			/*

			// Initialize int API
			{
				var unaOpType = new FunctionType(@int, new Parameter("val", @int));
				var binOpType = new FunctionType(@int, new Parameter("lhs", @int), new Parameter("rhs", @int));
				var relOpType = new FunctionType(@bool, new Parameter("lhs", @int), new Parameter("rhs", @int));
				var assOpType = new FunctionType(@int, new Parameter("dst", @int, ParameterFlags.Out), new Parameter("val", @int));

				// unary arithmetic
				InitFunSymbol(vars, PsiOperator.Plus, new BuiltinFunction(unaOpType, (args) =>
				{
					return args[0].Value;
				}));
				InitFunSymbol(vars, PsiOperator.Minus, new BuiltinFunction(unaOpType, (args) =>
				{
					return new Integer(-(args[0].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Invert, new BuiltinFunction(unaOpType, (args) =>
				{
					return new Integer(~(args[0].Value as Integer));
				}));

				// binary arithmetic
				InitFunSymbol(vars, PsiOperator.Plus, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) + (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Minus, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) - (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Multiply, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) * (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Divide, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) / (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Modulo, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) % (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.And, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) & (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Or, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) | (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Xor, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) ^ (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Exponentiate, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer(Pow((args[0].Value as Integer), (args[1].Value as Integer)));
				}));
				InitFunSymbol(vars, PsiOperator.ShiftLeft, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) << (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.ShiftRight, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((int)((uint)(int)(args[0].Value as Integer) >> (int)(args[1].Value as Integer)));
				}));
				InitFunSymbol(vars, PsiOperator.ArithmeticShiftRight, new BuiltinFunction(binOpType, (args) =>
				{
					return new Integer((args[0].Value as Integer) >> (args[1].Value as Integer));
				}));
				
				// relational operators
				InitFunSymbol(vars, PsiOperator.More, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Integer) > (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Less, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Integer) < (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.MoreOrEqual, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Integer) >= (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.LessOrEqual, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Integer) <= (args[1].Value as Integer));
				}));
				InitFunSymbol(vars, PsiOperator.Equals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Integer).Value == (args[1].Value as Integer).Value);
				}));
				InitFunSymbol(vars, PsiOperator.NotEquals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Integer).Value != (args[1].Value as Integer).Value);
				}));
				
				InitFunSymbol(vars, PsiOperator.CopyAssign, new BuiltinFunction(assOpType, (args) =>
				{
					args[0].Value = args[1].Value;
					return null;
				}));
			}

			// Initialize bool API
			{
				var unaOpType = new FunctionType(@bool, new Parameter("val", @bool));
				var binOpType = new FunctionType(@bool, new Parameter("lhs", @bool), new Parameter("rhs", @bool));
				var relOpType = binOpType;
				var assOpType = new FunctionType(@bool, new Parameter("dst", @bool, ParameterFlags.Out), new Parameter("val", @bool));

				// unary arithmetic
				InitFunSymbol(vars, PsiOperator.Invert, new BuiltinFunction(unaOpType, (args) =>
				{
					return new Boolean(!(args[0].Value as Boolean));
				}));

				// binary arithmetic
				InitFunSymbol(vars, PsiOperator.And, new BuiltinFunction(binOpType, (args) =>
				{
					return new Boolean((args[0].Value as Boolean) & (args[1].Value as Boolean));
				}));
				InitFunSymbol(vars, PsiOperator.Or, new BuiltinFunction(binOpType, (args) =>
				{
					return new Boolean((args[0].Value as Boolean) | (args[1].Value as Boolean));
				}));
				InitFunSymbol(vars, PsiOperator.Xor, new BuiltinFunction(binOpType, (args) =>
				{
					return new Boolean((args[0].Value as Boolean) ^ (args[1].Value as Boolean));
				}));
				
				// relational operators
				InitFunSymbol(vars, PsiOperator.Equals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Boolean).Value == (args[1].Value as Boolean).Value);
				}));
				InitFunSymbol(vars, PsiOperator.NotEquals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Boolean).Value != (args[1].Value as Boolean).Value);
				}));
				
				InitFunSymbol(vars, PsiOperator.CopyAssign, new BuiltinFunction(assOpType, (args) =>
				{
					args[0].Value = args[1].Value;
					return null;
				}));
			}

			// Initialize char API
			{

				var unaOpType = new FunctionType(@char, new Parameter("val", @char));
				var relOpType = new FunctionType(@bool, new Parameter("lhs", @char), new Parameter("rhs", @char));
				var assOpType = new FunctionType(@char, new Parameter("dst", @char, ParameterFlags.Out), new Parameter("val", @char));
				
				// relational operators
				InitFunSymbol(vars, PsiOperator.More, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Character).Value > (args[1].Value as Character).Value);
				}));
				InitFunSymbol(vars, PsiOperator.Less, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Character).Value < (args[1].Value as Character).Value);
				}));
				InitFunSymbol(vars, PsiOperator.MoreOrEqual, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Character).Value >= (args[1].Value as Character).Value);
				}));
				InitFunSymbol(vars, PsiOperator.LessOrEqual, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Character).Value <= (args[1].Value as Character).Value);
				}));
				InitFunSymbol(vars, PsiOperator.Equals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Character).Value == (args[1].Value as Character).Value);
				}));
				InitFunSymbol(vars, PsiOperator.NotEquals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as Character).Value != (args[1].Value as Character).Value);
				}));
				
				InitFunSymbol(vars, PsiOperator.CopyAssign, new BuiltinFunction(assOpType, (args) =>
				{
					args[0].Value = args[1].Value;
					return null;
				}));
			}
			
			// Initialize type API
			{

				var relOpType = new FunctionType(@bool, new Parameter("lhs", @type), new Parameter("rhs", @type));
				var assOpType = new FunctionType(@type, new Parameter("dst", @type, ParameterFlags.Out), new Parameter("val", @type));

				// relational operators
				InitFunSymbol(vars, PsiOperator.Equals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as TypeValue).Value == (args[1].Value as TypeValue).Value);
				}));
				InitFunSymbol(vars, PsiOperator.NotEquals, new BuiltinFunction(relOpType, (args) =>
				{
					return new Boolean((args[0].Value as TypeValue).Value != (args[1].Value as TypeValue).Value);
				}));
				
				InitFunSymbol(vars, PsiOperator.CopyAssign, new BuiltinFunction(assOpType, (args) =>
				{
					args[0].Value = args[1].Value;
					return null;
				}));
			}
			
			// Initialize basic I/O functions
			{
				InitFunSymbol(vars, "println", new BuiltinFunction(new FunctionType(), (args) => 
				{
					Console.WriteLine();
					return null;
				}));
				InitFunSymbol(vars, "print", new BuiltinFunction(new FunctionType(new Parameter("val", @int)), (args) => 
				{
					Console.Write("{0}", (args[0].Value as Integer).Value);
					return null;
				}));
				InitFunSymbol(vars, "print", new BuiltinFunction(new FunctionType(new Parameter("val", @char)), (args) => 
				{
					Console.Write("{0}", char.ConvertFromUtf32((args[0].Value as Character).Value));
					return null;
				}));
				InitFunSymbol(vars, "print", new BuiltinFunction(new FunctionType(new Parameter("val", @string)), (args) => 
				{
					var value = args[0].Value as Runtime.Array;
					var text = string.Join<string>("", value.Select(v => char.ConvertFromUtf32((v as Character).Value)));
					Console.Write("{0}", text);
					return null;
				}));
			}
			
			*/
			return scope;
		}

		/*
		static Symbol InitFunSymbol(VariableScope scope, PsiOperator id, FunctionPrototype proto)
		{
			var sym = scope.Add(new SymbolName(proto.Type, id));
			sym.IsConst = true;
			sym.IsExported = false;
			sym.KnownValue = new Function(proto);
			return sym;
		}

		static Symbol InitFunSymbol(VariableScope scope, string id, FunctionPrototype proto)
		{
			var sym = scope.Add(new SymbolName(proto.Type, id));
			sym.IsConst = true;
			sym.IsExported = false;
			sym.KnownValue = new Function(proto);
			return sym;
		}

		static int Pow(int bas, int exp)
		{
			return Enumerable
				  .Repeat(bas, exp)
				  .Aggregate(1, (a, b) => a * b);
		}
		*/
	}
}

using System;
using Psi.Runtime;
using Psi.Compiler.Resolvation;
using System.Linq;
using System.Collections.Generic;

namespace Psi.Compiler
{
	using Type = Psi.Runtime.Type;
	using Boolean = Psi.Runtime.Boolean;
	using Psi.Compiler.Resolvation;
	
	public class Translator
	{
		private readonly ResolvationContext builtin;
		
		public Translator()
		{
			builtin = CreateBuiltins();
		}

		public Program Translate(Psi.Compiler.Grammar.Module module)
		{
			var root = builtin.DeriveChild();
			
			// TODO: Implement "import" here
			// module.Imports
			
			// TODO: Resolve submodules
			// module.Submodules
			
			// TODO: Validate "assert" here
			// module.Assertions
			
			var ctx = root.DeriveChild();
			var vars = ctx.Variables;
			var types = ctx.Types;
			
			{
				var decls = new Queue<Grammar.TypeDeclaration>(module.TypeDeclarations);
				
				var syms = new Dictionary<Grammar.TypeDeclaration, TypeSymbol>();
				
				Grammar.TypeDeclaration marker = null;
				while(decls.Count > 0)
				{
					var decl = decls.Dequeue();
					if(marker == decl)
					{
						Console.WriteLine("Unresolved type symbols:");
						foreach(var d in decls.Append(decl))
							Console.WriteLine("{0}", d.Name);
					
						throw new InvalidOperationException("Could not compile!");
					}
					
					var type = decl.Type.Resolve(ctx).SingleOrDefault();
					if(type == null)
					{
						if(marker == null)
							marker = decl;
						decls.Enqueue(decl);
						continue;
					}
					
					Console.WriteLine("Resolved {0} to {1}", decl.Name, type);
					
					var sym = types.Add(decl.Name, type);
					sym.IsExported = decl.IsExported;
					
					marker = null;
				}
			}
			{
				var decls = new Queue<Grammar.Declaration>(module.Declarations);
				
				var syms = new Dictionary<Grammar.Declaration, Symbol>();
				
				while(decls.Count > 0)
				{
					Symbol sym;
					var decl = decls.Dequeue();
					if(syms.TryGetValue(decl, out sym) == false)
					{
						var type = decl.Type.Resolve(ctx).SingleOrDefault();
						if(type == null)
						{
							decls.Enqueue(decl);
							continue;
						}
						syms.Add(decl, sym = vars.Add(new SymbolName(type, decl.Name)));
						sym.IsConst = decl.IsConst;
						sym.IsExported = decl.IsExported;
					}
					if(sym == null) throw new InvalidOperationException("!");
					
					;
				}
			}
			
			var pgm = new Program();
			
			return pgm;
		}

		static ResolvationContext CreateBuiltins()
		{
			var vars = new VariableScope();
			var types = new TypeScope();
			
			var @void = Type.Void;
			var @int = Type.Integer;
			var @bool = Type.Boolean;
			var @char = Type.Character;
			var @type = Type.PsiType;
			var @string = Type.String;
			var @real = Type.Real;

			types.Add("void", @void);
			types.Add("int", @int);
			types.Add("real", @real);
			types.Add("bool", @bool);
			types.Add("char", @char);
			types.Add("string", @string);
			types.Add("type", @type);

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
	
			return new ResolvationContext(vars, types);
		}

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
	}
}

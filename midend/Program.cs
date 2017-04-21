using System;
using midend.AbstractSyntaxTree;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace midend
{
	using NLua;

	class MainClass
	{
		public static void Main(string[] args)
		{
			var cfg = new CompilerConfiguration();

			if (Debugger.IsAttached)
			{
				Console.SetIn(new StreamReader("/tmp/foobar.xml", Encoding.ASCII));
			}

			var ast = AST.Load(Console.In);

			AST.Store(Console.Out, ast);

			Console.WriteLine();

			var globalScope = CreateGlobalScope(cfg);

			var compileUnitScope = new Scope(globalScope);

			// Step #1: Create all declared modules in the unit scope.
			ast.BuildModuleStructure(compileUnitScope);

			// Step #2: Gather all declared symbols for all modules,
			//          without actually creating them
			var declarations = ast.GatherSymbols(compileUnitScope).ToList();

			// Step #3: Resolve the types of all declarations, try to build all definitions
			while (declarations.Count > 0)
			{
				var declPrecount = declarations.Count;

				for (int i = 0; i < declarations.Count; i++)
				{
					var decl = declarations[i];
					if (decl.InitialValue != null && decl.Value == null)
					{
						decl.TryCreateValue();
					}
					if (decl.CanCreateSymbol == false)
					{
						decl.TryResolveType();
						if (decl.CanCreateSymbol == false)
							continue;
					}
					var sym = decl.CreateSymbol();
					if (decl.InitialValue != null)
					{
						if (decl.Value == null)
							throw new InvalidOperationException("This should not happen: Value was not created already!");
						sym.InitialValue = decl.Value.Simplify();
					}

					declarations.RemoveAt(i);
					i -= 1; // Adjust offset
				}

				if (declarations.Count == declPrecount)
					throw new InvalidOperationException("Cyclic dependency detected, can't resolve!");
			}

			Console.WriteLine("Complete module:");
			PrintScope(compileUnitScope, compileUnitScope.Locals, "\t");
		}

		private static void PrintScope(Scope scope, IEnumerable<Signature> elements, string prefix = "")
		{
			foreach (var sig in elements)
			{
				var sym = scope[sig];
				Console.Write("{0}{2}{1}", prefix, sig, sym.HasStaticValue ? "static " : "");
				if (sym.InitialValue != null)
				{
					Console.Write(" = {0}", sym.InitialValue);
				}
				Console.WriteLine();
				if (sig.Type == ModuleType.Instance)
				{
					Console.WriteLine("{0}{{", new string(prefix.TakeWhile(char.IsWhiteSpace).ToArray()));
					var mod = (Scope)scope[sig].InitialValue.Evaluate(null).Value;
					PrintScope(mod, mod.Locals, "\t" + prefix);
					Console.WriteLine("{0}}}", new string(prefix.TakeWhile(char.IsWhiteSpace).ToArray()));
				}
			}
		}

		/// <summary>
		/// Creates the global scope with all included std modules
		/// </summary>
		/// <returns>The global scope.</returns>
		/// <param name="cfg">Cfg.</param>
		static Scope CreateGlobalScope(CompilerConfiguration cfg)
		{
			var globalScope = new Scope();

			var types = new Dictionary<string, CType>()
			{
				{ "string", CTypes.String },
				{ "bool", CTypes.Boolean },
				{ "char", CTypes.Char },
				
				// Create new integer types that have system size
				{ "int", new IntegerType(-(new BigInteger(1) << (cfg.IntegerWidth - 1)), (new BigInteger(1) << (cfg.IntegerWidth - 1))- 1, IntegerOverflowBehaviour.Failing) },
				{ "uint", new IntegerType(0, (new BigInteger(1) << cfg.IntegerWidth) - 1, IntegerOverflowBehaviour.Failing) }
			};
			foreach (var type in types)
			{
				globalScope.AddSymbol(type.Key, type.Value);
			}

			{ // i32 operators
				var optype = new BinaryOperatorType(IntegerType.Int32, IntegerType.Int32);
				globalScope.AddSymbol(Operator.Add, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(IntegerType.Int32, (BigInteger)arr[0].Value + (BigInteger)arr[1].Value);
				}));
				globalScope.AddSymbol(Operator.Sub, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(IntegerType.Int32, (BigInteger)arr[0].Value - (BigInteger)arr[1].Value);
				}));
				globalScope.AddSymbol(Operator.Times, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(IntegerType.Int32, (BigInteger)arr[0].Value * (BigInteger)arr[1].Value);
				}));
				globalScope.AddSymbol(Operator.Divide, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(IntegerType.Int32, (BigInteger)arr[0].Value / (BigInteger)arr[1].Value);
				}));
				globalScope.AddSymbol(Operator.Modulo, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(IntegerType.Int32, (BigInteger)arr[0].Value % (BigInteger)arr[1].Value);
				}));
			}

			{
				var std = new Module();

				std.AddSymbol("type", CTypes.Type);
				std.AddSymbol("module", CTypes.Module);

				{ // std.integers
					var stdint = new Module();
					var inttypes = new Dictionary<string, CType>()
					{
						{ "u8", IntegerType.UInt8 },
						{ "u16", IntegerType.UInt16 },
						{ "u32", IntegerType.UInt32 },
						{ "u64", IntegerType.UInt64 },
						{ "i8", IntegerType.Int8 },
						{ "i16", IntegerType.Int16 },
						{ "i32", IntegerType.Int32 },
						{ "i64", IntegerType.Int64 },
					};
					foreach (var type in inttypes)
					{
						stdint.AddSymbol(type.Key, type.Value);
					}
					std.AddSymbol("integers", stdint);
				}

				{ // std.system
					var stdsys = new Module();

					stdsys.AddSymbol(new Symbol("os", CTypes.String)
					{
						IsConst = true,
						IsExported = true,
						InitialValue = Expression.Constant(Environment.OSVersion.ToString())
					});




					std.AddSymbol("system", stdsys);
				}

				globalScope.AddSymbol("std", std);
			}

			return globalScope;
		}
	}
}
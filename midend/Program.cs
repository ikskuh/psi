using System;
using midend.AbstractSyntaxTree;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

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

			
			ast.GatherModulesAndSymbols();
			
			
			

			PrintScope(compileUnitScope, compileUnitScope.Locals);
		}

		private static void PrintScope(Scope scope, IEnumerable<Signature> elements, string prefix = "")
		{
			foreach (var sig in elements)
			{
				Console.WriteLine("{0}{1}", prefix, sig);
				if (sig.Type == ModuleType.Instance)
				{
					var mod = (Scope)scope[sig].InitialValue.Evaluate(null).Value;
					PrintScope(mod, mod.Locals, prefix + sig.Name + ".");
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
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

			// Step #1: Create all declared modules in the unit scope.
			var unit = ast.BuildModuleStructure(globalScope, "unit");

			// Step #2: Gather all declared symbols for all modules,
			//          without actually creating them
			var declarations = ast.GatherSymbols(unit).ToList();

			// Step #3: Resolve the types of all declarations, try to build all definitions
			while (declarations.Count > 0)
			{
				var declPrecount = declarations.Count;

				for (int i = 0; i < declarations.Count; i++)
				{
					var decl = declarations[i];
					Console.WriteLine("Try resolve {0}", decl.Name);
					if (decl.InitialValue != null && decl.Value == null)
					{
						decl.TryCreateValue();
					}
					Symbol sym;
					if (decl.Symbol == null && decl.CanCreateSymbol == false)
					{
						decl.TryResolveType();
						if (decl.CanCreateSymbol == false)
							continue;
						sym = decl.CreateSymbol();
					}
					if (decl.InitialValue != null)
					{
						if (decl.Value == null)
							continue; // throw new InvalidOperationException("This should not happen: Value was not created already!");
						decl.TryCreateValue();
					}

					Console.WriteLine("Resolved {0} : {1}", decl.Name, decl.Type);

					declarations.RemoveAt(i);
					i -= 1; // Adjust offset
				}

				if (declarations.Count == declPrecount)
				{
					Console.Error.WriteLine("Failed to translate:");
					foreach (var decl in declarations)
					{
						Console.Error.WriteLine(decl.Name);
					}
					throw new InvalidOperationException("Cyclic dependency detected, can't resolve!");
				}
			}

			// Step #3: Validate all assertions!
			foreach (var assert in ast.CreateAllAssertions(unit))
			{
				Console.WriteLine("Validate assertion in {0}: {1}", assert.Module, assert.Validate(false) ? "success" : "failure");
			}

			Console.WriteLine("Complete module:");
			PrintScope(unit.Scope, unit.Scope.Locals, "\t");
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
		static Module CreateGlobalScope(CompilerConfiguration cfg)
		{
			var globalScope = new Module();

			var types = new Dictionary<string, CType>()
			{
				{ "string", CTypes.String },
				{ "bool", CTypes.Boolean },
				{ "char", CTypes.Char },
				{ "int", CTypes.Integer },
			};
			foreach (var type in types)
			{
				globalScope.Scope.AddSymbol(type.Key, type.Value);
			}

			globalScope.Scope.AddSymbol("true", (CValue)true);
			globalScope.Scope.AddSymbol("false", (CValue)false);

			{ // i32 operators
				var optype = new BinaryOperatorType(CTypes.Integer, CTypes.Integer);
				var unoptype = new UnaryOperatorType(CTypes.Integer, CTypes.Integer);
				var opcomp = new BinaryOperatorType(CTypes.Integer, CTypes.Boolean);

				globalScope.Scope.AddSymbol(Operator.Add, new BuiltinFunction(unoptype, (arr) =>
				{
					return (CValue)(arr[0].Get<BigInteger>());
				}));
				globalScope.Scope.AddSymbol(Operator.Sub, new BuiltinFunction(unoptype, (arr) =>
				{
					return (CValue)(-arr[0].Get<BigInteger>());
				}));

				globalScope.Scope.AddSymbol(Operator.Add, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(CTypes.Integer, (BigInteger)arr[0].Value + (BigInteger)arr[1].Value);
				}));
				globalScope.Scope.AddSymbol(Operator.Sub, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(CTypes.Integer, (BigInteger)arr[0].Value - (BigInteger)arr[1].Value);
				}));
				globalScope.Scope.AddSymbol(Operator.Times, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(CTypes.Integer, (BigInteger)arr[0].Value * (BigInteger)arr[1].Value);
				}));
				globalScope.Scope.AddSymbol(Operator.Divide, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(CTypes.Integer, (BigInteger)arr[0].Value / (BigInteger)arr[1].Value);
				}));
				globalScope.Scope.AddSymbol(Operator.Modulo, new BuiltinFunction(optype, (arr) =>
				{
					return new CValue(CTypes.Integer, (BigInteger)arr[0].Value % (BigInteger)arr[1].Value);
				}));

				globalScope.Scope.AddSymbol(Operator.Less, new BuiltinFunction(opcomp, (arr) =>
				{
					return new CValue(CTypes.Boolean, (BigInteger)arr[0].Value < (BigInteger)arr[1].Value);
				}));
				globalScope.Scope.AddSymbol(Operator.Equals, new BuiltinFunction(opcomp, (arr) =>
				{
					return new CValue(CTypes.Boolean, (BigInteger)arr[0].Value == (BigInteger)arr[1].Value);
				}));
			}

			{ // String operators
				var optype = new BinaryOperatorType(CTypes.String, CTypes.String);
				var opcomp = new BinaryOperatorType(CTypes.String, CTypes.Boolean);

				globalScope.Scope.AddSymbol(Operator.Concatenate, new BuiltinFunction(optype, (arr) =>
				{
					return (CValue)(arr[0].Get<string>() + arr[1].Get<string>());
				}));

				globalScope.Scope.AddSymbol(Operator.Equals, new BuiltinFunction(opcomp, (arr) =>
				{
					return (CValue)(arr[0].Get<string>() == arr[1].Get<string>());
				}));
				globalScope.Scope.AddSymbol(Operator.Inequals, new BuiltinFunction(opcomp, (arr) =>
				{
					return (CValue)(arr[0].Get<string>() != arr[1].Get<string>());
				}));
			}

			{
				var binoptype = new BinaryOperatorType(CTypes.Boolean, CTypes.Boolean);
				var unoptype = new UnaryOperatorType(CTypes.Boolean, CTypes.Boolean);

				globalScope.Scope.AddSymbol(Operator.Invert, new BuiltinFunction(unoptype, (arg) =>
				{
					return (CValue)(!arg[0].Get<bool>());
				}));

				globalScope.Scope.AddSymbol(Operator.And, new BuiltinFunction(binoptype, (arg) =>
				{
					return (CValue)(arg[0].Get<bool>() && arg[1].Get<bool>());
				}));

				globalScope.Scope.AddSymbol(Operator.Or, new BuiltinFunction(binoptype, (arg) =>
				{
					return (CValue)(arg[0].Get<bool>() || arg[1].Get<bool>());
				}));

				globalScope.Scope.AddSymbol(Operator.Xor, new BuiltinFunction(binoptype, (arg) =>
				{
					return (CValue)(arg[0].Get<bool>() ^ arg[1].Get<bool>());
				}));

			}

			{
				var std = globalScope.AddSubModule("std");

				std.Scope.AddSymbol("type", CTypes.Type);
				std.Scope.AddSymbol("module", CTypes.Module);

				{ // std.system
					var stdsys = std.AddSubModule("system");
					stdsys.Scope.AddSymbol("os", (CValue)Environment.OSVersion.ToString());
					stdsys.Scope.AddSymbol("platform", (CValue)Environment.OSVersion.Platform.ToString());
				}
			}

			return globalScope;
		}
	}
}
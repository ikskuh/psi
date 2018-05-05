using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LLVMSharp;
using Psi.Compiler.Intermediate;

using PModule = Psi.Compiler.Intermediate.Module;
using LModule = LLVMSharp.Module;

namespace Psi.Compiler.Codegen
{
    public sealed class CodeGenerator
    {
        private readonly PModule source;

        private readonly TypeStorage types = new TypeStorage();

        // private readonly LLVMModuleRef module;
        public static LLVMModuleRef module;

        private readonly LLVMBuilderRef builder;

        private readonly Dictionary<Function, LLVMValueRef> functions = new Dictionary<Function, LLVMValueRef>();

        internal readonly Dictionary<Symbol, LLVMValueRef> symbols = new Dictionary<Symbol, LLVMValueRef>();

        private LLVMValueRef moduleInitializerFunction;
        private LLVMValueRef moduleInitializerBlock;

        private CodeGenerator(PModule output)
        {
            this.source = output;
            // module = LLVM.ModuleCreateWithName(output.Name);
            builder = LLVM.CreateBuilder();

            moduleInitializerFunction = LLVM.AddFunction(module, "module.init", LLVM.FunctionType(LLVM.VoidType(), new LLVMTypeRef[0], false));

            moduleInitializerBlock = LLVM.AppendBasicBlock(moduleInitializerFunction, "entry");
        }

        /// <summary>
        /// Generates intermediate language code
        /// </summary>
        /// <param name="output"></param>
        public static void GenerateIL(PModule output)
        {
            var codegen = new CodeGenerator(output);

            codegen.Initialize();
        
            LLVM.DumpModule(module);
        }

        private void Initialize()
        {
            foreach (var sym in source.Symbols)
                GenSymbol(sym.Value);

            {
                foreach (var sym in source.Symbols.Values.Where(s => s.Initializer != null))
                    GenInitializer(sym);

                // finish off the initializer
                LLVM.PositionBuilderAtEnd(this.builder, moduleInitializerBlock);
                LLVM.BuildRetVoid(this.builder);
            }

            // Instantiate all referenced user functions
            var closedList = new HashSet<Function>();
            while(true)
            {
                var all = functions.Keys.Cast<Function>().Except(closedList).ToArray();
                if (all.Length == 0)
                    break;
                foreach (var f in all)
                {
                    if (f is UserFunction user)
                        GenFunction(user, functions[f]);
                }
                closedList.UnionWith(all);
            }

        }

        private void GenSymbol(Symbol sym)
        {
            if (sym?.Type == null) throw new ArgumentException();

            var type = types.Get(sym.Type);
            
            var value = LLVM.AddGlobal(module, type, sym.Name.ID);
            // LLVM.SetInitializer(value, LLVM.ConstAllOnes(type));
            symbols.Add(sym, value);
        }

        private void GenInitializer(Symbol sym)
        {
            if (sym?.Initializer == null) throw new ArgumentException();
            
            LLVM.PositionBuilderAtEnd(this.builder, moduleInitializerBlock);
            
            var expr = new ExpressionCompiler(this, builder, moduleInitializerFunction);
            var value = expr.Compile(sym.Initializer);

            LLVM.BuildStore(builder, value, symbols[sym]);
        }

        private void GenFunction(UserFunction user, LLVMValueRef value)
        {
            for (int i = 0; i < user.Type.Parameters.Length; i++)
            {
                LLVMValueRef param = LLVM.GetParam(value, (uint)i);
                LLVM.SetValueName(param, user.Type.Parameters[i].Name);
            }

            // Create a new basic block to start insertion into.
            LLVM.PositionBuilderAtEnd(this.builder, LLVM.AppendBasicBlock(value, "entry"));

            // Create function body here
            CompileUserFunction(value, user);

            // Finish off the function with a default return value
            LLVM.BuildRetVoid(this.builder);

            // Validate the generated code, checking for consistency.
            LLVM.VerifyFunction(value, LLVMVerifierFailureAction.LLVMPrintMessageAction);
        }

        public LLVMValueRef GetFunction(Function fun)
        {
            if (functions.TryGetValue(fun, out var value))
                return value;
            if(fun is BuiltinFunction builtin)
            {
                value = builtin.Function;
            }
            else if (fun is UserFunction user)
            {
                var name = $"psifun@{source.Functions.TakeWhile(f => f != user).Count()}"; // fake index of

                var type = types.GetForFunction(fun.Type);

                value = LLVM.AddFunction(module, name, type);
            }
            else
            {
                throw new NotSupportedException();
            }
            functions.Add(fun, value);
            return value;
        }

        public LLVMValueRef GetFunctionPointer(Function fun)
        {
            var val = GetFunction(fun);

            return val;
        }

        public LLVMValueRef GetGlobalVariable(Symbol sym)
        {
            if(sym.IsConst && (sym.Initializer is FunctionLiteral lit))
            {
                return GetFunctionPointer(lit.Value);
            }
            return symbols[sym];
        }

        private void CompileUserFunction(LLVMValueRef function, UserFunction user)
        {
            var compiler = new StatementCompiler(this, function, this.builder);
            compiler.Compile(user.Body);
        }
    }
}

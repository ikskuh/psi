using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psi.Compiler.Grammar;

namespace Psi.Compiler.Intermediate
{
    public class ASTConverter
    {
        private readonly List<TranslationUnit> units = new List<TranslationUnit>();

        private readonly Dictionary<string, Module> modules = new Dictionary<string, Module>();

        public IFormatProvider SystemFormat => CultureInfo.InvariantCulture;

        public IScope GlobalScope { get; }

        protected CompilerErrorCollection Error { get; }

        public ASTConverter(IScope globalScope)
        {
            this.Error = new CompilerErrorCollection();
            this.GlobalScope = globalScope ?? throw new ArgumentNullException(nameof(globalScope));
        }

        #region Module Management

        public void AddModule(Grammar.Module module) => this.AddModule(module, null);

        private Module AddModule(Grammar.Module module, TranslationUnit parent)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));

            if (units.Any(u => u.Source == module))
                throw new InvalidOperationException("Cannot add the same module twice!");

            var name = (parent != null ? parent.Module.Name + "." : "") + module.Name;
            Module target = null;
            {
                var parts = name.Split('.');
                for (int i = 0; i < parts.Length; i++)
                {
                    var mname = string.Join(".", parts, 0, i + 1);
                    if (modules.ContainsKey(mname))
                    {
                        target = modules[mname];
                    }
                    else
                    {
                        var child = new Module(target, mname);
                        modules.Add(mname, child);
                        if (target != null)
                        {
                            target.Symbols.Add(new Symbol(Type.ModuleType, child.LocalName)
                            {
                                Initializer = new Literal<Module>(child),
                                IsConst = true,
                                IsExported = true
                            });
                        }
                        target = child;
                    }
                }
            }
            if (target?.Name != name)
                throw new InvalidOperationException("An error happened in module name resolvation!");

            var tu = new TranslationUnit(module, target);

            // Initialize the base scope of the translation unit
            if (parent == null)
                tu.Scope.Push(this.GlobalScope);
            else
                tu.Scope.Push(parent.Scope);
            tu.Scope.Push(tu.Imports);
            tu.Scope.Push(tu.Module.Symbols);

            this.units.Add(tu);

            // Now create each lexical sub-module (not logical submodule!)
            foreach (var sm in module.Submodules)
                this.AddModule(sm, tu);

            return target;
        }

        /// <summary>
        /// Gets a compiled module for an abstract module
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public Module GetModule(Grammar.Module module)
        {
            var tu = units.FirstOrDefault(u => u.Source == module);
            if (tu == null)
                throw new ArgumentOutOfRangeException(nameof(module));
            if (tu.IsComplete == false)
                throw new InvalidOperationException("Cannot get an incomplete module");
            return tu.Module;
        }

        /// <summary>
        /// Gets a list of all created modules
        /// </summary>
        /// <returns></returns>
        public Module[] GetModules()
        {
            if (this.units.Any(u => !u.IsComplete))
                throw new InvalidOperationException("Not all units were successfully translated!");
            return this.units.Select(u => u.Module).Distinct().ToArray();
        }

        #endregion

        public void Convert()
        {
            // Step 1: Prepare all compilation steps

            // Prepare type symbols
            foreach (var unit in this.units)
                this.CreateTypeSymbols(unit);

            // Prepare imports
            foreach (var unit in this.units)
                this.ImportSymbolsIntoUnit(unit);

            // Prepare rest of the symbols
            foreach (var unit in this.units)
                this.CreateVariables(unit);

            // Now set each unit to prepared
            foreach (var unit in this.units)
                unit.IsCompletlyPrepared = true;

            // Step 2: Run tasks until all tasks are done:
            while (this.units.Sum(u => u.Tasks.Count) > 0)
            {
                var anySuccess = false;

                ICollection<CompilerError> errors = this.Error; // explicit interface 
                errors.Clear();
                foreach (var unit in this.units)
                {
                    // take the current set of tasks and dequeue them
                    int count = unit.Tasks.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var task = unit.Tasks.Dequeue();
                        try
                        {
                            var error = task();
                            if (error != CompilerError.None)
                            {
                                unit.Tasks.Enqueue(task);
                                continue;
                            }
                            anySuccess = true;
                        }
                        catch (Exception ex)
                        {
                            errors.Add(new CompilerError(ex.Message));
                            unit.Tasks.Enqueue(task);
                        }
                    }
                }
                if (!anySuccess)
                {
                    foreach (var err in errors)
                        Console.Error.WriteLine("{0}", err.Description);
                    throw new InvalidOperationException("Cyclic dependency or other error encountered!");
                }
            }

            // Step 3: Postprocess the converted modules

            // Step 4: Validate all assertions

            Console.WriteLine("Compilation successful.");
        }

        private CompilerError CreateSymbol(TranslationUnit unit, IScope scope, Declaration def, out Symbol sym)
        {
            sym = null;

            Type type;
            if (def.Type != null)
                type = ConvertType(unit, scope, def.Type);
            else
                type = Type.UnknownType;

            if (type == null)
                return Error.UnresolvableType(def.Type);

            Expression initializer = null;
            if (def.Value != null)
            {
                // TODO: A type hint should be passed into convert expression here
                var values = ConvertExpression(unit, scope, def.Value);
                if (values.Count > 1)
                {
                    if (type == Type.UnknownType)
                    {
                        // TODO: Implement integer inferring
                        throw Error.AmbiguousExpression(def.Value, values);
                    }
                    else
                    {
                        initializer = SelectFitting(values, type);
                    }
                }
                else
                {
                    initializer = values.Single();
                }
                if (initializer == null)
                    return Error.InvalidExpression(def.Value);
            }

            if ((type == Type.UnknownType) && (initializer == null))
                return Error.InvalidSymbol(def);

            if ((type == Type.UnknownType) && (initializer != null))
            {
                type = initializer.Type;
                if ((type == null) || (type == Type.UnknownType))
                    return Error.UndeducedType(def);
            }

            if ((initializer != null) && (type != initializer.Type))
                return Error.TypeMismatch(type, initializer);

            if ((type == null) || (type == Type.UnknownType))
                return Error.Critical("Failed to create type!");

            sym = new Symbol(type, def.Name)
            {
                IsConst = def.IsConst,
                IsExported = def.IsExported,
                Initializer = initializer,
            };

            if (def.IsConst && (sym.Initializer == null))
                return Error.RequiresInitializer(sym);

            return Error.None;
        }

        private void CreateVariables(TranslationUnit unit)
        {
            foreach (var def in unit.Source.Declarations)
            {
                unit.AddTask(() =>
                {
                    var err = CreateSymbol(unit, unit.Scope, def, out var sym);
                    if (err != CompilerError.None)
                        return err;

                    if (unit.Module.Symbols.ContainsKey(sym.Name))
                        return Error.AlreadyDeclared(sym.Name);

                    unit.Module.Symbols.Add(sym);

                    return Error.None;
                });
            }
        }

        private void ImportSymbolsIntoUnit(TranslationUnit unit)
        {
            foreach (var name in unit.Source.Imports)
            {
                unit.AddTask(() =>
                {
                    var sym = GlobalScope.FindNamedSymbol(name, Type.ModuleType, true);
                    if (sym == null)
                        return Error.UnknownImport(name);
                    var mod = sym.GetValue<Module>();
                    if (mod == null)
                        throw new InvalidOperationException("imported module is not a constant!");

                    unit.Imports.Push(mod.Symbols);

                    return CompilerError.None;
                });
            }
        }

        private void CreateTypeSymbols(TranslationUnit unit)
        {
            foreach (var decl in unit.Source.TypeDeclarations)
            {
                unit.AddTask(() =>
                {
                    Type type = ConvertType(unit, unit.Scope, decl.Type);
                    if (type == null)
                        return Error.UnresolvableType(decl.Type);
                    if (type == Type.UnknownType)
                        throw new InvalidOperationException("Unknown type not allows in declaration");
                    if (type == Type.VoidType)
                        throw new InvalidOperationException("Void type may not be aliased!");
                    unit.Module.Symbols.Add(new Symbol(Type.MetaType, decl.Name)
                    {
                        IsConst = true,
                        IsExported = decl.IsExported,
                        Initializer = new Literal<Type>(type),
                    });
                    return CompilerError.None;
                });
            }
        }

        private Type ConvertType(TranslationUnit unit, IScope scope, AstType asttype)
        {
            if (asttype is LiteralType lt)
            {
                if (lt == LiteralType.Void)
                    return Type.VoidType;
                else if (lt == LiteralType.Unknown)
                    return Type.UnknownType;
                else
                    throw new NotSupportedException("Unknown literal type!");
            }
            else if (asttype is NamedTypeLiteral ntl)
            {
                var sym = scope.FindNamedSymbol(ntl.Name, Type.MetaType, true);
                if (sym != null)
                    return sym.GetValue<Type>();
                else
                    return null;
            }
            else if (asttype is EnumTypeLiteral etl)
            {
                return new EnumType(etl.Items);
            }
            else if (asttype is ArrayTypeLiteral atl)
            {
                var type = new ArrayType
                {
                    Dimensions = atl.Dimensions
                };
                unit.AddTask(() =>
                {
                    type.ElementType = ConvertType(unit, scope, atl.ElementType);
                    if (type.ElementType == null)
                        return Error.UnresolvableType(atl.ElementType);
                    return CompilerError.None;
                });
                return type;
            }
            else if (asttype is RecordTypeLiteral rtl)
            {
                var type = new RecordType();
                type.Members = new List<RecordMember>();
                foreach (var m in rtl.Fields)
                {
                    var mem = new RecordMember(type, m.Name);
                    unit.AddTask(() =>
                    {
                        var ftype = ConvertType(unit, scope, m.Type);
                        if (ftype == null)
                            return Error.UnresolvableType(m.Type);
                        var member = new RecordMember(type, m.Name)
                        {
                            Type = ftype,
                        };
                        return Error.None;
                    });
                    if (m.Value != null)
                    {
                        unit.AddTask(() =>
                        {
                            mem.Initializer = ConvertExpression(unit, scope, m.Value).Single();
                            if (mem.Initializer == null)
                                return Error.InvalidExpression(m.Value);
                            return Error.None;
                        });
                    }
                    type.Members.Add(mem);
                }
                return type;
            }
            else if (asttype is ReferenceTypeLiteral rftl)
            {
                var type = new ReferenceType();
                unit.AddTask(() =>
                {
                    type.ObjectType = ConvertType(unit, scope, rftl.ObjectType);
                    if (type.ObjectType == null)
                        return Error.UnresolvableType(rftl.ObjectType);
                    return CompilerError.None;
                });
                return type;
            }
            else if (asttype is FunctionTypeLiteral ftl)
            {
                var type = new FunctionType();
                unit.AddTask(() =>
                {
                    type.ReturnType = ConvertType(unit, scope, ftl.ReturnType);
                    if (type.ReturnType == null)
                        return Error.UnresolvableType(ftl.ReturnType);
                    return CompilerError.None;
                });
                var @params = new Parameter[ftl.Parameters.Count];
                for (int i = 0; i < ftl.Parameters.Count; i++)
                {
                    var par = ftl.Parameters[i];
                    var p = new Parameter(type, par.Name, i)
                    {
                        Flags = par.Prefix,
                    };
                    // Set "in" as default if neither in nor out is given
                    if (!p.Flags.HasFlag(ParameterFlags.In) && !p.Flags.HasFlag(ParameterFlags.Out))
                        p.Flags |= ParameterFlags.In;
                    if (par.Type != null)
                    {
                        unit.AddTask(() =>
                        {
                            p.Type = ConvertType(unit, scope, par.Type);
                            if (p.Type == null)
                                return Error.UnresolvableType(par.Type);
                            return CompilerError.None;
                        });
                    }
                    if (par.Value != null)
                    {
                        unit.AddTask(() =>
                        {
                            p.Initializer = ConvertExpression(unit, scope, par.Value).Single();
                            if (p.Initializer == null)
                                return Error.InvalidExpression(par.Value);
                            return CompilerError.None;
                        });
                    }
                    @params[i] = p;
                }

                type.Parameters = @params;

                return type;
            }
            else
            {
                throw new NotSupportedException($"{asttype.GetType().Name} is not supported yet!");
            }
        }

        /// <summary>
        /// Converts the given abstract expression into a list of possible AST expressions.
        /// Throws an exception if the translation was not possible because of unfinished symbols
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="scope"></param>
        /// <param name="value"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private IReadOnlyList<Expression> ConvertExpression(TranslationUnit unit, IScope scope, Grammar.Expression value, ExpressionContext context = null)
        {
            if (value is NumberLiteral num)
            {
                var literals = new List<Expression>();

                // try hex first, then decimal
                if (ulong.TryParse(num.Value, NumberStyles.HexNumber, SystemFormat, out ulong u))
                    literals.Add(new Literal<ulong>(u));
                else if (ulong.TryParse(num.Value, NumberStyles.Integer, SystemFormat, out u))
                    literals.Add(new Literal<ulong>(u));

                // try hex first, then decimal
                if (long.TryParse(num.Value, NumberStyles.HexNumber, SystemFormat, out long i))
                    literals.Add(new Literal<long>(i));
                else if (long.TryParse(num.Value, NumberStyles.Integer, SystemFormat, out i))
                    literals.Add(new Literal<long>(i));

                // also try double separated
                if (double.TryParse(num.Value, NumberStyles.Number, SystemFormat, out double dbl))
                    literals.Add(new Literal<double>(dbl));

                return literals.ToArray();
            }
            else if (value is StringLiteral str)
            {
                return new[] { new Literal<string>(str.Text) };
            }
            else if (value is CharacterLiteral chr)
            {
                return new[] { new Literal<int>(chr.Codepoint) };
            }
            else if (value is ArrayLiteral array)
            {
                var expr = new ArrayExpression();
                expr.Items = new Expression[array.Values.Count];
                for (int i = 0; i < expr.Items.Length; i++)
                {
                    int idx = i;
                    var elem = ConvertExpression(unit, scope, array.Values[idx]);
                    if (elem == null)
                    {
                        Error.InvalidExpression(value);
                        return null;
                    }
                    expr.Items[idx] = elem.Single();
                }

                if (expr.Items.Any(i => i is null))
                    throw Error.Critical("Not all array elements could be translated!");

                var type = FindCommonType(expr.Items.Select(i => i.Type));
                if (type == null)
                    throw Error.NoCommmonType();

                expr.ItemType = type;

                return new[] { expr };
            }
            else if (value is Grammar.FunctionLiteral function)
            {
                var type = ConvertType(unit, scope, function.Type) as FunctionType;
                if (type == null)
                    throw Error.UnresolvableType(function.Type);

                var fun = new UserFunction(type);

                var paramscope = new SimpleScope();
                foreach (var param in type.Parameters)
                {
                    paramscope.Add(new Symbol(param.Type, param.Name)
                    {
                        Kind = SymbolKind.Parameter
                    });
                }

                fun.Scope.Push(scope);
                fun.Scope.Push(paramscope);

                var ctx = new BlockContext
                {
                    EnclosingType = type
                };

                // IMPORTANT:
                // Use task system here as a function literal body is independent from its type
                // and can be translated completly separated from the rest of the expression
                unit.AddTask(() =>
                {
                    var body = ConvertStatement(unit, fun.Scope, function.Body, ctx);
                    if (body == null)
                        return Error.UntranslatableStatement(function.Body);
                    fun.Body = body;
                    return Error.None;
                });

                unit.Module.Functions.Add(fun);

                return new[] { new FunctionLiteral(fun) };
            }
            else if (value is VariableReference vref)
            {
                var syms = scope.Where(s => s.Name.ID == vref.Variable).ToArray();
                if (syms.Length == 0)
                    throw Error.SymbolNotFound(vref.Variable);
                return syms.Select(s => new SymbolReference(s)).ToArray();
            }
            else if (value is UnaryOperation unop)
            {
                var val = ConvertExpression(unit, scope, unop.Operand);
                if (val == null)
                    throw Error.InvalidExpression(unop.Operand);

                var results = new List<FunctionCall>();
                foreach (var item in val)
                {
                    var type = FunctionType.CreateUnaryOperator(Type.UnknownType, item.Type);

                    var sig = new Signature(type, unop.Operator);
                    if (scope.HasSymbol(sig) == false)
                        continue;
                    
                    results.Add(new FunctionCall(new SymbolReference(scope[sig]), new[] { item }));
                }
                if (results.Count == 0)
                    throw Error.UnknownOperator(unop);
                return results;
            }
            else if (value is BinaryOperation binop)
            {
                var lhslist = ConvertExpression(unit, scope, binop.LeftHandSide);
                var rhslist = ConvertExpression(unit, scope, binop.RightHandSide);

                var results = new List<FunctionCall>();

                foreach (var lhs in lhslist)
                {
                    foreach (var rhs in rhslist)
                    {
                        var type = FunctionType.CreateBinaryOperator(
                            returnType: Type.UnknownType,
                            leftType: lhs.Type,
                            rightType: rhs.Type);

                        var sig = new Signature(type, binop.Operator);

                        if (scope.HasSymbol(sig) == false)
                            continue;
                        
                        results.Add(new FunctionCall(new SymbolReference(scope[sig]), new[] { lhs, rhs }));
                    }
                }
                if (results.Count == 0)
                    Error.UnknownOperator(binop);
                return results;
            }
            else if (value is FunctionCallExpression fncall)
            {
                var results = new List<FunctionCall>();
                var functions = ConvertExpression(unit, scope, fncall.Value);
                foreach (var func in functions)
                {
                    var type = func.Type as FunctionType;
                    if (type == null)
                        continue;

                    var call = new FunctionCall();
                    call.Functor = func;

                    var arglist = new Expression[type.Parameters.Length];
                    var paramset = new HashSet<Parameter>(type.Parameters);

                    foreach (var arg in fncall.PositionalArguments)
                    {
                        var param = paramset.SingleOrDefault(p => p.Position == arg.Position);
                        if (param == null)
                            continue;

                        arglist[param.Position] = SelectFitting(
                            ConvertExpression(unit, scope, arg.Value),
                            param.Type);
                        if (arglist[param.Position] == null)
                            continue;

                        paramset.Remove(param);
                    }

                    foreach (var arg in fncall.NamedArguments)
                    {
                        var param = paramset.SingleOrDefault(p => p.Name == arg.Name);
                        if (param == null)
                            continue;

                        arglist[param.Position] = ConvertExpression(unit, scope, arg.Value).Single();
                        if (arglist[param.Position] == null)
                            continue;

                        paramset.Remove(param);
                    }

                    if (paramset.Count > 0)
                        continue;

                    call.Arguments = arglist;
                    results.Add(call);
                }
                if (results.Count == 0)
                    throw Error.Critical($"Unknown function {fncall.Value} with fitting argument list.");

                return results;
            }
            else
            {
                throw new NotSupportedException($"The expression type '{value?.GetType()?.Name ?? "?"}' is not supported yet.");
            }
        }

        private Statement ConvertStatement(TranslationUnit unit, IScope scope, Grammar.Statement stmt, BlockContext context)
        {
            if (stmt is Grammar.Block block)
            {
                var result = new Block();
                unit.AddTask(() =>
                {
                    var sequence = new List<Statement>();
                    var blockscope = scope;
                    foreach (var sub in block)
                    {
                        if (sub is Declaration decl)
                        {
                            // TODO: Allow CreateSymbol initializer to access the self-defined symbol
                            var err = CreateSymbol(unit, blockscope, decl, out var sym);
                            if (err != CompilerError.None)
                                return err;
                            sym.Kind = SymbolKind.Local;
                            blockscope = new ExtendingScope(blockscope, sym);
                            if (decl.Value != null)
                            {
                                var init = new ExpressionStatement();
                                unit.AddTask(() =>
                                {
                                    if (sym.Initializer == null)
                                        return Error.InvalidExpression(decl.Value);
                                    init.Expression = sym.Initializer;
                                    return Error.None;
                                });
                                sequence.Add(init);
                            }
                        }
                        else
                        {
                            var substmt = ConvertStatement(unit, blockscope, sub, context);
                            if (substmt == null)
                                return Error.UntranslatableStatement(sub);
                            sequence.Add(substmt);
                        }
                    }
                    result.Statements = sequence;
                    return Error.None;
                });
                return result;
            }
            else if (stmt is Grammar.ExpressionStatement expr)
            {
                var exec = new ExpressionStatement();
                unit.AddTask(() =>
                {
                    var list = ConvertExpression(unit, scope, expr.Expression);
                    if (list == null)
                        return Error.InvalidExpression(expr.Expression);
                    if (list.Count > 1)
                        return Error.AmbiguousExpression(expr.Expression, list);
                    exec.Expression = list.Single();
                    if (exec.Expression == null)
                        return Error.InvalidExpression(expr.Expression);
                    return Error.None;
                });
                return exec;
            }
            else if (stmt is Grammar.FlowBreakStatement flow)
            {
                switch (flow.Type)
                {
                    case FlowBreakType.Return:
                        {
                            var @return = new ReturnStatement();
                            if (flow.Value != null)
                            {
                                unit.AddTask(() =>
                                {
                                    var options = ConvertExpression(unit, scope, flow.Value);
                                    @return.Result = SelectFitting(options, context.EnclosingType.ReturnType);
                                    if (@return.Result == null)
                                        return Error.InvalidExpression(flow.Value);
                                    return Error.None;
                                });
                            }
                            return @return;
                        }
                    default:
                        throw new NotSupportedException($"{flow.Type} is not supported yet.");
                }
            }
            else if (stmt is WhileLoopStatement loop)
            {
                var s = new WhileLoop();
                unit.AddTask(() =>
                {
                    s.Condition = ConvertExpression(unit, scope, loop.Condition).Single();
                    if (s.Condition == null)
                        return Error.InvalidExpression(loop.Condition);
                    return Error.None;
                });
                unit.AddTask(() =>
                {
                    s.Body = ConvertStatement(unit, scope, loop.Body, context);
                    if (s.Body == null)
                        return Error.UntranslatableStatement(loop.Body);
                    return Error.None;
                });
                return s;
            }
            else
            {
                throw new NotSupportedException($"The statement type {stmt?.GetType()?.Name ?? "?"} is not supported yet.");
            }
        }

        private Expression SelectFitting(IReadOnlyCollection<Expression> options, Type returnType)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (returnType == null)
                throw new ArgumentNullException(nameof(returnType));
            if (options.Count == 0)
                return null;
            return options.FirstOrDefault(e => (e.Type == returnType))
                ?? options.FirstOrDefault(e => (e.Type.IsCompatibleTo(returnType)));
        }

        private Type FindCommonType(IEnumerable<Type> enumerable)
        {
            var list = enumerable.ToArray();
            if (list.Length == 0)
                return Type.UnknownType;
            if (list.All(l => (l.Equals(list[0]))))
                return list[0];

            Error.Add("Common type could not be found!");

            return null;
        }

        private class TranslationUnit
        {
            public delegate CompilerError CompilationTask();

            public TranslationUnit(Grammar.Module input, Module output)
            {
                this.Source = input ?? throw new ArgumentNullException(nameof(input));
                this.Module = output ?? throw new ArgumentNullException(nameof(output));
            }

            public bool AddTask(CompilationTask task)
            {
                try
                {
                    var error = task();
                    if (error != null)
                        this.Tasks.Enqueue(task);
                    return (error == null);
                }
                catch (Exception)
                {
                    this.Tasks.Enqueue(task);
                    return false;
                }
            }

            public Grammar.Module Source { get; }

            public Module Module { get; }

            public bool IsComplete => (IsCompletlyPrepared && (Tasks.Count == 0));

            public bool IsCompletlyPrepared { get;  set; }

            public Queue<CompilationTask> Tasks { get; } = new Queue<CompilationTask>();

            /// <summary>
            /// The basic scope for this translation unit.
            /// Contains at least the following options (bottom to top)
            /// 1. global scope (all libraries and stuff)
            /// 2. import scope (TranslateUnit.Imports)
            /// 3. the target module
            /// </summary>
            public StackableScope Scope { get; } = new StackableScope();

            /// <summary>
            /// The second stage of the units scope. Contains all import statements in order.
            /// </summary>
            public StackableScope Imports { get; } = new StackableScope();

            public override string ToString() => $"Unit({Module.Name})";
        }
    }
}

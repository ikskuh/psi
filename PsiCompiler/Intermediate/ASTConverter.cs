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

        public ASTConverter(IScope globalScope)
        {
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

            var tu = new TranslationUnit(module, target)
            {
                IsComplete = false
            };

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

            // Step 2: Run tasks until all tasks are done:
            while (this.units.Sum(u => u.Tasks.Count) > 0)
            {
                var anySuccess = false;
                var errors = new List<CompilerError>();
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
                            if (error != null)
                            {
                                errors.Add(error);
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
        }

        private void CreateVariables(TranslationUnit unit)
        {
            foreach (var def in unit.Source.Declarations)
            {
                unit.AddTask(() =>
                {
                    Type type;
                    if (def.Type != null)
                        type = ConvertType(unit, unit.Scope, def.Type);
                    else
                        type = Type.UnknownType;

                    if (type == null)
                        return new CompilerError($"could not resolve {def.Type}");

                    Expression initializer = null;
                    if (def.Value != null)
                    {
                        // TODO: A type hint should be passed into convert expression here
                        initializer = ConvertExpression(unit, unit.Scope, def.Value);
                        if (initializer == null)
                            return new CompilerError($"could not compile {def.Value}");
                    }

                    if ((type == Type.UnknownType) && (initializer == null))
                        return new CompilerError("Symbol does neither have a type nor an initializer");

                    if ((type == Type.UnknownType) && (initializer != null))
                    {
                        type = initializer.Type;
                        if ((type == null) || (type == Type.UnknownType))
                            return new CompilerError("Could not deduce type of symbol");
                    }

                    if ((initializer != null) && (type != initializer.Type))
                        return new CompilerError("Value does not mach declared type");

                    if ((type == null) || (type == Type.UnknownType))
                        return new CompilerError("Invalid symbol: No type has been detected");

                    var sym = new Symbol(type, def.Name)
                    {
                        IsConst = def.IsConst,
                        IsExported = def.IsExported,
                        Initializer = initializer,
                    };

                    unit.Module.Symbols.Add(sym);

                    return CompilerError.None;
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
                        return new CompilerError($"Could not find import module '{name}'");
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
                        return new CompilerError($"{decl.Type} is not resolvable!");
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
                        return new CompilerError($"Could not resolve '{atl.ElementType}'");
                    return CompilerError.None;
                });
                return type;
            }
            else if (asttype is RecordTypeLiteral rtl)
            {
                var type = new RecordType();
                unit.AddTask(() =>
                {
                    var members = new List<RecordMember>();
                    var map = new Dictionary<RecordMember, Declaration>();
                    foreach (var m in rtl.Fields)
                    {
                        var ftype = ConvertType(unit, scope, m.Type);
                        if (ftype == null)
                            return new CompilerError($"Could not resolve type for record field {m.Name}.");
                        var member = new RecordMember(type, m.Name)
                        {
                            Type = ftype,
                        };
                        map[member] = m;
                        members.Add(member);
                    }
                    if (type.Members != null)
                        throw new InvalidOperationException("record type was somehow already translated?!");
                    type.Members = members;
                    foreach (var member in type.Members)
                    {
                        var m = map[member];
                        if (m.Value == null)
                            continue;
                        unit.AddTask(() =>
                        {
                            member.Initializer = ConvertExpression(unit, scope, m.Value);
                            if (member.Initializer != null)
                                return CompilerError.None;
                            else
                                return new CompilerError($"Failed to convert initializer for {member.Name}");
                        });
                    }
                    return CompilerError.None;
                });
                return type;
            }
            else if (asttype is ReferenceTypeLiteral rftl)
            {
                var type = new ReferenceType();
                unit.AddTask(() =>
                {
                    type.ObjectType = ConvertType(unit, scope, rftl.ObjectType);
                    if (type.ObjectType == null)
                        return new CompilerError($"Could not find type '{rftl.ObjectType}'");
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
                        return new CompilerError($"Could not resolve type '{type.ReturnType}'");
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
                                return new CompilerError($"Could not resolve type '{par.Value}'");
                            return CompilerError.None;
                        });
                    }
                    if (par.Value != null)
                    {
                        unit.AddTask(() =>
                        {
                            p.Initializer = ConvertExpression(unit, scope, par.Value);
                            if (p.Initializer == null)
                                return new CompilerError($"Could not translate expression '{par.Value}'");
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


        private Expression ConvertExpression(TranslationUnit unit, IScope scope, Grammar.Expression value)
        {
            if (value is NumberLiteral num)
            {
                if (double.TryParse(num.Value, NumberStyles.Number, SystemFormat, out double dbl))
                    return new Literal<double>(dbl);
                else if (int.TryParse(num.Value, NumberStyles.HexNumber, SystemFormat, out int i))
                    return new Literal<int>(i);
                else if (int.TryParse(num.Value, NumberStyles.Integer, SystemFormat, out i))
                    return new Literal<int>(i);
                else
                    return null;
            }
            else if (value is StringLiteral str)
            {
                return new Literal<string>(str.Text);
            }
            else
            {
                throw new NotSupportedException($"The expression type '{value?.GetType()?.Name ?? "?"}' is not supported yet.");
            }
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
                catch(Exception)
                {
                    this.Tasks.Enqueue(task);
                    return false;
                }
            }

            public Grammar.Module Source { get; }

            public Module Module { get; }

            public bool IsComplete { get; set; }

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

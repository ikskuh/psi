using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psi.Compiler.Grammar;

namespace Psi.Compiler.Intermediate
{
    public class ASTConverter
    {
        private readonly List<TranslationUnit> units = new List<TranslationUnit>();

        public IScope GlobalScope { get; }

        public ASTConverter(IScope globalScope)
        {
            this.GlobalScope = globalScope ?? throw new ArgumentNullException(nameof(globalScope));
        }

        #region Module Management

        public void AddModule(Grammar.Module module) => this.AddModule(module, null);

        private Module AddModule(Grammar.Module module, Module parent)
        {
            // TODO: Fix parent/child relation of modules with complex compound name

            if (module.Name.Count > 1)
                throw new NotSupportedException("Compound module names not supported yet.");

            if (module == null)
                throw new ArgumentNullException(nameof(module));

            if (units.Any(u => u.Source == module))
                throw new InvalidOperationException("Cannot add the same module twice!");

            var name = (parent != null ? parent.Name + "." : "") + module.Name;

            Module output;
            if (units.Any(m => m.Module.Name == name))
            {
                // already known module, use same output
                output = units.Single(m => (m.Module.Name == name)).Module;
            }
            else
            {
                // module not known, use new output
                output = new Module(parent, name);
            }
            var tu = new TranslationUnit(module, output)
            {
                IsComplete = false
            };

            // Initialize the base scope of the translation unit
            tu.Scope.Push(this.GlobalScope);
            tu.Scope.Push(tu.Imports);
            tu.Scope.Push(tu.Module.Symbols);

            this.units.Add(tu);

            foreach (var sm in module.Submodules)
            {
                output.Symbols.Add(new Symbol(IntermediateType.ModuleType, sm.Name.Identifier)
                {
                    Initializer = new Literal<Module>(this.AddModule(sm, output)),
                    IsConst = true,
                    IsExported = true
                });
            }

            return output;
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
            foreach (var unit in this.units)
                this.CreateTypeSymbols(unit);

            foreach (var unit in this.units)
                this.ImportSymbolsIntoUnit(unit);

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
        }

        private void ImportSymbolsIntoUnit(TranslationUnit unit)
        {
            foreach (var name in unit.Source.Imports)
            {
                unit.AddTask(() =>
                {
                    var sym = GlobalScope.FindNamedSymbol(name, IntermediateType.ModuleType, true);
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
                    IntermediateType type = ConvertType(unit, unit.Scope, decl.Type);
                    if (type == null)
                        return new CompilerError($"{decl.Type} is not resolvable!");
                    if (type == IntermediateType.UnknownType)
                        throw new InvalidOperationException("Unknown type not allows in declaration");
                    if (type == IntermediateType.VoidType)
                        throw new InvalidOperationException("Void type may not be aliased!");
                    unit.Module.Symbols.Add(new Symbol(IntermediateType.MetaType, decl.Name)
                    {
                        IsConst = true,
                        IsExported = decl.IsExported,
                        Initializer = new Literal<IntermediateType>(type),
                    });
                    return CompilerError.None;
                });
            }
        }

        private static IntermediateType ConvertType(TranslationUnit unit, IScope scope, AstType asttype)
        {
            if (asttype is LiteralType lt)
            {
                if (lt == LiteralType.Void)
                    return IntermediateType.VoidType;
                else if (lt == LiteralType.Unknown)
                    return IntermediateType.UnknownType;
                else
                    throw new NotSupportedException("Unknown literal type!");
            }
            else if (asttype is NamedTypeLiteral ntl)
            {
                var sym = scope.FindNamedSymbol(ntl.Name, IntermediateType.MetaType, true);
                if (sym != null)
                    return sym.GetValue<IntermediateType>();
                else
                    return null;
            }
            else if (asttype is EnumTypeLiteral etl)
            {
                return new EnumType(etl.Items);
            }
            else if (asttype is ArrayTypeLiteral atl)
            {
                var type = new ArrayType();
                type.Dimensions = atl.Dimensions;
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
            else
            {
                throw new NotSupportedException($"{asttype.GetType().Name} is not supported yet!");
            }
        }


        private static Expression ConvertExpression(TranslationUnit unit, IScope scope, Grammar.Expression value)
        {
            throw new NotImplementedException();
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
                var error = task();
                if (error != null)
                    this.Tasks.Enqueue(task);
                return (error == null);
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

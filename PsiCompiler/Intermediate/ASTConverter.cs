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

        public ASTConverter()
        {

        }

        #region Module Management

        public void AddModule(Grammar.Module module) => this.AddModule(module, "");

        private void AddModule(Grammar.Module module, string @namespace)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));
            if (@namespace == null)
                throw new ArgumentNullException(nameof(@namespace));

            if (units.Any(u => u.Source == module))
                throw new InvalidOperationException("Cannot add the same module twice!");

            var name = string.Join(
                ".",
                @namespace
                    .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                    .Concat(module.Name));

            Module output;
            if (units.Any(m => m.Module.Name == name))
            {
                // already known module, use same output
                output = units.Single(m => (m.Module.Name == name)).Module;
            }
            else
            {
                // module not known, use new output
                output = new Module(name);
            }
            var tu = new TranslationUnit(module, output)
            {
                IsComplete = false
            };
            this.units.Add(tu);

            foreach (var sm in module.Submodules)
                this.AddModule(sm, name);
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
            foreach (var unit in this.units)
                this.CreateTypeSymbols(unit);
        }

        private void CreateTypeSymbols(TranslationUnit unit)
        {
            var dst = unit.Module;
            foreach (var decl in unit.Source.TypeDeclarations)
            {
                IntermediateType type;
                if (decl.Type is LiteralType lt)
                {
                    if (lt == LiteralType.Void)
                        type = IntermediateType.VoidType;
                    else if (lt == LiteralType.Unknown)
                        type = IntermediateType.UnknownType;
                    else
                        throw new NotSupportedException("Unknown literal type!");
                }
                else if(decl.Type is NamedTypeLiteral ntl)
                {
                    throw new NotSupportedException();
                }
                else if (decl.Type is EnumTypeLiteral etl)
                {
                    type = new EnumType(etl.Items);
                }
                else if (decl.Type is RecordTypeLiteral rtl)
                {
                    throw new NotSupportedException();
                }
                else
                {
                    throw new NotSupportedException($"{decl.Type.GetType().Name} is not supported yet!");
                }
                unit.Module.Symbols.Add(new Symbol(IntermediateType.MetaType, decl.Name)
                {
                    IsConst = true,
                    IsExported = decl.IsExported,
                    Initializer = new TypeLiteral(type),
                });
            }
        }


        private class TranslationUnit
        {
            public delegate bool CompilationTask();

            public TranslationUnit(Grammar.Module input, Module output)
            {
                this.Source = input ?? throw new ArgumentNullException(nameof(input));
                this.Module = output ?? throw new ArgumentNullException(nameof(output));
            }
            
            public Grammar.Module Source { get; }

            public Module Module { get; }

            public bool IsComplete { get; set; }

            public Queue<CompilationTask> Tasks { get; } = new Queue<CompilationTask>();

            public override string ToString() => $"Unit({Module.Name})";
        }
    }
}

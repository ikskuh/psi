using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLiteral = Psi.Compiler.Intermediate.Literal<Psi.Compiler.Intermediate.IntermediateType>;
using ModuleLiteral = Psi.Compiler.Intermediate.Literal<Psi.Compiler.Intermediate.Module>;

namespace Psi.Compiler.Intermediate
{
    [Serializable]
    public class Module
    {
        private readonly SymbolCollection symbols = new SymbolCollection();

        public Module(Module parent, string fullName)
        {
            this.Parent = parent;
            this.Name = fullName ?? throw new ArgumentNullException(nameof(fullName));
            this.LocalName = this.Name.Split('.').Last();
        }

        public SymbolCollection Symbols => this.symbols;

        public IReadOnlyDictionary<string, Module> Submodules => this.symbols
            .Where<Symbol>(s => s.IsConst)
            .Where(s => s.Initializer is ModuleLiteral)
            .Where(s => s.Type == IntermediateType.ModuleType)
            .ToDictionary(s => s.Name.ID, s => (s.Initializer as ModuleLiteral).Value);

        public IReadOnlyDictionary<string, IntermediateType> Types => this.symbols
            .Where<Symbol>(s => s.IsConst)
            .Where(s => s.Initializer is TypeLiteral)
            .Where(s => s.Type == IntermediateType.MetaType)
            .ToDictionary(s => s.Name.ID, s => (s.Initializer as TypeLiteral).Value);

        public IReadOnlyDictionary<string, IntermediateType> ExportedTypes => this.symbols
            .Where<Symbol>(s => s.IsConst)
            .Where(s => s.IsExported)
            .Where(s => s.Initializer is TypeLiteral)
            .Where(s => s.Type == IntermediateType.MetaType)
            .ToDictionary(s => s.Name.ID, s => (s.Initializer as TypeLiteral).Value);

        public Module Parent { get; }
        public string Name { get; }

        public string LocalName { get; }
    }
}

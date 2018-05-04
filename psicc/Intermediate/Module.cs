using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeLiteral = Psi.Compiler.Intermediate.Literal<Psi.Compiler.Intermediate.Type>;
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

        public Symbol AddType(string name, Type type, bool isExported)
        {
            var sym = new Symbol(Type.MetaType, name)
            {
                Initializer = new Literal<Type>(type),
                IsConst = true,
                IsExported = isExported,
            };
            this.Symbols.Add(sym);
            return sym;
        }

        public Symbol AddModule(string name, Module submodule)
        {
            var sym = new Symbol(Type.ModuleType, name)
            {
                Initializer = new Literal<Module>(submodule),
                IsConst = true,
                IsExported = true,
            };
            this.Symbols.Add(sym);
            return sym;
        }
        
        public Symbol AddConst(string name, Type type, Expression value, bool isExported)
        {
            var sym = new Symbol(type, name)
            {
                Initializer = value ?? throw new ArgumentNullException(nameof(value)),
                IsConst = true,
                IsExported = isExported,
            };
            this.Symbols.Add(sym);
            return sym;
        }

        public SymbolCollection Symbols => this.symbols;

        public IReadOnlyDictionary<string, Module> Submodules => this.symbols
            .Where<Symbol>(s => s.IsConst)
            .Where(s => s.Initializer is ModuleLiteral)
            .Where(s => s.Type == Type.ModuleType)
            .ToDictionary(s => s.Name.ID, s => (s.Initializer as ModuleLiteral).Value);

        public IReadOnlyDictionary<string, Type> Types => this.symbols
            .Where<Symbol>(s => s.IsConst)
            .Where(s => s.Initializer is TypeLiteral)
            .Where(s => s.Type == Type.MetaType)
            .ToDictionary(s => s.Name.ID, s => (s.Initializer as TypeLiteral).Value);

        public IReadOnlyDictionary<string, Type> ExportedTypes => this.symbols
            .Where<Symbol>(s => s.IsConst)
            .Where(s => s.IsExported)
            .Where(s => s.Initializer is TypeLiteral)
            .Where(s => s.Type == Type.MetaType)
            .ToDictionary(s => s.Name.ID, s => (s.Initializer as TypeLiteral).Value);

        public ICollection<UserFunction> Functions { get; } = new HashSet<UserFunction>();

        public Module Parent { get; }

        public string Name { get; }

        public string LocalName { get; }

        public override string ToString() => $"module:{Name}";
    }
}

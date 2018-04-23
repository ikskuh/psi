using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psi.Compiler.Intermediate
{
    [Serializable]
    public class Module
    {
        private readonly SymbolCollection symbols = new SymbolCollection();

        public Module(string fullName)
        {
            this.Name = fullName ?? throw new ArgumentNullException(nameof(fullName));
            this.LocalName = this.Name.Split('.').Last();
        }

        public SymbolCollection Symbols => this.symbols;

        public IReadOnlyDictionary<string, IntermediateType> Types => this.symbols
            .Where(s => s.Value.IsConst)
            .Where(s => s.Value.Initializer is TypeLiteral)
            .Where(s => s.Key.Type == IntermediateType.MetaType)
            .ToDictionary(s => s.Key.ID, s => (s.Value.Initializer as TypeLiteral).Type);

        public IReadOnlyDictionary<string, IntermediateType> ExportedTypes => this.symbols
            .Where(s => s.Value.IsConst)
            .Where(s => s.Value.IsExported)
            .Where(s => s.Value.Initializer is TypeLiteral)
            .Where(s => s.Key.Type == IntermediateType.MetaType)
            .ToDictionary(s => s.Key.ID, s => (s.Value.Initializer as TypeLiteral).Type);

        public string Name { get; }

        public string LocalName { get; }
    }
}

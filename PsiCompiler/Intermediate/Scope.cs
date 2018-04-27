using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Psi.Compiler.Intermediate
{
    public interface IScope : IEnumerable<Symbol>
    {
        bool HasSymbol(Signature name);

        Symbol this[Signature name] { get; }
    }

    public sealed class SimpleScope : IScope, ICloneable
    {
        private readonly Dictionary<Signature, Symbol> symbols;

        public SimpleScope()
        {
            this.symbols = new Dictionary<Signature, Symbol>();
        }

        private SimpleScope(SimpleScope other)
        {
            this.symbols = new Dictionary<Signature, Symbol>(other.symbols);
        }

        public void Add(Symbol sym) => this.symbols.Add(sym.Name, sym);

        public SimpleScope Clone() => new SimpleScope(this);

        public Symbol this[Signature name] => this.symbols.ContainsKey(name) ? this.symbols[name] : null;

        public IEnumerator<Symbol> GetEnumerator() => this.symbols.Values.GetEnumerator();

        public bool HasSymbol(Signature name) => this.symbols.ContainsKey(name);

        object ICloneable.Clone() => this.Clone();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public sealed class StackableScope : IScope, ICloneable
    {
        private readonly Stack<IScope> scopes;

        public StackableScope()
        {
            this.scopes = new Stack<IScope>();
        }

        private StackableScope(IEnumerable<IScope> contents)
        {
            this.scopes = new Stack<IScope>(contents);
        }

        public Symbol this[Signature name]
        {
            get
            {
                var a = scopes.ToArray(); // array is last-to-first/top-to-bottom order
                for (int i = 0; i < scopes.Count; i++)
                {
                    if (a[i].HasSymbol(name))
                        return a[i][name];
                }
                return null;
            }
        }

        public void Push(IScope scope)
        {
            this.scopes.Push(scope ?? throw new ArgumentNullException(nameof(scope)));
        }

        public void Pop()
        {
            this.scopes.Pop();
        }

        public bool HasSymbol(Signature name) => this.scopes.Any(s => s.HasSymbol(name));

        private IEnumerable<Symbol> EnumerateSymbols()
        {
            var exclusion = new HashSet<Signature>();
            foreach(var group in this.scopes)
            {
                foreach(var item in group)
                {
                    if (exclusion.Contains(item.Name))
                        continue;
                    yield return item;
                    exclusion.Add(item.Name);
                }
            }
        }

        public IEnumerator<Symbol> GetEnumerator() => this.EnumerateSymbols().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        object ICloneable.Clone() => this.Clone();

        // this is kinda stupid... pushing a stack into a stack initialize reverses order
        // so we reverse it back, so stack ctor will un-reverse it again
        public StackableScope Clone() => new StackableScope(this.scopes.Reverse()); 
    }

    public sealed class ExtendingScope : IScope
    {
        private readonly IScope scope;
        private readonly Symbol symbol;

        public ExtendingScope(IScope scope, Symbol sym)
        {
            this.scope = scope ?? throw new ArgumentNullException(nameof(scope));
            this.symbol = sym ?? throw new ArgumentNullException(nameof(sym));
        }

        public Symbol this[Signature name] => (name == symbol.Name) ? symbol : scope[name];

        public IEnumerator<Symbol> GetEnumerator()
        {
            var list = new Symbol[] { this.symbol };
            return list.Concat(this.scope.Except(list)).GetEnumerator();
        }

        public bool HasSymbol(Signature name) => (name == symbol.Name) ? true : scope.HasSymbol(name);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
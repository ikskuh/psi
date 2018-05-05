using System;
using System.Collections;
using System.Collections.Generic;
using Psi.Compiler.Intermediate;

namespace Psi.Compiler.Intermediate
{
    internal class AutoGlobalScope : IScope
    {
        private readonly Dictionary<Signature, Symbol> values = new Dictionary<Signature, Symbol>();

        public Symbol this[Signature name]
        {
            get
            {
                if (!this.values.ContainsKey(name))
                    GenerateSymbolForName(name);

                if (this.values.ContainsKey(name))
                    return this.values[name];
                else
                    return null;
            }
        }

        public IEnumerator<Symbol> GetEnumerator() => new List<Symbol>().GetEnumerator();

        public bool HasSymbol(Signature name) => CanGeneratorSymbol(name);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private bool CanGeneratorSymbol(Signature name)
        {
            if (name.TypeSignature is FunctionSignature funsig)
            {
                if (funsig.Parameters.Count == 2)
                {
                    switch (name.ID)
                    {
                        case "operator '='":
                            return object.Equals(funsig.Parameters[0].Type, funsig.Parameters[1].Type);
                        default:
                            return false;
                    }
                }
            }
            return false;
        }

        private void GenerateSymbolForName(Signature name)
        {
            Symbol sym;
            switch (name.ID)
            {
                case "operator '='":
                    {
                        var sig = name.TypeSignature as FunctionSignature;
                        var typ = new FunctionType();
                        typ.ReturnType = sig.Parameters[0].Type;
                        typ.Parameters = new Parameter[]
                        {
                            new Parameter(typ, "dst", 0)
                            {
                                Flags = ParameterFlags.Out,
                                Type = sig.Parameters[0].Type,
                                Initializer = null
                            },
                            new Parameter(typ, "src", 1)
                            {
                                Flags = ParameterFlags.Out,
                                Type = sig.Parameters[1].Type,
                                Initializer = null
                            }
                        };

                        sym = new Symbol(typ, PsiOperator.CopyAssign)
                        {
                            Initializer = new FunctionLiteral(new BuiltinFunction(typ)),
                            IsConst = true,
                            IsExported = false,
                            Kind = SymbolKind.Builtin,
                        };
                    }
                    break;
                default:
                    throw new NotSupportedException($"Generation of {name} is not supported yet.");
            }
            if (sym.Name.Equals(name) == false)
                throw new InvalidOperationException("Failed to create fitting symbol!");
            this.values.Add(sym.Name, sym);
        }
    }
}
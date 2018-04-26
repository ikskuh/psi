using System;
using System.Collections;
using System.Collections.Generic;
using Psi.Compiler.Grammar;

namespace Psi.Compiler.Intermediate
{
    public sealed class CompilerErrorCollection : ICollection<CompilerError>
    {
        private List<CompilerError> contents = new List<CompilerError>();
        public CompilerError None => CompilerError.None; 

        public CompilerErrorCollection()
        {

        }

        public CompilerError Add(string text, params object[] format) => Add(string.Format(text, format));

        public CompilerError Add(string text) => Add(new CompilerError(text));

        public CompilerError Add(CompilerError err)
        {
            this.contents.Add(err ?? throw new ArgumentNullException(nameof(err)));
            return err;
        }

        #region Specialized Messages

        internal CompilerError UnresolvableType(AstType type) => Add("The type {0} could not be resolved!", type);

        internal CompilerError InvalidExpression(object value)
        {
            throw new NotImplementedException();
        }

        internal CompilerError InvalidSymbol(Declaration def)
        {
            throw new NotImplementedException();
        }

        internal CompilerError UndeducedType(Declaration def)
        {
            throw new NotImplementedException();
        }

        public CompilerError TypeMismatch(Type type, Expression initializer)
        {
            throw new NotImplementedException();
        }

        public CompilerError Critical(string msg) => Add("Critical: {0}", msg);

        public CompilerError AlreadyDeclared(SymbolName name) => Add("A symbol with the name {0} is already declared in this scope!", name);

        public CompilerError UnknownImport(CompoundName name) => Add($"Could not find module {name} for import.");

        #endregion

        #region ICollection<CompilerError>
        

        int ICollection<CompilerError>.Count => ((ICollection<CompilerError>)contents).Count;

        bool ICollection<CompilerError>.IsReadOnly => ((ICollection<CompilerError>)contents).IsReadOnly;

        void ICollection<CompilerError>.Add(CompilerError item)
        {
            ((ICollection<CompilerError>)contents).Add(item);
        }

        void ICollection<CompilerError>.Clear()
        {
            ((ICollection<CompilerError>)contents).Clear();
        }

        bool ICollection<CompilerError>.Contains(CompilerError item)
        {
            return ((ICollection<CompilerError>)contents).Contains(item);
        }

        void ICollection<CompilerError>.CopyTo(CompilerError[] array, int arrayIndex)
        {
            ((ICollection<CompilerError>)contents).CopyTo(array, arrayIndex);
        }

        IEnumerator<CompilerError> IEnumerable<CompilerError>.GetEnumerator()
        {
            return ((ICollection<CompilerError>)contents).GetEnumerator();
        }

        bool ICollection<CompilerError>.Remove(CompilerError item)
        {
            return ((ICollection<CompilerError>)contents).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<CompilerError>)contents).GetEnumerator();
        }
        #endregion
    }
}
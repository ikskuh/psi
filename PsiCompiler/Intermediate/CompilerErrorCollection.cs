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



        #region Specialized Messages

        internal CompilerError UnresolvableType(AstType type) => Add("The type {0} could not be resolved!", type);

        internal CompilerError InvalidExpression(Grammar.Expression value) => Add($"The expression '{value}' could not be translated!");

        internal CompilerError InvalidSymbol(Declaration def)
        {
            throw new NotImplementedException();
        }

        internal CompilerError UndeducedType(Declaration def)
        {
            throw new NotImplementedException();
        }

        public CompilerError TypeMismatch(Type type, Expression initializer) => Add($"The expression {initializer} does not match the type {type}");

        public CompilerError Critical(string msg) => Add("Critical: {0}", msg);

        public CompilerError AlreadyDeclared(Signature name) => Add("A symbol with the name {0} is already declared in this scope!", name);

        public CompilerError UnknownImport(CompoundName name) => Add($"Could not find module {name} for import.");


        public CompilerError RequiresInitializer(Symbol sym) => Add($"The constant {sym.Name} requires an initializer!");

        public CompilerError NoCommmonType() => Add("No common type was found!");

        public CompilerError UntranslatableStatement(Grammar.Statement body) => Add($"The statement {body} was not translatable.");

        public CompilerError SymbolNotFound(string variable) => Add($"The variable '{variable}' could not be found!");

        internal void UnknownOperator(BinaryOperation binop)
        {
            throw new NotImplementedException();
        }

        internal void UnknownOperator(UnaryOperation unop)
        {
            throw new NotImplementedException();
        }

        public CompilerError InvalidType(Type type, string message) => Add($"Invalid type {type}. {message}");

        public CompilerError UnknownArgument(FunctionType type, NamedArgument arg) => Add($"Argument {arg.Name} does not exist in {type}.");

        public CompilerError UnknownArgument(FunctionType type, PositionalArgument arg) => Add($"Argument {arg.Position} does not exist in {type}.");

        public CompilerError AmbiguousExpression(Grammar.Expression expr, IReadOnlyCollection<Expression> functions)
        {
            if (functions.Count == 0)
                return Add($"Failed to deduce type for expression {expr}");
            else
                return Add($"Ambigious expression: {expr}");
        }

        #endregion
    }
}
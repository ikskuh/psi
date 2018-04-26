using System.Collections;
using System.Collections.Generic;

namespace Psi.Compiler.Intermediate
{
    public sealed class Block : Statement
    {
        public Block()
        {

        }

        public IList<Statement> Statements { get; set; } = new List<Statement>();
    }
}
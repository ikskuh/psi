using System;

namespace Psi.Compiler
{
    [Flags]
    public enum ParameterFlags
    {
        None = 0,
        In = 1,
        Out = 2,
        InOut = In | Out,
        This = 4,
        Lazy = 8
    }
}
using System;
using System.Collections.Generic;

namespace Psi.Compiler.Intermediate
{
    public static class TypeMapper
    {
        private static readonly Dictionary<System.Type, Type> cs2psi = new Dictionary<System.Type, Type>();
        private static readonly Dictionary<Type, System.Type> psi2cs = new Dictionary<Type, System.Type>();

        public static void Add(System.Type cstype, Type psitype)
        {
            cs2psi.Add(cstype, psitype);
            psi2cs.Add(psitype, cstype);
        }

        public static Type Get<T>() => cs2psi[typeof(T)];

        public static System.Type Get(Type t) => psi2cs[t];

        public static Type ToPsi(this System.Type type) => cs2psi[type];

        public static System.Type ToSystem(this Type type) => psi2cs[type];
    }
}
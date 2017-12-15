using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
    /*
    const set = fn(out dst : int, src : int) { dst = src; };

    const main = fn()
    {
	    var i : int;
	    set(i, 42);

	    const print = fn() 
	    {
		    print("i = ");
		    print(i);
		    print("\n");
	    };

	    print();
    };
    */

    /* Types:
     * [0] int
     * [1] fn(out p0 : int, in p1 : int)
     * [2] fn()
     * [3] fn(in p1 : int);
     * [4] char
     * [5] fn(in p1 : array<char>);
     */

    /* Functions:
     * [0] fn(out dst : int, src : int) { dst = src; }
     * [1] fn() { print("i = "); print(i); print("\n"); }
     * [2] fn() { var i : int; set(i, 42); const print = ...; print(); }
     */

    /* Literals:
     * [0] 42 : int
     * [1] "i = " : array<char>
     * [2] "\n" : array<char>
     */
    
    /* Global Variables:
     * [0] set  : t[1] = f[0]
     * [1] main : t[2] = f[2]
     */

    class Function
    {
        private readonly IStatement[] code;

    }

    interface IStatement
    {
        void Execute(ExecutionContext context);
    }

    class ExecutionContext
    {
        public int InstructionPointer { get; set; }

        public StorageContext Locals { get; }

        public StorageContext CreationContext { get; }
    }

    class Program
    {
        private readonly Type intType = new Type();
        private readonly Type mainFuncType = new Type();
        private readonly Type setFuncType = new Type();
        private readonly Type printFuncType = new Type();
        private readonly Type mainPrintFuncType = new Type();

        void Run()
        {
            var set = new ValueStore(setFuncType);
            var main = new ValueStore(mainFuncType);


            {
                var locals = new StorageContext(new ValueStore(intType));

                var func = new Function();
            }
        }

        static void Main(string[] args)
        {
            Program pgm = new Program();
            pgm.Run();
        }
    }
}

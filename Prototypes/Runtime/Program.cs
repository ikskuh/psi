using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psi.Runtime;
using Array = Psi.Runtime.Array;
using Boolean = Psi.Runtime.Boolean;

namespace Runtime
{
	class Program
	{
		void Run()
		{
			var @void = VoidType.Instance;
			var @int = IntegerType.Instance;
			var @bool = BooleanType.Instance;
			var @char = CharacterType.Instance;
			var @string = new ArrayType(@char);
			
			var setType = new FunctionType(new Parameter("dst", @int, ParameterFlags.Out), new Parameter("src", @int));
			var mainType = new FunctionType();
			var printIntType = new FunctionType(new Parameter("value", @int));
			var printStringType = new FunctionType(new Parameter("value", @string));
			var intBinOpType = new FunctionType(@int, new Parameter("lhs", @int), new Parameter("rhs", @int));
			var intRelOpType = new FunctionType(@bool, new Parameter("lhs", @int), new Parameter("rhs", @int));
			var intAssOpType = new FunctionType(@int, new Parameter("dst", @int, ParameterFlags.Out), new Parameter("val", @int));
			var limitType = new FunctionType(@int);
		
			var stringLiteral0 = new Array(@string, "i = ".Select(c => new Character(c)));
			var stringLiteral1 = new Array(@string, "\n".Select(c => new Character(c)));
		
			var @set = new UserFunction(setType, new Statement[]
			{
				new Statement.Call(new GlobalReference(6, false), new NullReference(), new StackFrameReference(0, false), new StackFrameReference(1, true)) { Location = "set:0" },
				new Statement.Exit() { Location = "set:1" } ,
			});
			
			var @print = new UserFunction(mainType, new Statement[]
			{
				new Statement.Call(new GlobalReference(3, false), new GlobalReference(8, true)) { Location = "print:0" },
				new Statement.Call(new GlobalReference(2, false), new CreationFrameReference(0, true)) { Location = "print:1" },
				new Statement.Call(new GlobalReference(3, false), new GlobalReference(9, true)) { Location = "print:2" },
				new Statement.Exit() { Location = "print:3" },
			});
			
			var @limit = new UserFunction(limitType, new Statement[]
			{
				new Statement.Call(new GlobalReference(6, false), new NullReference(), new StackFrameReference(0, false), new GlobalReference(10, true)) { Location = "limit:0" },
				new Statement.Exit() { Location = "limit:1" },
			});
			
			var @main = new UserFunction(mainType, new Statement[]
			{
				// 0: call   g[0] SF[0] *g[7]        /* set(i,42) */
				new Statement.Call(new GlobalReference(0, false), new StackFrameReference(0, false), new GlobalReference(7, true)) { Location = "main:0" },
				
				// 1: call   g[12] SF[3]            /* tmp1 = limit() */
				new Statement.Call(new GlobalReference(12, false), new StackFrameReference(3, false)) { Location = "main:1" },
				
				// 2: call   g[5] SF[2] *SF[0] *SF[3] /* tmp0 = (i > tmp1) */
				new Statement.Call(new GlobalReference(5, false), new StackFrameReference(2, false), new StackFrameReference(0, true), new StackFrameReference(3, true)) { Location = "main:2" },
				
				// 3: jmpifn 7 SF[2]                 /* while(tmp0) { */
				new Statement.ConditionalJump(new StackFrameReference(2, false), 7, JumpBehaviour.WhenFalse) { Location = "main:3" },
				
				// 4: call   g[4] SF[3] *SF[0] *g[11] /* tmp1 = i - 1 */
				new Statement.Call(new GlobalReference(4, false), new StackFrameReference(3, false), new StackFrameReference(0, true), new GlobalReference(11, true)) { Location = "main:4" },
				
				// 5: call   g[6] SF[0] *SF[3]       /* i = tmp1 */
				new Statement.Call(new GlobalReference(6, false), new NullReference(), new StackFrameReference(0, false), new StackFrameReference(3, true)) { Location = "main:5" },
				
				// 6: jmp    1                       /* } */
				new Statement.Jump(1) { Location = "main:6" },
				
				// 7: newfun SF[1] f[1]              /* print = f[1](SF) */
				new Statement.CreateClosure(new StackFrameReference(1, false), @print) { Location = "main:7" },
				
				// 8: call   SF[1]                   /* print() */
				new Statement.Call(new StackFrameReference(1, false)) { Location = "main:8" },
				
				// 9: exit                           /* return */
				new Statement.Exit() { Location = "main:9" }
			}, @int, mainType, @bool, @int );
			
			var @printInt = new BuiltinFunction(@printIntType, (args) =>
			{
				Console.Write("{0}", args[0].Value as Integer);
				return null;
			});
			
			var @printString = new BuiltinFunction(@printIntType, (args) =>
			{
				var value = args[0].Value as Array;
				var text = string.Join<string>("", value.Select(v => char.ConvertFromUtf32((v as Character).Value)));
				Console.Write("{0}", text);
				return null;
			});
		
			var @intAss = new BuiltinFunction(intAssOpType, (args) =>
			{
				args[0].Value = args[1].Value;
				return null;
			});
			
			var @intSub = new BuiltinFunction(intBinOpType, (args) =>
			{
				return new Integer((args[0].Value as Integer) - (args[1].Value as Integer));
			});
			
			var @intMoreThan = new BuiltinFunction(intBinOpType, (args) =>
			{
				return new Boolean((args[0].Value as Integer) > (args[1].Value as Integer));
			});
		
			var literalMain = new Function(@main);
		
			var globals = new StorageContext(13);
			{
				globals[0] = new ValueStore(new Function(@set)); //  set    : t[1] = f[0](nil)
				globals[1] = new ValueStore(literalMain); //  main   : t[2] = f[2](nil)
				globals[2] = new ValueStore(new Function(@printInt)); //  print  : t[3] = f[5](nil)
				globals[3] = new ValueStore(new Function(@printString)); //  print  : t[5] = f[4](nil)
				globals[4] = new ValueStore(new Function(@intSub)); //  '-'    : t[6] = f[6](nil)
				globals[5] = new ValueStore(new Function(@intMoreThan)); //  '>'    : t[7] = f[7](nil)
				globals[6] = new ValueStore(new Function(@intAss)); //  '='    : t[8] = f[3](nil)
				globals[7] = new ValueStore(new Integer(42)); //  42     : int
				globals[8] = new ValueStore(stringLiteral0); //  "i = " : array<char>
				globals[9] = new ValueStore(stringLiteral1); //  "\n"   : array<char>
				globals[10] = new ValueStore(new Integer(38)); //  38    : int
				globals[11] = new ValueStore(new Integer(1)); //  1     : int
				globals[12] = new ValueStore(new Function(@limit)); // limit : t[10] = f[8](nil)
			}
			
			literalMain.Call(globals);
		}

		static void Main(string[] args)
		{
			var pgm = new Program();
			pgm.Run();
		}
	}
}


Primitive(Builtin) Typen:
  - Integer
  - Real
	- Char
	- Null
	- ref<T>
Typkonstrukte:
	- Enum<a,b,c>
	- Array<a,b,dims>
	- Record(field:name)

Syntax Sugar:
	Operator → Function Call
	Cast → Function Call

Operator Definition.

```
const operator* = fn(a : int, b : int) -> int
{
	var r : a'type = 0;
	if(b < 0) {
		b = abs(b);
		a = -a;
	}
	while(b > 0) {
		r += a;
		b--;
	}
	return r;
}

const operator[] = fn(int i, int j) -> bool
{
	return (i & (1<<j)) != 0;
};
var i = 0x10;
if(i[4] == true)
	print("Fourth bit is set!");

```
	
Naming Type:
```
type named = enum(a,b,c);
```
	
Implicit Casting:
	Named Type → Unnamed Type
```
const foo : named = a;
const f : fn(x : enum(a,b,c));
f(foo);
```

Explicit Casting
	Unnamed Type → Named Type
```
const x : enum(a,b,c) = a;
const foo = named(x);
```
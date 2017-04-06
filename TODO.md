# TODO

## Syntax Level
- Add `special` operators (call, index)
- Allow only `<positional>* <named>*` argument lists...
- Allow `delete` only when explicit memory mode is on
- Decide if a function restriction is introduced with `with` or with `where`...

## Semantic Level
- Define language semantics (how?!)
- Think about multithreading implementations
- Define scopes and scope types
- Define type properties
	- Name
	- Type (Primitive, Record, Enum, Function, Predefined)
	- Operations (Construct, Deconstruct, Copy, Move)

## Compiler Level
- Enable/Disable certain language features
	- Lambda/closure vs. static function
	- Reference counting and secure pointers vs. manual memory management (uses `delete`)

## Documentation
- Document syntax
	- `type foo = bar` is equivalent to `const foo : type = bar`
- Document semantics (how?!)
- Document compiler

> fuer mich interessant wäre z.B die information "was ist das besondere an der sprache, wofuer ist sie besser geeignet als $x"
> "worin unterscheidet sie sich von $x, wenn sie ähnliche ziele verfolgt"
> -> darum eher vergleichend

> und dann gibt's noch fragen wie "wie ist das speichermodell", thread-safety und so gedöns, was eher advanced ist
	
```
export const main = fn(args : array<string>) -> int
	with args.length > 0
{
	return args.length;
};
```
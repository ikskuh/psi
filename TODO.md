# TODO

## Syntax Level
- Add restrictions for functions with `with`
- Add syntax for `new`, `delete`
	- generalize with `<name> <expr>`
	- `new` always
	- `delete` only when explicit memory mode is on
- Add syntax for typed for: `for(i:int in foo)`
- Allow only `<positional>* <named>*` argument lists...

## Semantic Level
- Define language semantics (how?!)

## Compiler Level
- Enable/Disable certain language features
	- Lambda/closure vs. static function
	- Reference counting and secure pointers

## Documentation
- Document syntax
	- `type foo = bar` is equivalent to `const foo : type = bar`
- Document semantics (how?!)
- Document compiler
	
```
export const main = fn(args : array<string>) -> int
	with args.length > 0
{
	return args.length;
};
```
# TODO

## Syntax Level
- Add declaration of overloaded operators
- Add restrictions for functions with `with`

## Semantic Level
- Define language semantics (how?!)

## Compiler Level
- Enable/Disable certain language features
	- Lambda/closure vs. static function
	- Reference counting and secure pointers

## Documentation
- Document syntax
- Document semantics (how?!)
- Document compiler
	
```
export const main = fn(args : array<string>) -> int
	with args.length > 0
{
	return args.length;
};
```
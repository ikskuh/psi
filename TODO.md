# TODO

## Syntax Level
- Add restrictions for functions with `with`
- Add named parameters with `(1,2,index:10)`
- Apply type semantics to AST on parsing (syntax sugar)

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
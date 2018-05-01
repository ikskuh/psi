# TODO-List

## Only those stupid conceptual tasks
- Create a list of possible optimizations
	- Same-tree-merging in expressions
- Make records extendable with a set of other records?
	```psi
	type vec2 = record(x : real, y : real);
	type vec3 = record extending vec2 (z : real);
	```
- Integrate checked/unchecked blocks into Psi (straight from C#)
- Integrate useful exception handling.
- `std.char` literal different from a `std.string` literal sounds useful
	- ``X`` instead of `"X"` for `std.char`?

## Documentation tasks
- Document ref<T> with all its quirks (especially with `inout param : ref<T>`)

## Meta-Tasks
- Define Standard-Library-API

## Actual programming tasks
- Refactor ASTConverter:
	- Each function literal can be separatly converted
		- Separates out symbol definitions
	- The body of each literal can be converted in a "success-or-fail" manner without having to consider parts of expressions
		- Fail when not all referenced symbols are fully defined
		- Succeed when all referenced symbols compile and the code is unambigious
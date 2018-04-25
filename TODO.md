# TODO-List

## Only those stupid conceptual tasks
- Is `fn(i : int)` equivalent to `fn(j : int)` or not? (name equality)
	- Mostly bullshit and not the expected behaviour...
- Is `fn(this i : int)` equivalent to `fn(i : int)` or not? (`this` prefix equality)
	- Would also be bullshit to have `this` modify equality
- Create a list of possible optimizations
	- Same-tree-merging in expressions
- Make records extendable with a set of other records?
	```psi
	type vec2 = record(x : real, y : real);
	type vec3 = record extending vec2 (z : real);
	```
- Integrate checked/unchecked blocks into Psi (straight from C#)
- Integrate useful exception handling.

## Documentation tasks
- Document structural equality in Psi
	- Records
	- Functions
	- Types in general
- Document ref<T> with all its quirks (especially with `inout param : ref<T>`)

## Meta-Tasks
- Define Standard-Library-API

## Actual programming tasks
- Update function type equality
- Remove order dependency in record equality
- Remove initializers from record equality
- Remove initializers from function equality

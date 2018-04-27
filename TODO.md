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

## Documentation tasks
- Document ref<T> with all its quirks (especially with `inout param : ref<T>`)

## Meta-Tasks
- Define Standard-Library-API

## Actual programming tasks
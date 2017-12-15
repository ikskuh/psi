# Thoughts on the Psi type system

## Type classes
Type(nil)
	- Class (Builtin, Record, Enum, Function, Reference, Array)

Builtin(Type)
	- Name
	
Record(Type)
	- Fields
		- Name
		- Type
		- Default
		- Position

Enum(Type)
	- Values
		- Name
		- Value

Function(Type)
	- Return Type
	- Paramters
		- Specifier (In, Out, InOut, This)
		- Name
		- Type
		- Default Value
		- Position

Reference(Type)
	- Referenced Type

Array(Type)
	- Element Type
	- Dimensions

## Operations on types

- CanBeCastInto
- CanBeCastFrom
	
## Comments
New type required: `any`
	- Castable from and to any type, but casting into a defined type
		yields error when invalid
		- Implicit casting rules apply here
	- Has subscript `.type` to query currently stored type
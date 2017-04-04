# Type System

## List of Basic Types

### `null`
The null type can only accept a single value: `null`

### `any`
A variable with this type can accept any value,
the type of the value must be queried at runtime.

### `char`
This type can accept any kind of textual character
and text control codes. This includes any unicode
codepoint.

### `int<min, max, behavior=wrapping,clamping,failing>`
An integral numeric value which is ranged between
*min* and *max* inclusively.

The *behavior* defines how the type should handle overflows:

| Behaviour  | Description                                                            	|
|------------|------------------------------------------------------------------------|
| `wrapping` | The type is a *residue class*, the values will wrap around the limits. |
| `clamping` | the value will be clamped between *min* and *max*.                     |
| `failing`  | If a value exceeds the numeric limits, an error will be thrown.        |

### `real<min=-∞, max=∞, storage=binary32|binary64>`
A real numeric value that can accept any value between
*min* and *max*. The *storage* defines the floating point format according to
[IEEE 754](https://en.wikipedia.org/wiki/IEEE_floating_point#Basic_and_interchange_formats).
Not all IEEE 754 formats are supported.

### `enum<option, option, …>`
An enumeration type can accept only the given *options* defined
in the bracket list. Other values are not accepted.

### `array<type, dimensions=1>`
An unbound array of the given *type*. It contains an arbitrary
number of elements arranged in the given number of *dimensions*.

### `fixarray<type, size, size, …>`
A *size*-bound array of the given *type*. It contains exactly the
number of elements given by *size*. Each instance of size will add 
an additional dimension to the array.

### `ref<type>`
A reference to a value of *type*. References allow sharing objects
between multiple other objects. When an object has no more references
to it, the object will be released.

### `weak<type>`
A weak reference is similar to a reference but it won't affect the
object lifetime. To access the referenced value of a *weakref*, it must be
promoted to an `option<null, ref<type>>` in order to make the object access
secure. If the option is `null`, the referenced object was freed, else the
referenced value can be accessed.

### `record ( field, field, … )`
A record type will pack an ordered list of named *fields* toghether into
a single type. Each field will have its own name and type. There can be
multiple fields with the same type but each field requires a record-
unique name.

### `option<type, type, …>`
An option allows a value to accept a range of *types*. It can
only take a single type at a time and can change its type on
assignment. This can be seen as the restricted `any` type.
	
## Implicit Casting

#### down-/upcasting
A reference to a merged record type can be cast to any of the
types it is composed by. It is also possible to do a promotion of
a reference to a merged record if the referenced record has a fitting
type.

#### interface casting
For interface references apply similar rules as for merged records.
Any record type reference is castable to a fitting interface type reference.

An interface type references can also be cast to the type it actually
is.

## Generics
Generics allow to specify a single type for multiple specializations with
only some parameters changed.

A generic is a template for a type which can be used to create customizable
types.

	generic type node<VTYPE : type, ATTRIBS : int> = record
	(
		value   : VTYPE,
		attribs : fixarray<string, ATTRIBS>,
		next    : pointer<node<VTYPE, ATTRIBS>>
	);

Each generic takes a number of generic parameters which can have any type
for which a literal representation exists. These parameters can then be
used inside the generic definition instead of actual values.

When a generic is instantiated (used), the parameters will be replaced with
the values provided.

Generics can also be applied to functions where the same rules apply as for
type generics:
	
	generic fn mul<int i>(int j) -> int
	{
		return i * j;
	}

## Subscription

Most of the types provide one or more subscription options. Subscription can
be used to access nested data and fields or gather additional information.

Array indexers and field indexers may be write-protected, so the value can
only be read, but not written. Meta indexers are always read-only.

### Array Indexer `[idx]`
The array indexer is used to access a nested datum that can be addressed by a
dynamic value. Array indexers can have one or more dimensions and can accept any
type.

For the both array types `array<>` and `narray<>` the indexers are numeric
and zero-based.

### Field Indexer `.field`
A field indexer is used to access a static datum like a record field. The index has
no type and can only be addressed by the fields name.

### Meta Indexer  `'meta`
A meta-indexer is used to gather information about the type of a value or a types
configuration.

### Examples

	(* Array indexer *)
	var idx : int = 1;
	var arr : array<int> = [ 1, 2, 3 ];
	print(arr[0]);
	print(arr[idx]);
	arr[2] = 10;
	
	(* Field Indexer *)
	type date = record(day : int, month : int, year : int);
	var today : date = date(15,01,2017);
	print(today.day);
	today.year = 2000;
	
	(* Meta Indexer *)
	var i : int = 10;
	print(i'min);
	print(i'max);

## List of Type Aliases

	optional<T> = option<null, T>
	boolean     = enum<true, false>
	tristate    = optional<boolean>
	pointer<T>  = optional<ref<T>>
	string      = array<char>
	u8          = int<0, 255>
	u16         = int<0, 65536>
	u32         = int<0, 4294967296>
	u64         = int<0, 18446744073709551616>
	i8          = int<-128, 127>
	i16         = int<-32768, 32767>
	i32         = int<-2147483648, 2147483647>
	i64         = int<-9223372036854775808, 9223372036854775807>
	half        = real<-∞, ∞, half>
	float       = real<-∞, ∞, single>
	double      = real<-∞, ∞, double>
	uint        = u32; (* This may be a u16 or u64, dependinging on the system *)
	int         = i32; (* This may be a u16 or u64, dependinging on the system *)

<hr />

	FileSystem = record
	(
		root : Directory
	)

	Directory = record
	(
		files : array<File>
	)

	File = record
	(
		owner        : ref<User>,
		name         : string,
		data         : any,
		creationTime : DateTime,
		lastWrite    : DateTime
	)

	DateTime = merge<Date,Time>;

	Date = record
	(
		day   : int<1, 31>,
		month : int<1, 12>,
		year  : i32
	)

	Time = record
	(
		hour     : int<0, 23>,
		minute   : int<0, 59>,
		second   : int<0, 59>,
		useconds : int<0, 999999>,
	)

	User = record
	(
		name          : string,
		passwordHash  : array<u8, 32>,
		isAdmin       : boolean,
		homeDirectory : optional<Directory>,
		shell         : optional<Executable>
	)

	Executable = record
	(
		secions : array<Section>,
		…
	)

	Section = record
	(
		offset : uint,
		data   : array<u8>,
		…
	)
	
<hr />

## Design TODOs

### Reference handling and auto references
What happens when you pass a non-ref object
to a reference value?

As references are reference-counted, the objects must
be on the heap, but what about stack objects?

> Solution: Do not allow reference promotion.

### Promoting an object to the heap/references

### Unit Types
Declaration of units instead of numeric types
with conversion factors to other units.

Each unit requires a unit class where each unit in the
class is castable to other units. Cross-unit-class casting
is not possible without "enforced conversion"

Literals of a unit type must be postfixed with the fitting
unit marker, unit values must be declared in terms of quantities

#### Quantities
A quantity is required per unit type like

- distance/length
- weight
- time
- …

### How to handle numeric overflow?
- "Ignore"
- Error
- Wrap
- Clamp

### Exception Handling
How?

Stack Unwinding, depends on ABI

### Is a function type useful?
Pro: Pretty useful for functional programming and stuff

Con: Not serializable at all

### Semantic versioning for types
This is useful and required for serialization

### Type Packing
Always, never, optional?

### Write about reflection and the reflection types

### Memory layout for arrays

- Row Major
- Column Major
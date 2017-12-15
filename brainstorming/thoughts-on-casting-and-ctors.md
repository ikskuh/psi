# Thoughts on casting and construction in Psi

## Object Construction
Objects in Psi are either constructed via a literal (enum, number, string, function, array, type)
or by using a constructor function (records). One exception is a reference object which is
created by applying the `new` operator on an expression.

If a record type is defined, a const function object with the same name will be defined. This
will not happen if the type is defined by a variable declaration or used implicitly as a type
literal. Constructing such an anonymous record is done by calling the generic record constructor
`record` as a function.

```
var x : record(i : int, j : int);
x = record(i:1, j:2);
```

## Implicit Casting

## Explicit Casting

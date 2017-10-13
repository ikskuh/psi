# Psi Examples

This folder contains some example files for the language so one can get a first
impression on how the language looks and feels.

## `hello-world.psi`

This is the classic programming language example provided for nearly every
programming language: *Hello World*

```psi
import std;
import std.io;

const main = fn(args : array<string>) -> int
{
	print("Hello, World!");
};
```


## `parsertest.psi`
This file is some kind of unit test for the parser. It contains all syntactical
structures the language provides.

> ein- und ausgabe, iteration, lese- schreibzugriff,
> einzigartige sprachfeatures und syntactic sugar eventl.
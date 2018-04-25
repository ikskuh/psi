# Datentypen

## Primitive Datentypen

### `std.byte`
Ein 8 Bit breiter, vorzeichenloser Ganzzahlen-Datentyp. Der Wertebereich geht von *0* bis *255*.

```psi
const NUL : byte = 0;
const STX : byte = 2;
const ETX : byte = 3;
```

### `std.int`
Ein 32 Bit breiter, vorzeichenbehafter Ganzzahlen-Datentyp, der als Zweierkomplement implementiert ist.
Der Wertebereich geht von *-2147483648* bis *2147483647*.

```psi
var x : int = 10;
var y : int = -25000;
```

### `std.real`

Ein Fließkomma-Datentyp, der das *IEEE754-Format* als *binary64* implementiert. Im anderen Programmiersprachen ist dieser
Datentyp als `double` bekannt.

```psi
const pi : double = 3.14159265358979323846;
const e  : double = 2.71828182845904523536;
```

### `std.char`

Ein Symbol-Datentyp, der Unicode-Symbole aufnehmen kann. Wird in der *UTF-32*-Kodierung gespeichert und benötigt somit 4 Byte pro Character.

```psi
const latinA : char = "A"; 
const psi    : char = "Ψ";
const venus  : char = "♀";
const mars   : char = "♂";
```

## Benutzerdefinierte Datentypen

### Arrays (`array`)

> TODO

### Aufzählung (`enum`)
Eine Aufzählung ist ein einfacher Datentyp, der eine benutzerdefinierte Menge an Werten annehmen kann. Diese werden in runden Klammern angegeben:

```psi
type color = enum(red, green, blue, cyan, magenta, yellow, white, black);
```

Auf die Werte einer Aufzählung kann mit Hilfe eines Enum-Literals zugegriffen werden:

```psi
var blau : color = :red;
```

### Typisierte Aufzählungen (`enum<T>`)

Typisierte Aufzählungen verhalten sich ähnlich wie normale Aufzählungen, besitzen aber eine implizite Konvertierung in den angebenen Datentyp:

```psi
type weight_unit = enum<real>(gram = 0.001, kilogram = 1.0, ton = 1000.0);

var amountOfFlour = 250.0 * :gram; // will result in 0.25
```

### Datensatz-Typen (`record`)

Datensätze sind eine Möglichkeit, Daten zu strukturieren. Ein Datensatz enthält mehrere Felder, welche 

### Funktionstypen (`fn`)

> TODO

## Vordefinierte Datentypen

### `std.bool`

Ein boolscher Wert kann nur zwei Zustände annehmen: `true` und `false`. 

```psi
type bool = enum(false, true);

// Vordefinierte Werte für true/false
const true : bool = :true;
const false : bool = :false;
```

### `std.string`

Ein String ist eine Verkettung von Zeichen, die zusammen einen Text ergeben. Psi implementiert diese als
Array von `std.char` und nicht als gesonderten Datentyp, um eine einfachere API-Kompatibiltät zu anderen
Funktionen zu bieten.

```psi
type string = array<std.char>;
```

Strings können mit einem String-Literal inline definiert werden:

```
var langName = "Psi";
```

### `std.bitstring`

Ein Array aus Byte-orientierten Binärdaten.

```psi
type bitstring = array<std.byte>;
```

## Compiler-Datentypen

### `std.compiler.void`

### `std.compiler.type`

### `std.compiler.module`

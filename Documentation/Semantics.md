
Typen:
- Builtin-Typen
	- Integer
		: Ganzzahliger Datentyp, welcher keine Größenbeschränkung besitzt.
		: Wird intern als "big integer" gehandhabt.
	- Char
		: Datentyp, welcher einen Unicode-Codepoint enthält und damit ein
		: einzelnes Zeichen darstellt.
		: Wird intern als 32 bit Zahl gehandhabt.
	- Real
		: Datentyp für reelle Zahlen. Wird intern als IEEE754(binary64)
		: behandelt.
	- Array
		: Dynamisches Array, welches eine geordnete Menge an Elementen
		: eines bestimmten Types enthält.
- Vordefinierte (notwendige) Typen
	- Type
		: Ein Typ, welcher eine Beschreibung für die in Psi verwendeten
		: Datentypen bereitstellt.
- Benutzerdefinierte Typen (Vorlage)
	- Record
	- Enum
	- Funktionstypen

# Begriffe

## Objekt
Ein Objekt ist ein konkreter Wert, welcher das Ergebnis eines Ausdruckes oder
der Inhalt einer Variable ist.

## Symbol
Ein Symbol ist ein benannter Wert, welcher in einer Variablen oder einem Parameter
gespeichert wird.

## Scope
Die aktuelle Sicht auf alle definierten Symbole, welche von einer bestimmten Stelle
im Code adressiert werden können.

## Parameter und Argument
Eine Funktion besitzt in ihrer Definition eine Liste an benannten Parametern, welche die
abstrakte Definition liefern. Bei einem Funktionsaufruf wird ein Argument in einen Parameter
übergeben. Das heißt, dass ein Argument den Wert festlegt, welcher in einen Parameter übergeben
wird.

# Operatoren:
	Zuweisung (`=`):
		Bei de Ausführung der Operation `a = b` wird die Struktur des Objekts `b`
		ohne Umformung in das Objekt `a` übertragen. Die beiden Objekte sind danach
		als *gleich* anzusehen.
	Meta-Operator (`'field`):
		Der Meta-Operator greift auf statische Daten eines Objektes
	Heap-Operator (`new`):
		Bei der Ausführung des Heap-Operators `new a` wird ein neuer Wert des Typs
		von `a` auf dem Heap alloziert und mit den Werten aus `a` initialisiert.
		Zurückgegeben wird ein Wert des Typs `ref<a'type>`.

# Speicherorte für Werte

## Globaler Speicher
Alle Variablen, welche in einem Modul liegen, sind im globalen Speicher.

## Lokaler Speicher
Variablen, welche als lokale Variable oder aber als Parameter definiert sind, liegem im lokalen Speicher.

## Heap-Speicher
Das Ergebnis eines Ausdrucks kann in den Heap-Speicher für längerfristige, dynamische Speicherung "verschoben" werden.
Hierzu erhält der Wert eine einzigartige Speicheradresse (Pointer)

## Temporärer Speicher
Werte, die bei der Auswertung eines Ausdrucks entstehen und dafür als Zwischenergebnis gespeichert werden müssen,
liegen im temporären Speicher. Dieser Speicher kann nicht referenziert werden.

# Funktionsaufrufe

Ein Funktionsaufruf legt ein Stackframe an, welches die Rücksprungadresse sowie die lokalen Variablen und Parameter enthält.
Anschließend wird der Code in der Funktion ausgeführt und ein einzelner Wert zurückgegeben.

## Parameterliste

### Übergabe
Die Argumentliste bei einem Funktionsaufruf besteht aus *0* bis *n* unbenannten Argumenten, welche über ihre
Reihenfolge in die Parameter übergeben werden. Hierbei ist *n* die Anzahl an Parametern, welche die aufgerufene
Funktion besitzt.

Zudem können noch alle nicht über die Position angegeben Parameter mit einem benannten Argument definiert werden.
Hierbei spielt die Reihenfolge, in welcher die benannten Argumente angegeben werden, keine Rolle.

Alle nicht über Position oder Name angegebenen Parameter müssen einen Default-Wert besitzen, damit jeder Parameter
einen definierten Wert erhält.

```psi
const example = fn(i : int, j : int = 6, k : int = 4);

// Übergabe via Position:
example(1,2,3);

// Übergabe via Name:
example(i: 1, k: 3, j: 2);

// Gemischte Übergabe:
example(1, j: 2, k: 3);

// Default-Übergabe
example(1, 2);    // k = 4
example(1, k: 3); // j = 6
```

### Paramter-Attribute

Parameter können verschiedene Attribute haben, welche das Verhalten verändern. Hierbei gibt es folgende Optionen:

#### `in`
Dies ist das Standardverhalten eines Parameters. Es wird bei der Übergabe des Arguments eine Kopie des Arguments in
die Parametervariable gelegt und der Parameter kann wie eine lokale Variable verwendet werden.

#### `inout`
Ein `inout`-Parameter verhält sich grundlegend anders als ein `in`-Parameter: Es können nur Argumente übergeben werden,
die eine *lvalue* sind, also ein Wert, dem etwas zugewiesen werden kann. Jeder Schreibzugriff auf den Parameter erfolgt
direkt auf den übergebenen *lvalue* und modifiziert diesen.

Der Parameter kann also als Alias für den übergebenen *lvalue* gesehen werden.

```psi
const example = fn(inout i : int)
{
	i *= 2;
};
var x = 10;
example(x);
// x ist jetzt 20
example(x);
// x ist jetzt 40
```

#### `out`
Ein `out`-Parameter verhält sich analog zu einem `inout`-Parameter, nur muss dem `inout`-Parameter zuerst ein Wert
zugewiesen werden, bevor dieser verwendet wird.

Dies bedeutet, dass der ursprüngliche Wert des Arguments verworfen wird und die Funktion den Wert des Arguments mit
einem neuen Wert überschreibt.

```psi
const example = fn(out i : int)
{
	i = 42;
};
var x = 10;
example(x);
// x ist jetzt 42
```

#### `this`
Dieses Attribut kann nur mit dem ersten Parameter in einer Funktion verwendet werden und definiert eine
Erweiterungsmethode.

Diese funktionieren ähnlich wie die Erweiterungsmethoden in C#:

Das erste Argument kann als vorangestellter Ausdruck geschrieben werden und somit den Eindruck eines Methodenaufrufs
erwecken:

```psi
var fun : fn(this i : int); // Erweiterungsmethode
var num : int;

fun(num);  // klassischer aufruf
num.fun(); // erweiterter aufruf
```
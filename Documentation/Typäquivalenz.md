# Typäquivalenz

In Psi sind Datentypen strukturäquivalent und nicht, wie in vielen anderen Programmiersprachen, namensäquivalent. Hierdurch ergeben sich einige,
ungewohnte Besonderheiten.

Typ-Kompatibilität bedeutet:
> Ein Typ *a* ist zu einem Typen *b* kompatibel, wenn man einen Wert vom Typ *a* an einer Stelle schreiben kann, an der Typ *b* erwartet wird.

Typ-Äquivalenz bedeutet:
> Wenn ein Typ *a* ist zu einem Typen *b* äquivalent ist, werden beide Typem vom Compiler als der selbe Typ gehandhabt.

## `byte`, `int`, `uint` und `real`
Die primitiven Zahlentypen sind immer in die "verlustfreie" Richtung kompatibel, in die Gegenrichtung muss ein Konstruktor-Cast durchgeführt werden.

Hierbei gilt die Einschränkung, dass "leichte" Verluste hingenommen werden, welche in einem `checked`-Block mit einem Fehler abgefangen werden können.

| Von\Zu | `byte` | `int`  | `uint` | `real` |
|--------|--------|--------|--------|--------|
| `byte` |   Ja   |   Ja   |   Ja   |   Ja   |
| `int`  |  Nein  |   Ja   |   Ja   |   Ja   |
| `uint` |  Nein  |   Ja   |   Ja   |   Ja   |
| `real` |  Nein  |  Nein  |  Nein  |   Ja   |

```psi
// legal:
var b : byte = 250;
var i : int  = b;
var u : uint = i;
var r : real = r;
b = byte(r); // discards and wraps to 8 bit

// illegal:
b = i;
i = r;
```

## Funktionstypen
Ein Funktionstyp *a* ist zu einem anderen Funktionstyp *b* äquivalent, falls folgende Bedingungen gelten:
- Die Anzahl der Parameter ist gleich
- Die Parameter haben in der Reihenfolge übereinstimmende Typen
- Die Parameter haben das gleiche Prefix
    - **Ausnahme:** `this` wird bei der Typkompatibiltät nicht beachtet und gilt nur im Deklarationskontext einer Variable.
- Der Rückgabewert ist gleich.

## Record-Typen
Ein Record-Typ *a* ist zu einem anderen Record-Typen *b* kompatibel, falls gilt:
- Für jedes Feld *y* aus *b* existiert ein Feld mit gleichem Namen sowie __kompatiblem__ Typen in *a*.

Ein Record-Typ *a* ist äquivalent zu einem Record-Typen *b*, falls gilt:
- Für jedes Feld *y* aus *b* existiert ein Feld mit gleichem Namen sowie __gleichem__ Typen in *a*.
- Für jedes Feld *x* aus *a* existiert ein Feld mit gleichem Namen sowie __gleichem__ Typen in *b*.

Obwohl zwei Record-Typen als äquivalent betrachtet werden, können diese doch unterschiedliche Initializer haben:
```psi
// vec2a und vec2b sind äquivalent
type vec2a = record(x : real = 0.0, y : real = 0.0);
type vec2b = record(y : real, x : real);
```

Dies liegt daran, dass der Initializer keine Typ-Eigenschaft ist, sondern einen Konstruktor definiert.
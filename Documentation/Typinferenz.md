# Implizite Umwandlungen

In Psi finden, wie in jeder anderen Programmiersprache, eine Reihe von impliziten Umwandlungen dar.
Literale besitzen mehr als einen Datentypen und müssen dementsprechend ggf. in einen passenden
Datentyp gewandelt werden.

Zudem erlaubt Psi auch die implizite Umwandlung von Record-Datentypen auf andere, kompatible Record-Datentypen.

## Umwandlung von Integer-Literalen



## Umwandlung von String-Literalen

Jedes String-Literal, welches nur einen Buchstaben enthält, darf implizit in einen `std.char` umgewandelt werden.
Hiermit wird nur ein Literal-Typ benötigt.

Hierbei tritt aber eine mögliche Doppeldeutigkeit auf:

```psi
const f : fn(c : char);
const f : fn(s : string);
f("X");
```

Hier kann `"X"` sowohl `std.char` als auch `std.string` sein. Da die `std.string`-Darstellung der Normalform des Stringliterals
entspricht wird in diesem Fall `fn(c : string)` aufgerufen.

Soll trotz dieser Regel `fn(s : char)` aufgerufen werden, muss das Literal vorher in eine String-Variable kopiert werden:;

```psi
const f : fn(c : char);
const f : fn(s : string);
const lit_X : char = "X";
f(lit_X);
```
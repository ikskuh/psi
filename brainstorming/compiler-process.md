
# Compiler Process

1. Für jedes zu compilierende Modul:
    1. Erzeuge alle Symbole (Typen und Variablen)
    2. Erstelle eine Liste der exportierten Typen
2. Für jedes zu compilierende Modul:
    1. Löse alle Importe in den privaten Modulscope auf
    2. Löse alle deklarierten Typentypen und deren Abhängigkeiten auf
3. Für jedes zu compilierende Modul:
    1. Für jede deklarierte Variable, bestimme den möglichen Datentyp
    1. Für jede deklarierte Varia
4. 


```psi
type nothing = std.void;
```
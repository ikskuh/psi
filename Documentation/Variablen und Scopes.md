# Variablen und Scopes

In Psi gibt es nur eine Art von Symbol: Die Variable.

Eine Variable hat folgende Eigenschaften:
- Name
- Typ
- ggf. Initializer
- Const / Variabel
- Exportiert / Lokal

Die Besonderheit an Psi-Variablen ist, dass sie nicht wie in
quasi allen Programmiersprachen durch ihren Namen, sondern auch
zusätzlich durch ihren Datentypen identifiziert werden.
Ein Identifier besteht somit aus dem Tupel *(Typ, Name)*.

Dieses Konzept nennt sich *Multi-Variable*.
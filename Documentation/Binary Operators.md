# Binary Operators

## Precedence

Strongest to weaskest bindings:

- `.`, `[]`, `'`, `()`
- unary: unary `+`, unary `-`, `~`
- shifting: `>>>` `<<` `>>` : erlaube `1<<2 + 1<<3 == 12`
- expo: `**`
- term: `*` `/` `%`
- sum: `+` `-` `--`
- expr_arrows: `->` `<-`
- comparison: `<=` `>=` `<` `>`
- equality: `!=` `==` 
- expr_and: `&` : bindet schwächer als `==`, da `a==1 & b==2` nicht `(a == (1&b) == 2)` sein soll, selbiges für implikation: `a -> b & c -> d` ist nicht `a -> (b & c) -> d`, sondern `(a -> b) & (c -> d)`
- expr_xor: `^` 
- expr_or: `|`
- expression: `=` `:=` `>>>=` `<<=` `>>=` `+=` `-=` `--=` `*=` `/=` `%=` `**=` `~=` `&=` `|=` `^=`

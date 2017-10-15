
strong binding

- `.`, `[]`, `'`, `()`
x unary: unary `+`, unary `-`, `~`
x shifting: `>>>` `<<` `>>` : erlaube `1<<2 + 1<<3 == 12`
x expo: `**`
x term: `*` `/` `%`
x sum: `+` `-` `--`
x expr_arrows: `->` `<-`
x comparison: `<=` `>=` `<` `>`
x equality: `!=` `==` 
x expr_and: `&` : bindet schwächer als `==`, da `a==1 & b==2` nicht `(a == (1&b) == 2)` sein soll, selbiges für implikation: `a -> b & c -> d` ist nicht `a -> (b & c) -> d`, sondern `(a -> b) & (c -> d)`
x expr_xor: `^` 
x expr_or: `|`
x expression: `=` `:=` `>>>=` `<<=` `>>=` `+=` `-=` `--=` `*=` `/=` `%=` `**=` `~=` `&=` `|=` `^=`

weak binding
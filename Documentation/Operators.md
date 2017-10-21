# Operators

## Precedence

Strongest to weaskest bindings:

- `.`, `'`, `[]`, `()`
- unary: unary `+`, unary `-`, `~`, `new`
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

## Field Index Operator (`.`)

## Meta Operator (`'`)

## Array Indexing Operator (`[]`)

## Function Call Operator (`()`)

## Unary Plus Operator (`+`)

## Unary Minus Operator (`-`)

## Inversion Operator (`~`)

## `new` Operator

## Arithmetic Shift Right (`>>>`)

## Logical Shift Right (`>>`)

## Logical Shift Left (`<<`)

## Exponentiation Operator (`**`)


## Multiplication Operator (`*`)

## Division Operator (`/`)

## Modulo Operator (`%`)

## Addition Operator (`+`)

## Subtraction Operator (`-`)

## Concatenation Operator (`--`)

## Addition Operator (`+`)

## Forward Operator (`->`)

## Backward Operator (`<-`)

## Comparison Operators (`<=`, `>=`, `<`, `>`)

## Equality Operators (`!=`, `==`)

## And Operator (`&`)

## Exclusive Or Operator (`^`)

## Or Operator (`|`)

## Flat Copy Assignment Operator (`=`)

## Semantic Assignment Operator (`:=`)

## Shorthand Assignment Operators (`>>>=`, `<<=`, `>>=`, `+=`, `-=`, `--=`, `*=`, `/=`, `%=`, `**=`, `~=`, `&=`, `|=`, `^=`)

module Infix

open Expressions
open FParsec

let (<!>) (p: Parser<_,_>) label : Parser<_,_> =
  fun stream ->
    printfn "%A: Entering %s" stream.Position label
    let reply = p stream
    printfn "%A: Leaving %s (%A)" stream.Position label reply.Status
    reply

let (expr, exprimpl) = createParserForwardedToRef()

let ws p = spaces >>. p .>> spaces
let str s = ws (pstring s)
let anystr strs = choice (List.map str strs)
let ident = identifier (new IdentifierOptions())
let fname = ws ident
let opname = anystr [ "+"; "-"; "*"; "/" ]
let comma = str ","
let exprlist = str "(" >>. sepBy expr comma .>> str ")"

let varname =   ws ident            |>> VariableRef
let numvalue =  ws pint32           |>> NumericLiteral
let funappl =   fname .>>. exprlist |>> FunctionApplication
let term =      ws (attempt funappl <|> varname <|> numvalue)
let infixappl = term .>>. opname .>>. term |>> fun ((l, o), r) -> InfixApplication(o, l, r)

exprimpl := ws (attempt infixappl <|> term)

let parseExpr exprText =
  match run expr exprText with
  | Success(result, _, p) -> result
  | Failure(error, _, _) -> failwith error

let evalExprText exprText env =
  let expr = parseExpr exprText
  eval expr env

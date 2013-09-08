module DiscriminatedUnions

open System

type ExprNode =
  | NumericLiteral of int
  | VariableRef of string
  | FunctionApplication of string * ExprNode list
  | InfixApplication of string * ExprNode * ExprNode

let functions =
  Map.ofList [
    ("factorial", fun args -> List.reduce (*) [1 .. List.head args])
    ("sum", fun args -> List.sum args)
    ("sqr", fun args -> (List.head args) * (List.head args))
  ]

let operators =
  Map.ofList [
    ("+", (+))
    ("-", (-))
    ("*", (*))
    ("/", (/))
  ]

let rec eval expr env =
  match expr with
  | NumericLiteral n -> n
  | VariableRef v -> env(v)
  | FunctionApplication (func, exprs) ->
      let args = [ for e in exprs -> eval e env ]
      let f = functions.[func]
      f args
  | InfixApplication (op, lexpr, rexpr) ->
      let larg = eval lexpr env
      let rarg = eval rexpr env
      let f = operators.[op]
      f larg rarg

let testEnv =
  function
  | "a" -> 1
  | "b" -> 2
  | other -> failwith ("unknown variable " + other)

let testExpr =  // sum(factorial(a + 3), b)
  FunctionApplication("sum",
    [
    FunctionApplication("factorial",
      [
      InfixApplication("+", VariableRef("a"), NumericLiteral(3))
      ])
    VariableRef("b")
    ])

let rec prettyPrint expr =
  match expr with
  | NumericLiteral n -> sprintf "%d" n
  | VariableRef v -> v
  | FunctionApplication (func, exprs) ->
      sprintf "%s(%s)" func (String.Join(", ", (List.map prettyPrint exprs)))
  | InfixApplication (op, lexpr, rexpr) ->
      sprintf "%s %s %s" (prettyPrint lexpr) op (prettyPrint rexpr)

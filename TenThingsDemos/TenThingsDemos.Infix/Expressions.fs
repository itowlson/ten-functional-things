module Expressions

open Utils

type ExprNode =
  | NumericLiteral of int
  | VariableRef of string
  | FunctionApplication of string * ExprNode list
  | InfixApplication of string * ExprNode * ExprNode

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

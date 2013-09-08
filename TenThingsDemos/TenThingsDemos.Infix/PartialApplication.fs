module PartialApplication

open Utils
open Expressions
open Infix

// Partial application

let makeEval exprText =
  let expr = parseExpr exprText
  eval expr

let runExprBad exprText envs =
  List.map (evalExprText exprText) envs
let runExprGood exprText envs =
  List.map (makeEval exprText) envs

let lotsOfEnvs = [1..200000]
                 |> List.map (fun i -> [("a", i); ("b", i + 1)])
                 |> List.map makeEnv


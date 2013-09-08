module PatternMatching

open System
open System.Collections.Generic

open Immutable
open DiscriminatedUnions

let evalOp opname lval rval =
  let op =
    match opname with
    | "+" -> (+)
    | "-" -> (-)
    | "*" -> (*)
    | "/" -> (/)
    | _   -> failwith "unknown operation"
  op lval rval

let rec factorial n =
  match n with
  | _ when n < 0 -> failwith "can't take factorial of negative number"
  | 0  | 1       -> 1
  | _            -> n * factorial (n - 1) 

let pythagoras' list =
  match list with
  | [ x; y ]    -> sqrt (x * x + y * y)
  | [ x; y; z ] -> sqrt (x * x + y * y + z * z)
  | _           -> failwith "that's a crazy number of dimensions!"

let sum' list =
  match list with
  | []          -> 0
  | [ x ]       -> x
  | [ x; y ]    -> x + y
  | [ x; y; z ] -> x + y + z
  | _           -> failwith "but who would ever need to add more than three numbers?"

let rec sum'' list =
  if List.isEmpty list then
    0
  else
    (List.head list) + sum'' (List.tail list)

let rec sum list =
  match list with
  | []        -> 0
  | x :: rest -> x + sum rest  // in reality, use tail recursion or fold

let rec select' f xs =
  match xs with
  | [] -> []
  | x :: rest -> (f x) :: select' f rest

let rec selectMany' f xs =
  match xs with
  | [] -> []
  | x :: rest -> (f x) @ selectMany' f rest

let customers =
  Map.ofList [
    (1, "Alice")
    (2, "Bob")
    (3, "Carol")
    (4, "Dave")
  ]

let customerNameOrDefault id defval =
  match Map.tryFind id customers with
  | Some name -> name
  | None      -> defval

let rec depth expr =
  match expr with
  | NumericLiteral _ -> 1
  | VariableRef _    -> 1
  | FunctionApplication (_, exprs)
      -> 1 + (exprs |> List.map depth |> List.max)
  | InfixApplication (_, lexpr, rexpr)
      -> 1 + max (depth lexpr) (depth rexpr)

let pythagoras { X = x; Y = y; Z = z } =
  Math.Sqrt (x * x + y * y + z * z)

let printElement' (dict : Dictionary<_, _>) key =
  let result = dict.TryGetValue(key)
  match result with
  | (true, value) -> printfn "%A" value
  | (false, _)    -> printfn "<missing>"

let printElement'' (dict : Dictionary<_, _>) key =
  let (found, value) = dict.TryGetValue(key)
  match found with
  | true  -> printfn "%A" value
  | false -> printfn "<missing>"

let printElement (dict : Dictionary<_, _>) key =
  match dict.TryGetValue(key) with
  | (true, value) -> printfn "%A" value
  | (false, _)    -> printfn "<missing>"

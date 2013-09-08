module PartialApplication

open Utils
open DiscriminatedUnions

let isEven n = n % 2 = 0
let isOdd = not << isEven

let testValues = [1;2;3;4]

// let (|>) x f = f x
let oddSquares = testValues
                 |> List.map square
                 |> List.filter isOdd

let getOdds xs = List.filter isOdd xs  // filter takes two args...
let getOdds' = List.filter isOdd       // ...but we're only passing one!

let incrementBy n x = n + x

let inced1 = List.map (fun x -> incrementBy 1 x) testValues
let inced2 = List.map (incrementBy 1) testValues

// See Infix project for more examples


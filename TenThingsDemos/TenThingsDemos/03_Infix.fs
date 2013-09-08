module Infix

open Utils

// Infix notation

let isEven n = n % 2 = 0
let isOdd = not << isEven
let isOdd' = isEven >> not

//let (|>) x f = f x
let isSquareRootOdd x = isOdd (int (sqrt x))
let isSquareRootOdd' x = x |> sqrt |> int |> isOdd

let squaresOfOdds xs = xs
                       |> List.filter isOdd
                       |> List.map (fun x -> x * x)


let product xs = List.reduce (*) xs

// Infix notation as DSL: FParsec - see Infix project

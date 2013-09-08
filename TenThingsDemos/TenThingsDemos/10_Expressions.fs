module Expressions

open System
open System.IO

let ifExpressionTest value =
  let abs = if value < 0 then -value else value
  printfn "%d" abs

let matchExpressionTest value =
  let trollText =
    match value with
    | 0 -> "none"
    | 1 -> "one"
    | 2 -> "some"
    | 3 -> "many"
    | _ -> "lots"
  printfn "%s" trollText

let exceptionExpressionTest() =
  let text =
    try
      File.ReadAllText(@"c:\temp\test.txt")
    with
      | :? FileNotFoundException -> String.Empty
  printfn "File contents: %s" text

let usingExpressionTest() =
  let lineCount =
    using (File.OpenRead(@"c:\temp\test.txt")) <| fun stream ->
      using (new StreamReader(stream)) <| fun reader ->
        reader.ReadToEnd().Split('\n').Length
  printfn "%d" lineCount

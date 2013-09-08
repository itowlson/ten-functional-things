open System
open Utils
open Expressions
open Infix
open PartialApplication

[<EntryPoint>]
let main argv =
  let exprText = "sum(a, 2 * b, 3)"
  let result = evalExprText exprText testEnv
  printfn "\r\nEXPR: %s" exprText
  printfn "\r\nRESULT: %d" result

//  printfn "\r\n%A" DateTime.Now
//  let results = runExprBad exprText lotsOfEnvs
//  printfn "%d" results.Length
//  printfn "%A" DateTime.Now

  Console.ReadKey() |> ignore
  0 // return an integer exit code

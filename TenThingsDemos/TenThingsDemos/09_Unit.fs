module Unit

open System

open Utils

let withExceptionLogging f =
  try f()
  with ex -> log(ex); reraise()

let i = 17

let getSqrt () = sqrt i                   // unit -> float
let sqrti = withExceptionLogging getSqrt

let writeSqrt () = printfn "%f" (sqrt i)  // unit -> unit
withExceptionLogging writeSqrt



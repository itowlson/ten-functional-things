module Utils

open System

let sqrt (i : int) =
  if i < 0 then invalidArg "i" "can't take square root of negative number"
  else Math.Sqrt(float(i))

let square x = x * x

let log (ex : Exception) = ()  // dummy


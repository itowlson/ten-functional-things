module Option

open System

open Immutable
open NonNullable

let parsePoint3D' (str : string) =
  let components = str.Split(',')
                   |> Array.map (fun s -> s.Trim())
                   |> Array.map (fun s -> Double.Parse(s))
  if components.Length = 3 then
    Some { X = components.[0]; Y = components.[1]; Z = components.[2] }  // Haskell Just
  else
    None  // Haskell Nothing

let visualisePoint' userText =
  let point = parsePoint3D' userText
  if point.IsNone then
    dopefishImage()
  else
    buildImage point.Value

let visualisePoint'' userText =
  match parsePoint3D' userText with
  | None       -> dopefishImage()
  | Some point -> buildImage point

let applyOrDefault option fsome fnone =
  match option with
  | None -> fnone ()
  | Some v -> fsome v

let visualisePoint''' userText =
  let point = parsePoint3D' userText
  applyOrDefault point buildImage dopefishImage


let parsePoint3D'' (str : string) =
  try
    let components = str.Split(',')
                    |> Array.map (fun s -> s.Trim())
                    |> Array.map (fun s -> Double.Parse(s))
    if components.Length = 3 then
      Choice2Of2 { X = components.[0]; Y = components.[1]; Z = components.[2] }  // Haskell Right
    else
      Choice1Of2 "incorrect number of values"  // Haskell Left
  with
  | ex -> Choice1Of2 (ex.Message)

let visualisePoint'''' userText =
  match parsePoint3D'' userText with
  | Choice1Of2 errText -> errorImage errText
  | Choice2Of2 point -> buildImage point


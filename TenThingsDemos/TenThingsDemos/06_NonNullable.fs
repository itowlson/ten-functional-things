module NonNullable

open System

open Immutable

let parsePoint3D (str : string) =
  let components = str.Split(',')
                   |> Array.map (fun s -> s.Trim())
                   |> Array.map (fun s -> Double.Parse(s))
  if components.Length = 3 then
    { X = components.[0]; Y = components.[1]; Z = components.[2] }
  else
    //null  // doesn't compile
    origin

let dopefishImage () =
  System.Drawing.Bitmap.FromFile(@"c:\temp\dopefish.jpg")
let errorImage errText : System.Drawing.Image =
  upcast new System.Drawing.Bitmap(1, 1)  // dummy
let buildImage (pt : Point3D) : System.Drawing.Image =
  upcast new System.Drawing.Bitmap(1, 1)  // dummy

let visualisePoint userText =
  let point = parsePoint3D userText
  //if point = null then  // doesn't compile - doesn't need to
  if point = origin then
    dopefishImage()
  else
    buildImage point


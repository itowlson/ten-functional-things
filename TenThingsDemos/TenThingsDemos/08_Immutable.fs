module Immutable

type Point3D = {
  X : float
  Y : float
  Z : float
}

let origin = { X = 0.0; Y = 0.0; Z = 0.0 }
let unitX = { X = 1.0; Y = 0.0; Z = 0.0 }

//unitX.X <- unitX.X - 1  // forbidden

let unitXMinus1 = { unitX with X = unitX.X - 1.0 }

// immutable variables too
let count = 0
//count <- count + 1
let mutable count' = 0
count' <- count' + 1

let extend { X = x; Y = y; Z = z } dx dy dz =
  { X = x * dx; Y = y + dy; Z = z + dz }

module BubblingUnder

// F# specials rather than common features of FP languages

open System
open System.Collections.Generic

// Object expressions

let roundingComparer (digits : int) = {
  new IEqualityComparer<Decimal> with
    member this.Equals(d1 : Decimal, d2 : Decimal) : bool =
      Decimal.Round(d1, digits) = Decimal.Round(d2, digits)
    member this.GetHashCode(d : Decimal) = Decimal.Round(d, digits).GetHashCode()
  }

// Triple-quoted strings

let scareQuotes = """Hello, so-called "world"!!!"""

// Units of measure

[<Measure>] type m;
[<Measure>] type ft;
[<Measure>] type s;

let c = 299792458.0<m/s>;
let distanceToChemist = 150.0<m>;
let timeItTakesLightToGetToChemist = distanceToChemist / c;

let socketSize = 0.12<m>;
let plugSize = 0.11<ft>;
//let clearance = socketSize - plugSize;  // error!





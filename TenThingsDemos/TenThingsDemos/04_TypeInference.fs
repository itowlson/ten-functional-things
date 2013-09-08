module TypeInference

open System.Collections.Generic

let select f xs =
  [ for x in xs -> f x ]
let selectMany f xs =
  [ for x in xs do yield! f x ]

let printElement (dict : Dictionary<_, _>) key =
  let result = dict.TryGetValue(key)
  if fst result then  // better way to follow!
    printfn "%A" (snd result)
  else
    printfn "<missing>"


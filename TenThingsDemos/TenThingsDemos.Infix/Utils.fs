module Utils

let makeEnv vars =
  let m = Map.ofList vars
  fun name ->
    match Map.tryFind name m with
    | Some value -> value
    | None       -> failwith ("unknown variable " + name)

let testEnv = makeEnv [("a", 1); ("b", 2)]

let functions =
  Map.ofList [
    ("factorial", fun args -> List.reduce (*) [1 .. List.head args])
    ("sum", fun args -> List.sum args)
    ("sqr", fun args -> (List.head args) * (List.head args))
  ]

let operators =
  Map.ofList [
    ("+", (+))
    ("-", (-))
    ("*", (*))
    ("/", (/))
  ]


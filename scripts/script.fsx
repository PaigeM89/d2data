#r "nuget: FSharp.Data"
open FSharp.Data
open System

// let sourceDir = __SOURCE_DIRECTORY__

// let runesPath = System.IO.Path.Combine(sourceDir, "..", "json/runes.json")

// let fileContents = System.IO.File.ReadAllText runesPath

//printfn "Runes path is: '%s'" runesPath

[<Literal>]
let directPath = "/Users/maxpaige/git/personal/d2data/scripts/../cleaned-json/runes.json"

type Runewords = JsonProvider<directPath, SampleIsList = true>

let hasValue (s : string option) =
    s
    // ""/null -> true |> not = false
    |> Option.map (fun x -> String.IsNullOrWhiteSpace x |> not)
    |> Option.defaultValue false

let notComplete (oi : int option) = 
    let v = Option.defaultValue 0 oi
    v = 0

for item in Runewords.GetSamples() do
    if item.RuneName |> hasValue && item.Complete |> notComplete then printfn "Name: %A. Complete: %A" item.RuneName item.Complete

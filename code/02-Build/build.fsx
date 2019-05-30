#r "paket: groupref Build //"
#load "./fake-helper.fsx"

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

Target.create "Default" (fun _ ->
  Trace.trace "Hello World from FAKE"
)

Target.create "Clean" (fun _ ->
    !! "hello/**/bin"
    ++ "hello/**/obj"
    |> Shell.cleanDirs
)

Target.create "Build" (fun _ ->
    !! "hello/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "All" ignore

"Default"
  ==> "Clean"
  ==> "Build"
  ==> "All"

Target.runOrDefaultWithArguments "Default"

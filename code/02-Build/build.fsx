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

// Recent FAKE change - initializing environment before any targets
Target.initEnvironment()
// Get build configuration from the environment
let buildConfigutation = DotNet.BuildConfiguration.fromEnvironVarOrDefault "BuildConfiguration" DotNet.BuildConfiguration.Debug

Target.create "Build" (fun _ ->
    !! "hello/**/*.*proj"
    |> Seq.iter (DotNet.build (fun b -> { b with Configuration = buildConfigutation }))
)

Target.create "All" ignore

"Default"
  ==> "Clean"
  ==> "Build"
  ==> "All"

Target.runOrDefault "Default"

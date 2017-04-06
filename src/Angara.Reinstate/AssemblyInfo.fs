﻿namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Angara.Reinstate")>]
[<assembly: AssemblyProductAttribute("Angara")>]
[<assembly: AssemblyDescriptionAttribute("The modelling environment")>]
[<assembly: AssemblyVersionAttribute("0.2.6")>]
[<assembly: AssemblyFileVersionAttribute("0.2.6")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.2.6"
    let [<Literal>] InformationalVersion = "0.2.6"

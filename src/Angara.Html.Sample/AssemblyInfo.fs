namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("Angara.Html.Sample")>]
[<assembly: AssemblyProductAttribute("Angara")>]
[<assembly: AssemblyDescriptionAttribute("The modelling environment")>]
[<assembly: AssemblyVersionAttribute("0.2.5")>]
[<assembly: AssemblyFileVersionAttribute("0.2.5")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.2.5"
    let [<Literal>] InformationalVersion = "0.2.5"

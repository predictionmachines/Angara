﻿module Angara.Html

open System.IO
open Angara.Serialization
open Angara.HtmlSerializers


let internal xa = System.Reflection.Assembly.GetExecutingAssembly()

let internal unwrapWebFolder (targetDir : string) : string = 
    let dir = Path.Combine(targetDir, ".Web")
    use webZipStream = "web.zip" |> xa.GetManifestResourceStream
    use webZip = Ionic.Zip.ZipFile.Read(webZipStream)
    webZip.ExtractAll(dir, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
    dir

let internal prepareHtml (path : string) (content : string) = 
    let replace (placeholder : string) (content : string) (snippet : string) = snippet.Replace(placeholder, content)
    
    let snippet = 
        use src = "index.cshtml" |> xa.GetManifestResourceStream
        use reader = new StreamReader(src)
        reader.ReadToEnd()
    
    let title = Path.GetFileNameWithoutExtension(path)
    let page = snippet |> replace "@Title" title |> replace "@Content" content
    File.WriteAllText(path, page)


/// The library to be filled dynamically with serializers of types for which there are viewers (e.g. Table, Chart).
let Serializers = Angara.Serialization.SerializerLibrary("Html")
/// Keeps a serializer for any object when its public properties are serialized.
let internal RecordSerializer = Angara.Serialization.SerializerLibrary()

/// The last item of the composition must be the RecordSerializer for it is a fallback serializer if none of others is suitable.
let internal UIResolver = SerializerCompositeResolver([ Angara.Serialization.CoreSerializerResolver.Instance; AssignableSerializerResolver(Serializers); AssignableSerializerResolver(RecordSerializer) ])

/// <summary>Generates an HTML page that displays the given object.</summary>
/// <param name="fileName">A file name to save the HTML page.</param>
/// <param name="artefact">An object to display.</param>
let Save (fileName : string) (artefact : obj) = 
    let targetDir = Path.GetDirectoryName fileName
    let infoSet = Angara.Serialization.ArtefactSerializer.Serialize UIResolver artefact
    let json = Angara.Serialization.Json.Marshal(infoSet, None)
    let content = json.ToString(Newtonsoft.Json.Formatting.Indented)       
    let webDir = unwrapWebFolder targetDir
    prepareHtml fileName content
    ()

/// <summary>Generates an HTML page that displays a value previously stored using
/// <see cref="Angara.ReinstateServices.Reinstate">Angara.ReinstateServices.Reinstate</see> method.</summary>
/// <param name="path">A folder that was provided to the Reinstate method call.</param>
let Make (path:string) = 
    let value = Angara.ReinstateServices.Reinstate<obj> path (fun () -> failwith "Cannot reinstate a value from the storage")
    let lastChar = path.Chars(path.Length-1)
    let fileName = (if lastChar = Path.DirectorySeparatorChar || lastChar = Path.AltDirectorySeparatorChar then path.Substring(0, path.Length-1) else path) + ".html";
    Save fileName value


do 
    RecordSerializer.Register(Angara.HtmlSerializers.RecordViewSerializer())

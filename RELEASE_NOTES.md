## 0.2.6 - April 6, 2017

* Table Viewer works in embeddable mode.
* Uses IDD 1.5.1 (IDD is taken from cdnjs).

#### 0.2.5 - October 19, 2016

* Uses IDD 1.4.3 and Newtonsoft.Json 9.0.1.

#### 0.2.4 - July 21, 2016

* Uses IDD 1.4.


#### 0.2.3 - July 21, 2016

* `Angara.Html.Console` allows to dynamically display objects in a browser.
* Uses IDD 1.3.

#### 0.2.2 - April 26, 2016

* Uses InteractiveDataDisplay v1.2.x with updated UI.

#### 0.2.1 - April 20, 2016

* Target framework is .NET 4.5.2
* Uses Angara.Table 0.2.1, Angara.Chart 0.2.0 and Angara.Serialization 0.2.0

Bug fixes:
* Serialization of a complex structure (e.g. a Table instance) as a record (i.e. using the general object serializer) for HTML caused StackOverflowException.

#### 0.1.5 - March 24, 2016

* Uses recent version of angara.tablejs (v0.1.1).

#### 0.1.4 - March 24, 2016

Features:
* The repository exposes a bower component `Angara.Html` which includes basic scripts
required by HTML code produced by `Angara.Html.MakeEmbeddable`. 
* `Angara.Html.MakeEmbeddable` doesn't require `origin` parameter and the produced HTML code 
uses github as cdn for Angara scripts. 
* Angara.Html supports for `Angara.Data.Table` type.
* `Angara.Base.Init()` registers serializers of the `Angara.Table` package as well.

Fixes:
* Bower for Angara.Html has explicit resolution for `jquery` to version 2.1.4.

#### 0.1.3 - March 18, 2016

* New method `Angara.Html.MakeEmbeddable` which generates HTML text displaying the object given
as the argument. The HTML text loads all required resources from an origin CDN and can be
embedded to an HTML page without any additional files required.
* Nuget package Angara.Base depends on Angara.Statistics.

#### 0.1.2 - February 19, 2016

Features:
* `Angara.Html.Save()` for an unregistered object checks whether it implements `IEnumerable` or `IDictionary` interfaces and serializes their contents as well.
* Build process of Angara.Html is improved. 

Refactoring:
* `Angara.Html.UISerializers` is now `Angara.Html.Serializers`.

Bug fix:
* `Angara.Html.Save()` allows to save objects with indexing properties.

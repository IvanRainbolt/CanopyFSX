#r "packages/NETStandard.Library/build/netstandard2.0/ref/netstandard.dll"
open canopy.csharp
#r "packages/Selenium.WebDriver/lib/netstandard2.0/WebDriver.dll"
#r "packages/canopy/lib/netstandard2.0/canopy.dll"

open System
open canopy.classic
open OpenQA.Selenium

///////////////////////////////////////
/// HELPERS
///////////////////////////////////////
module ReadOnly =
    let ofSeq<'a> (ss: 'a seq) = (ResizeArray ss).AsReadOnly()
    let ofList<'a> (ls: 'a list) = (ResizeArray ls).AsReadOnly()
    let ofArray<'a> (arr: 'a array) = (ResizeArray arr).AsReadOnly()
    let empty<'a> () = (ResizeArray []).AsReadOnly()
    let init<'a> length initializer = (ResizeArray (List.init length initializer)).AsReadOnly()
    let toSeq<'a> (collection: Collections.ObjectModel.ReadOnlyCollection<'a>) = seq { for i in collection do yield i } 
    let toList<'a> collection = collection |> toSeq |> List.ofSeq
    let toArray<'a> collection = collection |> toSeq |> List.ofSeq

let elText (el:IWebElement) = el.Text

// Allows finding by name using `q` instead of `[name=q]`
let findByName (name:string) (f:By -> Collections.ObjectModel.ReadOnlyCollection<IWebElement>) (_ : IWebDriver) =
    try
        f(By.Name(name)) |> ReadOnly.toList
    with | ex -> []

addFinder findByName

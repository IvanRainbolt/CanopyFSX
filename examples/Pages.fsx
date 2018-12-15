#r "packages/Selenium.WebDriver/lib/netstandard2.0/WebDriver.dll"
#r "packages/canopy/lib/netstandard2.0/canopy.dll"
#load "CanopyHelpers.fsx"

open canopy.classic
open OpenQA.Selenium
open CanopyHelpers

type SearchResult = {
    Title:string
    Description:string
    El:IWebElement
}

module SearchResult =
    let fromEl el =
        let title = el |> elementWithin "h3" |> elText
        let desc = el |> elementWithin ".st" |> elText
        {
            Title = title
            Description = desc
            El = el
        }

    let click sr = sr.El |> elementWithin "h3" |> fun el -> el.Click()    

module GooglePage =

    let uri = "https://google.com/"
    let goto () = url uri
    let searchFor term = 
        "q" << term
        press enter

module SearchResultPage =

    let results () =
        (List.collect (fun el -> elementsWithin ".g" el) (elements ".srg"))// collect needed because .srg is sometimes split across multipe elements
        |> List.map SearchResult.fromEl
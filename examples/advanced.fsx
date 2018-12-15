//#r "packages/NETStandard.Library/build/netstandard2.0/ref/netstandard.dll"
#r "packages/Selenium.WebDriver/lib/netstandard2.0/WebDriver.dll"
#r "packages/canopy/lib/netstandard2.0/canopy.dll"
#load "Pages.fsx"

open canopy.classic
open canopy.configuration
open canopy.types
open Pages

chromeDir <- "C:\\tools\\selenium\\"
start chrome
pin FullScreen

let term = "bob"

GooglePage.goto()
GooglePage.searchFor term
let results = SearchResultPage.results()

// print result count
results
|> List.length
|> printfn "Result count for '%s' is %i" term

//click first result
results
|> List.head
|> SearchResult.click
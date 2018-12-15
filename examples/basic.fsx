#r "packages/Selenium.WebDriver/lib/netstandard2.0/WebDriver.dll"
#r "packages/canopy/lib/netstandard2.0/canopy.dll"

open canopy.classic
open canopy.configuration
open canopy.types

chromeDir <- "C:\\tools\\selenium\\"
start chrome
pin FullScreen

url "https://google.com/"

"[name=q]" << "Youtube: BGF Red and Blue"
press enter
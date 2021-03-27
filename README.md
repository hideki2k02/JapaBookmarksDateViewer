# JapaBookmarksDateViewer

## Needs .NET Core 5.0
## Program uses [HtmlAgilityPack v 1.11.32 by zzzprojects](https://html-agility-pack.net/)

 A simple C# tool built to View the Date of an Bookmarks Export.

 This program was originally on Japa's Unified Test Program v4 (My Test Toolkit)

 Then i decided to rewrite it since the code was pretty garbage, then post it here (Open-Source)
 
 ## Screenshot of what the program does
![image](https://user-images.githubusercontent.com/5614680/112727832-1383a300-8f03-11eb-9b44-160c580b5edf.png)


## Why you should use this program
- This program should be used (even if only once) if you are trying to figure out precisely when something was added to your bookmark

- Chromium Browsers (like Chrome and Brave; so far i've only tested in Chromium Browsers) save the Bookmark's date as a [UNIX Time](https://en.wikipedia.org/wiki/Unix_time) but for some reason the End-User cant access it normally if he doesnt have the knowledge to do so.

- This program as previously stated, will help you to find this pesky little [UNIX Time](https://en.wikipedia.org/wiki/Unix_time) and convert it to [UTC](https://en.wikipedia.org/wiki/Coordinated_Universal_Time).

- It is also Open-Source, so you can be sure i wont be seeing whats in your Homework folder ;)

## How to use
Its easy as 1, 2, 3. Just follow the instructions below

In case you dont know how to export your Bookmarks as HTML, check [this page](https://www.wikihow.com/Export-Bookmarks-from-Chrome)

- Download the pre-built program on the [Releases page](https://github.com/japa4551/JapaBookmarksDateViewer/releases) (You can also build it yourself if you want to or if there is no version for your current system)

- Drag and drop the Exported HTML in the Program's executable (or just leave a HTML file in the same place as the Executable) then launch the program

- The program will attempt to read the file, if it succeeds it will save the output on the executable's path as "input_file_name_output.txt" (Example: favoritos_26_03_2021_output.txt)

- You can also use multiple HTML files by placing them in the Program's Folder or by running the program on Terminal with multiple parameters (Program.exe file1.html file2.html)

## Random facts
- Previously before release, you had to manually enter the Input file's name (with extension) and path to make it work

- If any data on the Input was incorrect, the program would crash

- The program also was one file at the time before the rework

- I don't know how to make GitHub pages properly, so it will contain literally everything of this project (including Debug Builds)

- Some interesting things can happen if the program reads an file that its not meant to read
![image](https://user-images.githubusercontent.com/5614680/112727762-cbfd1700-8f02-11eb-9a5b-0834e4dfe576.png)

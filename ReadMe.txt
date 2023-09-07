  MyCompany.BookManagement.BookManager

Design consideration:
Application type – Console, but the design is such a way that tomorrow another type can be introduced with ease (web, windows, mobile etc)

Assumptions:
•	We will assume a simplified approach to calculate word counts and character statistics. For example, we will treat a word as a sequence of non-space characters, and we'll consider punctuation as part of the word (e.g., "word." is one word).
•	We will use a basic approach for finding common word groupings, such as extracting consecutive words from the text.
•	For searching, we'll implement a simple keyword-based search.
•	We'll provide basic functionality for counting word frequency.

Tools Used:
•	Visual Studio or Visual Studio Code (for C# development).
•	.NET 6 framework and building application.
•	Configuration: appsettings.json

Note: 
Improvements are listed as TODOs inline in the code


Unit testing is not added but can be done, please let me know.

using System;
using System.Runtime.Intrinsics.X86;
using MyCompany.BookManagement.Repository.File;
using MyCompany.BookManagement.Service;

namespace MyCompany.BookManagement.ConsoleApp
{
    /// <summary>
    /// Main program. Console App
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //TODO: Use dependency framework here
            var bookRepository = new FileBookRepository();
            var textAnalyzer = new TextAnalyzer();
            var bookService = new BookService(bookRepository, textAnalyzer);

            Console.WriteLine("Choose a persona to simulate:");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Researcher");
            Console.WriteLine("4. Business Analyst");
            Console.WriteLine("5. Exit");

            while (true)
            {
                Console.Write("Enter your choice (1-5): ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {

                   // Can use factory pattern if complexity increases
                    if (choice == 5)
                    {
                        break; // Exit the program
                    }
                    else if (choice >= 1 && choice <= 4)
                    {
                        var books = bookService.GetAllBooks();
                        Console.WriteLine("Select a book to analyze:");
                        for (int i = 0; i < books.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {books[i].Title}");
                        }

                        Console.Write("Enter the book number: ");
                        if (int.TryParse(Console.ReadLine(), out int bookNumber) && bookNumber >= 1 && bookNumber <= books.Count)
                        {
                            var selectedBook = books[bookNumber - 1];

                            switch (choice)
                            {
                                case 1: // Librarian Persona
                                    Console.WriteLine($"Number of pages: {selectedBook.Text.Length / 250}");
                                    break;
                                case 2: // Student Persona
                                    Console.WriteLine("Select an action:");
                                    Console.WriteLine("1. Word and Character Statistics");
                                    Console.WriteLine("2. Search");
                                    Console.Write("Enter your choice (1-2): ");
                                    if (int.TryParse(Console.ReadLine(), out int studentChoice) && studentChoice >= 1 && studentChoice <= 2)
                                    {
                                        if (studentChoice == 1)
                                        {
                                            var stats = bookService.CalculateCharacterStatistics(selectedBook.Text);
                                            Console.WriteLine($"Word and character statistics:");
                                            Console.WriteLine($"Total Characters: {stats.TotalCharacters}, Letters: {stats.Letters}, Digits: {stats.Digits}, Words: {stats.Words}");
                                        }
                                        else
                                        {
                                            Console.Write("Enter a keyword to search: ");
                                            string searchKeyword = Console.ReadLine();
                                            var searchResults = bookService.Search(selectedBook.Text, searchKeyword);
                                            Console.WriteLine($"Search results for '{searchKeyword}':");
                                            foreach (var result in searchResults)
                                            {
                                                Console.WriteLine(result);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                                    }
                                    break;
                                case 3: // Researcher Persona
                                    var commonWordGroupings = bookService.FindCommonWordGroupings(selectedBook.Text, 2);
                                    Console.WriteLine($"Common word groupings: {string.Join(", ", commonWordGroupings)}");
                                    break;
                                case 4: // Business Analyst Persona
                                    var words = bookService.FindMostUsedWords(selectedBook.Text, 10);
                                    Console.WriteLine($"Top 10 most used words: {string.Join(", ", words)}");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid book number. Please enter a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}


using Microsoft.Extensions.Configuration;
using MyCompany.BookManagement.Domain;
using MyCompany.BookManagement.Repository.Api;

namespace MyCompany.BookManagement.Repository.File
{
    public class FileBookRepository : IBookRepository
    {
        private readonly string folderName = string.Empty;

        public FileBookRepository()
        {
            //TODO: Refactor and introduce configuration domain service

            IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

            folderName = configuration["FolderName"];


            // Construct the full path to the subfolder in the bin folder
            string subfolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);


            // Check if the folderPath is null or empty
            if (string.IsNullOrEmpty(folderName))
            {
                Console.WriteLine("The 'BookFolder' setting is missing or empty in appsettings.json.");
                return;
            }

        }

  
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAll()
        {
            // loading all books from the folder
            var bookFiles = Directory.GetFiles(folderName, "*.txt");
            var books = new List<Book>();
            foreach (var bookFile in bookFiles)
            {
                string text = System.IO.File.ReadAllText(bookFile);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(bookFile);
                books.Add(new Book(fileNameWithoutExtension, "Unknown Author", text));
            }
            return books;
        }

    }
}
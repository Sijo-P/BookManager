namespace MyCompany.BookManagement.Domain
{
    /// <summary>
    /// Book domain
    /// </summary>
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Text { get; private set; }

        /// <summary>
        /// Constrctor
        /// </summary>
        /// <param name="title">The book title</param>
        /// <param name="author">The author</param>
        /// <param name="text">The content of the book</param>
        public Book(string title, string author, string text)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Text = text;
        }


    }
}
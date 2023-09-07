using MyCompany.BookManagement.Domain;

namespace MyCompany.BookManagement.Repository.Api
{
    public interface IBookRepository
    {

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        List<Book> GetAll();
      

    }
}
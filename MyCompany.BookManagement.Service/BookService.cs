using MyCompany.BookManagement.Domain;
using MyCompany.BookManagement.Domain.Api;
using MyCompany.BookManagement.Repository.Api;
using System.Text.RegularExpressions;

namespace MyCompany.BookManagement.Service
{
    /// <summary>
    /// Book managment service
    /// </summary>
    public class BookService 
    {
        private readonly IBookRepository _bookRepository;
        private readonly ITextAnalyzer _textAnalyzer;
        public BookService(IBookRepository bookRepository, ITextAnalyzer _textAnalyze)
        {
            _bookRepository = bookRepository;
            _textAnalyzer = _textAnalyze;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }


        /// <summary>
        /// Find CommonWord Groupings
        /// </summary>
        /// <param name="text"></param>
        /// <param name="groupingSize"></param>
        /// <returns></returns>
        public List<string> FindCommonWordGroupings(string text, int groupingSize)
        {
            return _textAnalyzer.FindCommonWordGroupings(text, groupingSize);
        }

        /// <summary>
        /// Calculate Character Statistics
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public CharacterStatistics CalculateCharacterStatistics(string text)
        {
            return _textAnalyzer.CalculateCharacterStatistics(text);

        }

        /// <summary>
        /// Search a word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<string> Search(string text, string keyword)
        {
            return _textAnalyzer.Search(text, keyword);
        }

        /// <summary>
        /// Find Most Used Words
        /// </summary>
        /// <param name="text"></param>
        /// <param name="topN"></param>
        /// <returns></returns>

        public List<string> FindMostUsedWords(string text, int topN)
        {
            return _textAnalyzer.FindMostUsedWords(text, topN);
        }


    }
}
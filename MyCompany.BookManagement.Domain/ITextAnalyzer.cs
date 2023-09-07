using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.BookManagement.Domain.Api
{
    /// <summary>
    /// Text analyzer
    /// </summary>
    public interface ITextAnalyzer
    {
        /// <summary>
        /// Calculate Character Statistics
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        CharacterStatistics CalculateCharacterStatistics(string text);

        /// <summary>
        /// Find CommonWord Groupings
        /// </summary>
        /// <param name="text"></param>
        /// <param name="groupingSize"></param>
        /// <returns></returns>
        List<string> FindCommonWordGroupings(string text, int groupingSize);

        /// <summary>
        /// Find Most Used Words
        /// </summary>
        /// <param name="text"></param>
        /// <param name="topN"></param>
        /// <returns></returns>
        List<string> FindMostUsedWords(string text, int topN);

        /// <summary>
        /// Search a word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        List<string> Search(string text, string keyword);
    }
}

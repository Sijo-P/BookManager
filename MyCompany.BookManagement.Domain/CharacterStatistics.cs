using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.BookManagement.Domain
{
    /// <summary>
    /// Character Statistics
    /// </summary>
    public class CharacterStatistics
    {
        public int TotalCharacters { get; private set; }
        public int Letters { get; private set; }
        public int Digits { get; private set; }
        public int Words { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="totalCharacters">The total char count</param>
        /// <param name="letters">The total letter count</param>
        /// <param name="digits">The total digit count</param>
        /// <param name="words">The total word count</param>
        public CharacterStatistics(int totalCharacters, int letters, int digits, int words)
        {
            TotalCharacters = totalCharacters;
            Letters = letters;
            Digits = digits;
            Words = words;
        }
    }
}

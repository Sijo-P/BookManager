using MyCompany.BookManagement.Domain;
using MyCompany.BookManagement.Domain.Api;
using System.Text.RegularExpressions;

namespace MyCompany.BookManagement.Service
{
    /// <summary>
    /// Text analyser implementation
    /// </summary>
    public class TextAnalyzer:ITextAnalyzer
    {
        public List<string> FindCommonWordGroupings(string text, int groupingSize)
        {
            // Split the text into words
            var words = Regex.Split(text, @"\s+");

            // Create word groupings of the specified size
            var wordGroupings = new List<List<string>>();
            for (int i = 0; i <= words.Length - groupingSize; i++)
            {
                var grouping = words.Skip(i).Take(groupingSize).ToList();
                wordGroupings.Add(grouping);
            }

            // Find common word groupings (2 or more occurrences)
            var commonGroupings = wordGroupings
                .GroupBy(grouping => string.Join(" ", grouping))
                .Where(group => group.Count() >= 2)
                .Select(group => group.Key)
                .ToList();

            return commonGroupings;
        }

        public CharacterStatistics CalculateCharacterStatistics(string text)
        {
            // Calculate character statistics
            int totalCharacters = text.Length;
            int letters = text.Count(char.IsLetter);
            int digits = text.Count(char.IsDigit);

            // Define the word delimiters (whitespace and punctuation marks)
            char[] delimiters = new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;


            return new CharacterStatistics(totalCharacters, letters, digits, wordCount) { };

        }

        public List<string> Search(string text, string keyword)
        {
            // Split the text into sentences
            var sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Find sentences containing the keyword
            var searchResults = sentences
                .Where(sentence => sentence.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return searchResults;
        }

        public List<string> FindMostUsedWords(string text, int topN)
        {
            // Split the text into words
            var words = Regex.Split(text, @"\s+");

            // Group and count word occurrences
            var wordCounts = words
                .GroupBy(word => word.ToLower())
                .OrderByDescending(group => group.Count())
                .Take(topN)
                .Select(group => group.Key)
                .ToList();

            return wordCounts;
        }
    }
}

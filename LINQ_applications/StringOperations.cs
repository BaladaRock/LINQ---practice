using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class StringOperations
    {
        public static int ConvertToInteger(string word)
        {
            ThrowNullException(word);

            return word.Aggregate(0, (totalNumber, currentChar) => totalNumber + currentChar);
        }

        public static char FirstUniqueCharacter(string word)
        {
            ThrowNullException(word);

            foreach (var grouping in word.GroupBy(x => x))
            {
                if (grouping.Count() == 1)
                {
                    return grouping.Key;
                }
            }

            throw new InvalidOperationException("No unique character was found!/t");
        }

        public static IEnumerable<string> GeneratePalindroms(string word)
        {
            ThrowNullException(word);

            bool flag = IsPalindrom("ab ba");
            var palindrom = word.GroupBy(x => x);
            return new[] { "" };
        }

        public static char MostAparitionsChar(string word)
        {
            ThrowNullException(word);

            char result = ' ';
            int maxApparitions = 0;
            foreach (var grouping in word.GroupBy(x => x))
            {
                int count = grouping.Count();
                if (count > maxApparitions)
                {
                    maxApparitions = count;
                    result = grouping.Key;
                }
            }

            return result;
        }

        public static (int vocals, int consonants) VocalsAndConsonants(string word)
        {
            ThrowNullException(word);

            return word.Aggregate((0, 0), (tuplure, currentLetter)
                => "AEIOUaeiou".Contains(currentLetter)
                ? (tuplure.Item1 + 1, tuplure.Item2)
                : (tuplure.Item1, tuplure.Item2 + 1));
        }

        private static bool IsPalindrom(string word)
        {
            int halfWord = word.Length / 2;
            string firstHalf = word.Substring(0, halfWord);
            IEnumerable<char> reversedSecondHalf = word.Substring(halfWord + 1, halfWord).Reverse();

            return firstHalf.Equals(reversedSecondHalf);
        }

        private static void ThrowNullException(string word)
        {
            if (word != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(word));
        }

        private string GetPalindromHalf(string initialWord, int startPosition, int finishPosition)
        {
            return "";
        }
    }
}
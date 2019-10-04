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

        public static int CountConsonants(string word)
        {
            ThrowNullException(word);

            return word.Count() - CountVocals(word);
        }

        public static int CountVocals(string word)
        {
            return word.Intersect("AEIOUaeiou").Count();
        }

        public static char FirstUniqueCharacter(string word)
        {
            ThrowNullException(word);

            return GroupCharacters(word).Select(x => x).First((y) => y.Count() == 1).First();
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

            return word.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(g => g.Key)
                .First();
        }

        private static IEnumerable<string> GroupCharacters(string word)
        {
            return word.GroupBy(x => x, (x, enumerable) => string.Join("", enumerable));
        }

        private static bool IsPalindrom(string word)
        {
            int wordLength = word.Length;
            int halfWord = wordLength / 2;

            if (wordLength == 1 || wordLength % 2 == 0)
            {
                return false;
            }

            return word.Substring(0, halfWord).Equals(word.Substring(wordLength - 1, halfWord));
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
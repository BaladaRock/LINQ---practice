using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class StringOperations
    {
        public static int ConvertStringToInt(string word)
        {
            ThrowNullException(word);

            return ConvertToInt(word);
        }

        public static char FirstUniqueCharacter(string word)
        {
            ThrowNullException(word);

            return word.GroupBy(x => x)
                .First(x => x.Count() == 1)
                .Key;
        }

        public static IEnumerable<string> GeneratePalindroms(string word)
        {
            ThrowNullException(word);

            return word.SelectMany(
                (_, index) =>
                word
                    .Substring(index)
                    .Select((x, secondIndex) => word.Substring(index, word.Length - secondIndex - index)))
               .Where(x => IsPalindrom(x));
        }

        public static char MostAparitionsChar(string word)
        {
            ThrowNullException(word);

            return word.GroupBy(x => x)
                .Aggregate((occurencies, currentElement) =>
                currentElement.Count() > occurencies.Count()
                ? currentElement
                : occurencies).Key;
        }

        public static (int vocals, int consonants) VocalsAndConsonants(string word)
        {
            ThrowNullException(word);

            return word.Aggregate((0, 0), (tuplure, currentLetter) =>
                "AEIOUaeiou".Contains(currentLetter)
                ? (tuplure.Item1 + 1, tuplure.Item2)
                : (tuplure.Item1, tuplure.Item2 + 1));
        }

        private static int ConvertDigitToInt(char letter, string source)
        {
            if (IsDigit(letter))
            {
                return letter - '0';
            }

            throw new FormatException("String does not meet Int32 requirements");
        }

        private static int ConvertToInt(string word)
        {
            const int positionPower = 10;
            string newWord = RemoveExtraCharacters(word);

            return newWord.Aggregate(0, (sum, currentDigit) =>
                    sum * positionPower + ConvertDigitToInt(currentDigit, newWord));
        }

        private static bool IsDigit(char digit)
        {
            return digit >= '0' && digit <= '9';
        }

        private static bool IsPalindrom(string word)
        {
            return word.Take(word.Length).ToString() == word.Reverse().ToString();
        }

        private static string RemoveExtraCharacters(string word)
        {
            if (word.First() == ' ' || word.Last() == ' ')
            {
                word = word.Trim();
            }

            return "+-".Contains(word.First())
                ? word.Substring(1)
                : word;
        }

        private static void ThrowNullException(string word)
        {
            if (word != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(word));
        }
    }
}
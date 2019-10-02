using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_applications
{
    public class StringOperations
    {
        public static int CountVocals(string word)
        {
            return word.Intersect("AEIOUaeiou").Count();
        }

        public static int CountConsonants(string word)
        {
            ThrowNullException(word);

            return word.Count() - CountVocals(word);
        }

        public static char FirstUniqueCharacter(string word)
        {
            ThrowNullException(word);

            var uniqueCharacters = word.Distinct();
            return uniqueCharacters.First();
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

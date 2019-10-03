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

            var characters = word.GroupBy(x => x, (x, enumerable) => string.Join("", enumerable));
            return characters.Select(x => x).First((y) => y.Count() == 1).First();
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

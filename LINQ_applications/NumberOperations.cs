using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class NumberOperations
    {
        public static IEnumerable<IEnumerable<int>> GenerateSubsets(int[] array, int maxSum = int.MinValue)
        {
            ThrowNullException(array);

            return array.SelectMany((_, startPos) => GetSubSet(array, startPos)
                                    .Select((number, secIndex)
                                    => GetSubSet(array, startPos, array.Length - secIndex - startPos)))
                        .Where(x => CheckSumOfElements(x, maxSum));
        }

        public static IEnumerable<IEnumerable<int>> GetPythagoreanNumbers(int[] array)
        {
            ThrowNullException(array);

            var triples = array.SelectMany((first, fstIndex) => array.Skip(fstIndex + 1)
                                          .SelectMany((sec, secIndex) => array.Skip(fstIndex + ++secIndex + 1)
                                                     .Select(third => new[] { first, sec, third })));

            return SelectPythagoreanCombinations(triples);
        }

        private static bool CheckSumOfElements(IEnumerable<int> array, int sum)
        {
            return array.Sum() <= sum;
        }

        private static IEnumerable<int> GetSubSet(IEnumerable<int> array, int startingPosition, int numbersToTake)
        {
            return GetSubSet(array, startingPosition).Take(numbersToTake);
        }

        private static IEnumerable<int> GetSubSet(IEnumerable<int> array, int startingPosition)
        {
            return array.Skip(startingPosition);
        }

        private static IEnumerable<IEnumerable<int>> SelectPythagoreanCombinations(IEnumerable<int[]> triples)
        {
            throw new NotImplementedException();
        }

        private static void ThrowNullException(IEnumerable<int> array)
        {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(array));
        }
    }
}
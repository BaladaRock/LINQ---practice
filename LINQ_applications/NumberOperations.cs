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

            return array.SelectMany((_, startingPosition) => GetSubSet(array, startingPosition)
                                    .Select((number, secondIndex)
                                    => GetSubSet(array, startingPosition, array.Length - secondIndex - startingPosition)))
                        .Where(x => CheckSumOfElements(x, maxSum));
        }

        public static IEnumerable<IEnumerable<int>> GetPythagoreanNumbers(int[] array)
        {
            ThrowNullException(array);

            return array.SelectMany((first, index) => array.Skip(index + 1)
                                   .Select(second => new[] { first, second }));
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
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

            return array.SelectMany(
                (start, finish) =>
                    GetSubSet(array, start, finish)
                    .Select((x, index) => GetSubSet(array, start, array.Length - index - start)))
               .Where(x => CheckSumOfElements(x, maxSum));
        }

        private static bool CheckSumOfElements(IEnumerable<int> array, int sum)
        {
            return array.Aggregate(0, (x, y) => x + y) <= sum;
        }

        private static IEnumerable<int> GetSubSet(IEnumerable<int> array, int startingPosition, int numbersToTake)
        {
            return array.Skip(startingPosition).Take(numbersToTake);
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

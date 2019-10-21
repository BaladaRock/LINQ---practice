using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class NumberOperations
    {
        public static IEnumerable<IEnumerable<int>> GenerateSubsets(IEnumerable<int> array, int maxSum = int.MinValue)
        {
            ThrowNullException(array);

            return array.SelectMany((_, startPos) => GetSubSet(array, startPos)
                                    .Select((number, secIndex)
                                    => GetSubSet(array, startPos, array.Count() - secIndex - startPos)))
                        .Where(x => CheckSumOfElements(x, maxSum));
        }

        public static IEnumerable<IEnumerable<int>> GetPythagoreanNumbers(IEnumerable<int> array)
        {
            ThrowNullException(array);

            return array.SelectMany((a, i) =>
            {
                var inner = array.Skip(i + 1);
                return inner.SelectMany((b, j) =>
                    inner.Skip(j + 1)
                        .SelectMany(c => GetTriplePermutations(a, b, c)));
            });
        }

        public static IEnumerable<IEnumerable<char>> GetSumCombinations(int maxNumber, int numberToCheck)
        {
            return null;
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

        private static IEnumerable<IEnumerable<int>> GetTriplePermutations(int first, int second, int third)
        {
            return PermuteElements(first, second, third)
                   .Where(x => IsTriplePythagorean(x.First(), x.ElementAt(1), x.Last()));
        }

        private static bool IsTriplePythagorean(int firstElement, int secondElement, int thirdElement)
        {
            return (firstElement * firstElement) + (secondElement * secondElement)
                     == thirdElement * thirdElement;
        }

        private static IEnumerable<IEnumerable<int>> MakeEnum(int first, int second, int third)
        {
            return new[]
            {
                new[] { first, second, third }, new[] { first, third, second },
                new[] { second, first, third }, new[] { second, third, first },
                new[] { third, first, second }, new[] { third, second, first }
            };
        }

        private static IEnumerable<IEnumerable<int>> PermuteElements(int first, int second, int third)
        {
            return first != second
                ? MakeEnum(first, second, third)
                : new[] { new[] { 0, 0, 0 } };
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
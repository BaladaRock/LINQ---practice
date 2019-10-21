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

            return array.SelectMany((first, fstIndex) => array.Skip(fstIndex + 1)
                                          .SelectMany((sec, secIndex) => array.Skip(fstIndex + ++secIndex + 1)
                                                     .SelectMany(third
                                                     => GetTriplePermutations(first, sec, third))));
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
            var elements = new List<int> { first, second, third };
            elements.Sort();

            if (!IsTriplePythagorean(elements[0], elements[1], elements.Last()))
            {
                return Enumerable.Empty<IEnumerable<int>>();
            }

            if (first == 0)
            {
                return new[] { new[] { first, second, third } };
            }

            if (third >= second && third >= first)
            {
                return MakeEnum(first, second, third);
            }

            return first >= second
                ? MakeEnum(second, third, first)
                : MakeEnum(first, third, second);
        }

        private static IEnumerable<IEnumerable<int>> MakeEnum(int first, int second, int third)
        {
            return new[] { new[] { first, second, third }, new[] { second, first, third } };
        }

        private static bool IsTriplePythagorean(int firstElement, int secondElement, int thirdElement)
        {
            return (firstElement * firstElement) + (secondElement * secondElement)
                     == thirdElement * thirdElement;
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
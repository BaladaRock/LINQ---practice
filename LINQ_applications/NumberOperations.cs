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
                                              .Select(third => new[] { first, sec, third })))
                        .SelectMany(combination => IsTriplePythagorean(combination)
                                              ? GetTriplePermutations(combination).Select(x => x)
                                              : combination);
        }

        private static bool IsTriplePythagorean(IEnumerable<int> triple)
        {
            int firstSquare = triple.First() * triple.First();
            int secondSquare = triple.ElementAt(1) * triple.ElementAt(1);
            int thirdSquare = triple.Last() * triple.Last();

            if (thirdSquare >= firstSquare && thirdSquare >= secondSquare)
            {
                return firstSquare + secondSquare == thirdSquare;
            }

            return firstSquare >= secondSquare
                ? firstSquare + thirdSquare == secondSquare
                : secondSquare + thirdSquare == firstSquare;
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

        private static IEnumerable<IEnumerable<int>> GetTriplePermutations(IEnumerable<int> triple)
        {
            int first = triple.First();
            int second = triple.ElementAt(1);
            int last = triple.Last();

            var elements = triple.ToList();
            elements.Sort();

            return last >= first
                ? new[] { new[] { first, second, last }, new[] { second, first, last } }
                : new[] { new[] { last, first, second }, new[] { last, second, first } };
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
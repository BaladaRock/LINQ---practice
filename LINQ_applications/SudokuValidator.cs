using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class SudokuValidator
    {
        private readonly byte[][] square;

        public SudokuValidator(byte[][] square)
        {
            this.square = square;
        }

        public bool CheckSudoku()
        {
            int count = square.Length;
            /*if (count != 9)
            {
                return false;
            }*/

            var columns = Enumerable.Range(0, count)
                .Select(index => square
                    .Select(col => col[index]));

            bool checkDigitsApparitions = !square.SelectMany(a => a.Select(b => Convert.ToInt32(b)))
                 .Except(Enumerable.Range(1, count)).Any();

            return CheckRepetitions(square) && CheckRepetitions(columns) && checkDigitsApparitions;
        }

        private bool CheckRepetitions(IEnumerable<IEnumerable<byte>> square)
        {
            return !square.SelectMany((a, _) =>
                            a.Select(b => b)
                                .GroupBy(x => x)).Any(y => y.Count() > 1);
        }
    }
}
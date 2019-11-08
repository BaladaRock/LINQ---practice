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
            if (count != 9)
            {
                return false;
            }

            var columns = Enumerable.Range(0, count)
                .Select(index => square
                    .Select(col => col[index]));

            bool checkDigitsApparitions = square.SelectMany(a => a.Select(b => Convert.ToInt32(b)))
                 .Except(Enumerable.Range(1, count)).Any();

            return !checkDigitsApparitions &&
                   CheckRepetitions(square, count) ||
                   CheckRepetitions(columns, count);
        }

        private bool CheckByteLine(IEnumerable<byte> line, int count)
        {
            bool elementsIntegrity = line.Select(_ => Convert.ToInt32(_))
                .Except(Enumerable.Range(1, count))
                .Any();

            return elementsIntegrity || line.Count() != line.Distinct().Count();
        }
    }
}
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

            if (count != 9 || square.Select(x => x)
                  .Any(y => !CheckByteLine(y, count)))
            {
                return false;
            }

            return CheckEnumerable("columns", count) && CheckEnumerable("blocks", count);
        }

        private bool CheckByteLine(IEnumerable<byte> line, int count)
        {
            bool elementsIntegrity = line.Select(x => Convert.ToInt32(x))
                .All(y => Enumerable.Range(1, count).Contains(y));

            return elementsIntegrity &&
                line.Count() == line.Distinct().Count();
        }

        private bool CheckEnumerable(string toCheck, int count)
        {
            var inner = Enumerable.Range(0, count).Select(index =>
            {
                return toCheck == "blocks"
                   ? GetInnerBlock(index / 3 * 3, index % 3 * 3)
                   : square.Select(col => col[index]);
            });

            return inner.All(y => CheckByteLine(y, count));
        }

        private IEnumerable<byte> GetInnerBlock(int lineIndex, int columnIndex)
        {
            return Enumerable.Range(lineIndex, 3)
                .SelectMany(x => Enumerable.Range(columnIndex, 3)
                     .Select(y => square[x][y]));
        }
    }
}
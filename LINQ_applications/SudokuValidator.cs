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

            bool checkBlocks = Enumerable.Range(0, count)
                .Select(index =>
                    GetInnerBlock((index / 3) * 3, (index % 3) * 3))
                    .All(y => CheckByteLine(y, count));

            bool checkColumns = Enumerable.Range(0, count)
                .Select(index => square
                        .Select(col => col[index]))
                   .All(y => CheckByteLine(y, count));

            bool checkLines = square.Select(x => x).All(y => CheckByteLine(y, count));

            return checkColumns && checkLines && checkBlocks;
        }

        private bool CheckByteLine(IEnumerable<byte> line, int count)
        {
            bool elementsIntegrity = !line.Select(_ => Convert.ToInt32(_))
                .Except(Enumerable.Range(1, count))
                .Any();

            return elementsIntegrity && line.Count() == line.Distinct().Count();
        }

        private IEnumerable<byte> GetInnerBlock(int lineIndex, int columnIndex)
        {
            return Enumerable.Range(lineIndex, 3)
                .SelectMany(x => Enumerable.Range(columnIndex, 3)
                     .Select(y => square[x][y]));
        }
    }
}
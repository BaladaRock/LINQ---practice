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
            int squareSize = (int)Math.Sqrt(count);
            var digits = Enumerable.Range(0, count);

            var lines = square.Select(x => x);
            var columns = digits
                .Select(index => square.Select(col => col[index]));
            var squares = digits
                .Select(index =>
                    GetInnerBlock(
                        index / squareSize * squareSize,
                        index % squareSize * squareSize,
                        squareSize));

            var all = lines
                .Concat(columns)
                .Concat(squares);

            return all.All(y => CheckByteLine(y, count));
        }

        private bool CheckByteLine(IEnumerable<byte> line, int count)
        {
            bool elementsIntegrity = line.Select(x => Convert.ToInt32(x))
                .All(y => Enumerable.Range(1, count).Contains(y));

            return elementsIntegrity &&
                line.Count() == line.Distinct().Count();
        }

        private IEnumerable<byte> GetInnerBlock(int lineIndex, int columnIndex, int count)
        {
            return Enumerable.Range(lineIndex, count)
                .SelectMany(x => Enumerable.Range(columnIndex, count)
                     .Select(y => square[x][y]));
        }
    }
}
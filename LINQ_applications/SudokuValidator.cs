using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class SudokuValidator
    {
        private readonly IEnumerable<IEnumerable<byte>> square;

        public SudokuValidator(IEnumerable<IEnumerable<byte>> square)
        {
            this.square = square;
        }

        public bool CheckSudoku()
        {
            return square.SelectMany((a, _) =>
                a.Select(b => b)
                    .GroupBy(x => x)).Max(y => y.Count()) == 1;
        }
    }
}
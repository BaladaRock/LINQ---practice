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
            return square.GroupBy(x => x).Count() == square.Count();
        }
    }
}
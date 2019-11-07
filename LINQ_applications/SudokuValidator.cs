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
            var checkDigitsApparitions = !square.SelectMany(a => a.Select(b => Convert.ToInt32(b)))
                 .Except(Enumerable.Range(1, square.Count())).Any();

            return !square.SelectMany((a, _) =>
                a.Select(b => b)
                    .GroupBy(x => x)).Any(y => y.Count() > 1) && checkDigitsApparitions;
        }
    }
}
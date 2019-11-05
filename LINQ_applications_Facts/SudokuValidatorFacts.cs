using LINQ_applications;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ_applications_Facts
{
    public class SudokuValidatorFacts
    {
        [Fact]
        public void CheckSudoku_SimpleCase_2x2_Square_CheckLines()
        {
            //Given
            IEnumerable<IEnumerable<byte>> square = new[]
            {
                new byte[]{ 1, 2 },
                new byte[] { 3, 4 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.True(validator.CheckSudoku());
        }
    }
}

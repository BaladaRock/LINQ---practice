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
        public void CheckSudoku_SimpleCase_2x2_Square_CorrectFormat_But_Smaller_Size()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 1, 2 },
                new byte[] { 2, 1 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_elements_UNICITY_FirstLine_has_repeating_Elements()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 1, 1 },
                new byte[] { 3, 4 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_elements_UNICITY_For_FULLSCALE_square()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new byte[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new byte[] { 1, 9, 7, 8, 3, 4 ,5, 6, 2 },
                new byte[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new byte[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new byte[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new byte[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new byte[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new byte[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 },
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.True(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_Elements_Line_Integrity_for_2x2_Square()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 1, 3 },
                new byte[] { 2, 1 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_Elements_Integrity_for_Larger_Square()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 1, 2, 3, 4 },
                new byte[] { 2, 3, 1, 4 },
                new byte[] { 1, 2, 3, 4 },
                new byte[] {15, 2, 3, 4 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_Elements_Integrity_for_FULLSIZE_square()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 9, 2, 6, 1, 7, 8, 5, 4, 3 },
                new byte[] { 4, 9, 3, 6, 5, 2, 1, 9, 8 },
                new byte[] { 8, 5, 1, 9, 4, 3, 6, 2, 7 },
                new byte[] { 6, 8, 5, 2, 3, 1, 9, 7, 4 },
                new byte[] { 7, 3, 4, 8, 9, 5, 2, 6, 1 },
                new byte[] { 2, 1, 9, 4, 6, 7, 8, 3, 5 },
                new byte[] { 5, 6, 8, 7, 2, 4, 3, 1, 9 },
                new byte[] { 3, 4, 2, 5, 1, 9, 7, 8, 6 },
                new byte[] { 12, 9, 7, 3, 8, 6, 4, 5, 2}
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_elements_UNICITY_Elements_Repeat_on_Coloumn()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 1, 2 },
                new byte[] { 1, 2 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Elements_Repeat_On_Column_FullSize_Square()
        {
            //Given
            byte[][] square =
            {
                new byte[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new byte[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new byte[] { 1, 9, 7, 8, 3, 4 ,5, 6, 2 },
                new byte[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new byte[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new byte[] { 9, 5, 1, 7, 4, 3, 6, 2, 4 },
                new byte[] { 5, 1, 9, 3, 2, 6, 8, 7, 8 },
                new byte[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new byte[] { 2, 6, 3, 4, 1, 8, 2, 7, 9 },
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }

        [Fact]
        public void CheckSudoku_Check_elements_UNICITY_Elements_Repeat_Inside_First_Block()
        {
            //Given
            byte[][] square =
            {
                   new byte[] { 9, 2, 6, 1, 7, 8, 5, 4, 3 },
                   new byte[] { 4, 9, 3, 6, 5, 2, 1, 9, 8 },
                   new byte[] { 8, 5, 1, 9, 4, 3, 6, 2, 7 },
                   new byte[] { 6, 8, 5, 2, 3, 1, 9, 7, 4 },
                   new byte[] { 7, 3, 4, 8, 9, 5, 2, 6, 1 },
                   new byte[] { 2, 1, 9, 4, 6, 7, 8, 3, 5 },
                   new byte[] { 5, 6, 8, 7, 2, 4, 3, 1, 9 },
                   new byte[] { 3, 4, 2, 5, 1, 9, 7, 8, 6 },
                   new byte[] { 1, 9, 7, 3, 8, 6, 4, 5, 2 }
            };
            //When
            var validator = new SudokuValidator(square);
            //Then
            Assert.False(validator.CheckSudoku());
        }
    }
}

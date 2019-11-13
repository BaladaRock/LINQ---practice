using LINQ_applications;
using Xunit;

namespace LINQ_applications_Facts
{
    public class ReversePolishFacts
    {
        [Fact]
        public void Should_Correctly_Calculate_Simple_Sum()
        {
            //Given, When
            var result = ReversePolish.CalculateExpression("1 2 +");
            //Then
            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_Correctly_Calculate_Simple_Difference()
        {
            //Given, When
            var result = ReversePolish.CalculateExpression("2 1 -");
            //Then
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Correctly_Calculate_MoreComplicated_Expression()
        {
            //Given, When
            var result = ReversePolish.CalculateExpression("2 1 - 3 *");
            //Then
            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_Correctly_Calculate_Simple_Expression_ConsequitiveOperators()
        {
            //Given, When
            var result = ReversePolish.CalculateExpression("2 1 3 - +");
            //Then
            Assert.Equal(0, result);
        }

        [Fact]
        public void Should_Correctly_Calculate_Long_Expression_More_Operators_per_Series()
        {
            //Given, When
            var result = ReversePolish.CalculateExpression("15 7 1 1 + - / 3 * 2 1 1 + + -");
            //Then
            Assert.Equal(5, result);
        }
    }
}

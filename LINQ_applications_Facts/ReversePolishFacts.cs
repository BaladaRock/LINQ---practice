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
            Assert.Equal("3", result);
        }

        [Fact]
        public void Should_Correctly_Calculate_Simple_Difference()
        {
            //Given, When
            var result = ReversePolish.CalculateExpression("1 2 -");
            //Then
            Assert.Equal("-1", result);
        }

    }
}

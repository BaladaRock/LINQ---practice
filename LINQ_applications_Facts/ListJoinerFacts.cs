using LINQ_applications;
using System.Collections.Generic;
using Xunit;

namespace LINQ_applications_Facts
{
    public class ListJoinerFacts
    {
        [Fact]
        public void Test_ListJoiner_Simple_Lists()
        {
            //Given
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 3)
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 4)
            };

            //When
            var joiner = new ListJoiner(firstList, secondList);

            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 7)
            }
            , joiner.JoinLists());
        }
    }
}
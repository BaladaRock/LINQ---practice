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

        [Fact]
        public void Test_ListJoiner_lists_contain_More_Elements()
        {
            //Given
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 3),
                new ProductQuantity("bike", 4)
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 4),
                new ProductQuantity("bike", 4)
            };

            //When
            var joiner = new ListJoiner(firstList, secondList);

            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 7),
                new ProductQuantity("bike", 8)
            }
            , joiner.JoinLists());
        }

        [Fact]
        public void Test_ListJoiner_some_Products_May_Appear_more_than_Once()
        {
            //Given
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 3),
                new ProductQuantity("car", 4),
                new ProductQuantity("bike", 4)
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 4),
                new ProductQuantity("bike", 4)
            };

            //When
            var joiner = new ListJoiner(firstList, secondList);

            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 11),
                new ProductQuantity("bike", 8)
            }
            , joiner.JoinLists());
        }
    }
}
using LINQ_applications;
using System.Collections.Generic;
using Xunit;

namespace LINQ_applications_Facts
{
    public class ListJoinerFacts
    {
        [Fact]
        public void Test_ListJoiner_FirstList_is_SHORTER_Than_SecondList()
        {
            //Given
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 3),
                new ProductQuantity("phone", 2),
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 4),
                new ProductQuantity("car", 4),
                new ProductQuantity("bike", 4),
                new ProductQuantity("phone", 2)
            };

            //When
            var joiner = new ListJoiner(firstList, secondList);
            var joinedList = joiner.MergeLists();
            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 11),
                new ProductQuantity("phone", 4),
                new ProductQuantity("bike", 4)
            }
            , joinedList);
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
            , joiner.MergeLists());
        }

        [Fact]
        public void Test_ListJoiner_Lists_Have_No_common_Elements()
        {
            //Given
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("car", 3),
                new ProductQuantity("phone", 2),
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("bike", 4),
                new ProductQuantity("motorcycle", 2)
            };

            //When
            var joiner = new ListJoiner(firstList, secondList);
            var joinedList = joiner.MergeLists();
            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 3),
                new ProductQuantity("phone", 2),
                new ProductQuantity("bike", 4),
                new ProductQuantity("motorcycle", 2),
            }
            , joinedList);
        }

        [Fact]
        public void Test_ListJoiner_Same_Product_May_Appear_more_Times_in_both_Lists()
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
                new ProductQuantity("car", 4),
                new ProductQuantity("bike", 4)
            };

            //When
            var joiner = new ListJoiner(firstList, secondList);
            var joinedList = joiner.MergeLists();
            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 15),
                new ProductQuantity("bike", 8)
            }
            , joinedList);
        }

        [Fact]
        public void Test_ListJoiner_Same_Product_May_Appear_more_Times_in_FirstList()
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
            var joinedList = joiner.MergeLists();
            //Then
            Assert.Equal(new[]
            {
                new ProductQuantity("car", 11),
                new ProductQuantity("bike", 8)
            }
            , joinedList);
        }

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
            , joiner.MergeLists());
        }
    }
}
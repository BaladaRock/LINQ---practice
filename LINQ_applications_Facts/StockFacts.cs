using System;
using Xunit;
using LINQ_applications;

namespace LINQ_applications_Facts
{
    public class StockFacts
    {
        [Fact]
        public void Should_ELIMINATE_one_element_ONE_Product_was_BOUGHT_STOCK_has_one_ProductType()
        {
            //Given
            var apples = new Product("apples", 10);
            var fruits = new Stock(apples);
            //When
            fruits.Buy(apples, 1);
            //Then
            Assert.Equal(9, fruits.GetQuantity(apples));
        }

        [Fact]
        public void Should_ELIMINATE_one_element_ONE_Product_was_BOUGHT_STOCK_has_more_ProductTypes()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock(apples, pears);
            //When
            fruits.Buy(pears, 1);
            //Then
            Assert.Equal(4, fruits.GetQuantity(pears));
        }

        [Fact]
        public void Should_ADD_Products_STOCK_has_more_ProductTypes()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock();
            fruits.AddProducts(apples, pears);
            //When
            fruits.Refill(pears, 1);
            //Then
            Assert.Equal(6, fruits.GetQuantity(pears));
        }

        [Fact]
        public void Should_ADD_ONE_MORE_Product_Type_To_STOCK()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var watermelon = new Product("watermelon", 3);
            var fruits = new Stock(apples, pears);
            //When
            fruits.AddProducts(watermelon);
            fruits.Buy(watermelon, 1);
            //Then
            Assert.Equal(2, fruits.GetQuantity(watermelon));
        }

        [Fact]
        public void Should_REMOVE_Product_Type_From_STOCK()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock(apples, pears);
            //When
            fruits.RemoveProduct(pears);
            //Then
            Assert.Equal(0, fruits.GetQuantity(pears));
        }

        [Fact]
        public void Should_Throw_Exceptionwhen_product_to_be_ADDED_IS_ALREADY_in_Stock()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock(apples, pears);
            //When
            Action addException = () => fruits.AddProducts(pears);
            //Then
            Assert.Throws<InvalidOperationException>(addException);
        }
    }
}

using LINQ_applications;
using System;
using System.Collections.Generic;
using Xunit;

namespace LINQ_applications_Facts
{
    public class StockFacts
    {
        [Fact]
        public void Should_ADD_ONE_MORE_Product_Type_To_STOCK()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var watermelon = new Product("watermelon", 3);
            var fruits = new Stock(new List<Product> { apples, pears });
            //When
            fruits.AddProducts(watermelon);
            fruits.Buy(1, watermelon);
            //Then
            Assert.Equal(2, fruits.GetQuantity(watermelon));
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
            fruits.AddProducts(1, pears);
            //Then
            Assert.Equal(6, fruits.GetQuantity(pears));
        }

        [Fact]
        public void Should_ELIMINATE_one_element_ONE_Product_was_BOUGHT_STOCK_has_more_ProductTypes()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock(new List<Product> { apples, pears });
            //When
            fruits.Buy(1, pears);
            //Then
            Assert.Equal(4, fruits.GetQuantity(pears));
        }

        [Fact]
        public void Should_ELIMINATE_one_element_ONE_Product_was_BOUGHT_STOCK_has_one_ProductType()
        {
            //Given
            var apples = new Product("apples", 10);
            var fruits = new Stock(new List<Product> { apples });
            //When
            fruits.Buy(1, apples);
            //Then
            Assert.Equal(9, fruits.GetQuantity(apples));
        }

        [Fact]
        public void Should_Throw_Exception_GetQuantity_When_Product_IS_NOT_in_Stock()
        {
            //Given
            var apples = new Product("apples", -3);
            var fruits = new Stock();
            //When
            Action addException = () => fruits.GetQuantity(apples);
            //Then
            Assert.Throws<InvalidOperationException>(addException);
        }

        [Fact]
        public void Should_Throw_Exception_when_Product_Is_NULL()
        {
            //Given
            var fruits = new Stock();
            //When
            Action addException = () => fruits.AddProducts(null);
            //Then
            Assert.Throws<ArgumentNullException>(addException);
        }

        [Fact]
        public void Should_Throw_Exception_when_product_to_be_ADDED_IS_ALREADY_in_Stock()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock(new List<Product> { apples, pears });
            //When
            Action addException = () => fruits.AddProducts(pears);
            //Then
            Assert.Throws<InvalidOperationException>(addException);
        }

        [Fact]
        public void Should_Throw_Exception_when_Product_To_Be_Refilled_IS_NOT_in_Stock()
        {
            //Given
            var apples = new Product("apples", 10);
            var pears = new Product("pears", 5);
            var fruits = new Stock(new List<Product> { apples });
            //When
            Action addException = () => fruits.AddProducts(2, pears);
            //Then
            Assert.Throws<InvalidOperationException>(addException);
        }

        [Fact]
        public void Should_Throw_Exception_when_Product_TO_Remove_IS_NOT_in_Stock()
        {
            //Given
            var apples = new Product("apples", 10);
            var fruits = new Stock();
            //When
            Action addException = () => fruits.RemoveProduct(apples);
            //Then
            Assert.Throws<InvalidOperationException>(addException);
        }

        [Fact]
        public void Should_Throw_Exception_When_Quantity_To_Add_Is_Not_Positive()
        {
            //Given
            var fruits = new Stock();
            //When
            Action addException = () => fruits.AddProducts(new Product("apples", -3));
            //Then
            Assert.Throws<ArgumentException>(addException);
        }

        [Fact]
        public void Should_Throw_NULL_Exception_For_Remove()
        {
            //Given
            var fruits = new Stock();
            //When
            Action addException = () => fruits.RemoveProduct(null);
            //Then
            Assert.Throws<ArgumentNullException>(addException);
        }
    }
}
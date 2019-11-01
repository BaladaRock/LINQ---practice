using LINQ_applications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LINQ_applications_Facts
{
    public class ProductFacts
    {
        [Fact]
        public void Should_Filter_List_Correctly_2_products_have_Identical_Names()
        {
            //Given
            Feature firstFeature = new Feature { Id = 2 };
            Feature secondFeature = new Feature { Id = 3 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { firstFeature }
            };
            ProductType pears = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { secondFeature }
            };
            ProductType nuts = new ProductType
            {
                Name = "nuts",
                Features = new List<Feature> { new Feature { Id = 4 }, secondFeature }
            };
            ProductType watermelons = new ProductType
            {
                Name = "watermelons",
                Features = new List<Feature> { new Feature { Id = 4 } }
            };

            var productList = new List<ProductType> { apples, pears, nuts, watermelons };

            //When
            var filteringCriteria = new List<Feature> { new Feature { Id = 5 }, secondFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AnyFeatureFilter();

            //Then
            Assert.Equal(2, filteredList.Count());
            Assert.Equal(pears, filteredList.First());
        }

        [Fact]
        public void Should_Filter_List_For_More_Elements_And_More_Given_Features()
        {
            //Given
            Feature firstFeature = new Feature { Id = 2 };
            Feature secondFeature = new Feature { Id = 3 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { firstFeature }
            };
            ProductType pears = new ProductType
            {
                Name = "pears",
                Features = new List<Feature> { firstFeature }
            };
            ProductType nuts = new ProductType
            {
                Name = "nuts",
                Features = new List<Feature> { firstFeature, secondFeature }
            };
            ProductType watermelons = new ProductType
            {
                Name = "watermelons",
                Features = new List<Feature> { new Feature { Id = 4 } }
            };

            var productList = new List<ProductType> { apples, pears, nuts, watermelons };

            //When
            var filteringCriteria = new List<Feature> { firstFeature, secondFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AnyFeatureFilter();

            //Then
            Assert.Equal(3, filteredList.Count());
        }

        [Fact]
        public void Should_Filter_List_For_One_Element_And_One_Given_Feature()
        {
            //Given
            Feature askedFeature = new Feature { Id = 1 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { askedFeature }
            };
            ProductType pears = new ProductType
            {
                Name = "pears",
                Features = new List<Feature> { new Feature { Id = 2 } }
            };

            var productList = new List<ProductType> { apples, pears };

            //When
            var filteringCriteria = new List<Feature> { askedFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AnyFeatureFilter();

            //Then
            Assert.Single(filteredList);
        }

        [Fact]
        public void Test_Filtering_After_All_Features_list_of_2_Products()
        {
            //Given
            Feature firstFeature = new Feature { Id = 2 };
            Feature secondFeature = new Feature { Id = 3 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { firstFeature, secondFeature }
            };
            ProductType pears = new ProductType
            {
                Name = "pears",
                Features = new List<Feature> { secondFeature }
            };

            var productList = new List<ProductType> { apples, pears };

            //When
            var filteringCriteria = new List<Feature> { firstFeature, secondFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AllFeaturesFilter();

            //Then
            Assert.Single(filteredList);
        }

        [Fact]
        public void Test_Filtering_After_All_Features_Longer_list_Features_Order_should_NOT_matter()
        {
            //Given
            Feature firstFeature = new Feature { Id = 2 };
            Feature secondFeature = new Feature { Id = 3 };
            Feature thirdFeature = new Feature { Id = 4 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { firstFeature }
            };
            ProductType pears = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { secondFeature }
            };
            ProductType nuts = new ProductType
            {
                Name = "nuts",
                Features = new List<Feature> { thirdFeature, secondFeature, firstFeature }
            };
            ProductType watermelons = new ProductType
            {
                Name = "watermelons",
                Features = new List<Feature> { firstFeature, secondFeature, firstFeature }
            };

            var productList = new List<ProductType> { apples, pears, nuts, watermelons };

            //When
            var filteringCriteria = new List<Feature> { firstFeature, secondFeature, thirdFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AllFeaturesFilter();

            //Then
            Assert.Single(filteredList);
        }

        [Fact]
        public void Test_Filtering_After_NO_Feature_list_of_2_Products()
        {
            //Given
            Feature firstFeature = new Feature { Id = 2 };
            Feature secondFeature = new Feature { Id = 3 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { new Feature { Id = 4 } }
            };
            ProductType pears = new ProductType
            {
                Name = "pears",
                Features = new List<Feature> { new Feature { Id = 5 } }
            };
            ProductType nuts = new ProductType
            {
                Name = "nuts",
                Features = new List<Feature> { secondFeature, new Feature { Id = 5 } }
            };

            var productList = new List<ProductType> { apples, pears, nuts };

            //When
            var filteringCriteria = new List<Feature> { firstFeature, secondFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.NoFeatureFilter();

            //Then
            Assert.Equal(2, filteredList.Count());
        }

        [Fact]
        public void Test_Filtering_After_NO_Feature_Should_Not_Consider_Features_ORDER()
        {
            //Given
            Feature firstFeature = new Feature { Id = 2 };
            Feature secondFeature = new Feature { Id = 3 };
            Feature thirdFeature = new Feature { Id = 4 };

            ProductType apples = new ProductType
            {
                Name = "apples",
                Features = new List<Feature> { thirdFeature }
            };
            ProductType pears = new ProductType
            {
                Name = "pears",
                Features = new List<Feature> { secondFeature, thirdFeature, firstFeature }
            };
            ProductType nuts = new ProductType
            {
                Name = "nuts",
                Features = new List<Feature> { secondFeature, firstFeature }
            };

            var productList = new List<ProductType> { apples, pears, nuts };

            //When
            var filteringCriteria = new List<Feature> { firstFeature, secondFeature, thirdFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.NoFeatureFilter();

            //Then
            Assert.Empty(filteredList);
        }

        /*[Fact]
        public void Test_ListsJoin_Should_Merge_Simple_lists()
        {
            //Given

            var product = new ProductType();
            product.Pr

            var productList = new List<ProductType> { apples, pears, nuts, watermelons };

            //When
            var filteringCriteria = new List<Feature> { new Feature { Id = 5 }, secondFeature };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AnyFeatureFilter(productList);

            //Then
            Assert.Equal(2, filteredList.Count);
            Assert.Equal(pears, filteredList[0]);
        }*/
    }
}
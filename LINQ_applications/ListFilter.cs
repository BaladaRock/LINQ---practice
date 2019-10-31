using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class ListFilter
    {
        private readonly List<Feature> featureList;
        private readonly List<ProductType> productList;

        public ListFilter(List<ProductType> products, List<Feature> features)
        {
            productList = products;
            featureList = features;
        }

        public List<ProductType> AllFeaturesFilter(List<ProductType> productList)
        {
            return productList.Where(product =>
                product.Features
                 .GroupBy(x => x).Count() == featureList
                   .GroupBy(x => x).Count())
                .ToList();
        }

        public List<ProductType> AnyFeatureFilter(List<ProductType> listToFilter)
        {
            return productList.Where(product =>
                 featureList.Intersect(product.Features, new IDComparer())
                    .Any())
                 .ToList();
        }

        public List<ProductType> NoFeatureFilter(List<ProductType> productList)
        {
            return productList.Except(AnyFeatureFilter(productList))
                 .ToList();
        }
    }
}
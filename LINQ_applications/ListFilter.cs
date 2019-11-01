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

        public IEnumerable<ProductType> AllFeaturesFilter()
        {
            return productList.Where(x =>
                featureList.All(a => x.Features.Contains(a)));
        }

        public IEnumerable<ProductType> AnyFeatureFilter()
        {
            return productList.Where(product =>
                 FindAtLeastOneFeature(product));
        }

        public IEnumerable<ProductType> NoFeatureFilter()
        {
            return productList.Where(product =>
                 !FindAtLeastOneFeature(product));
        }

        private bool FindAtLeastOneFeature(ProductType product)
        {
            return featureList.Intersect(product.Features, new IDComparer())
                                .Any();
        }
    }
}
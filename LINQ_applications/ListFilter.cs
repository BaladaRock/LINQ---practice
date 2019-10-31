using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<ProductType> FilterList(List<ProductType> listToFilter)
        {
            return productList.Where(product =>
                 featureList.Intersect(product.Features, new IDComparer()).Any())
                 .ToList();
        }
    }
}

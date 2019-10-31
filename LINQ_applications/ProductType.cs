using System.Collections.Generic;

namespace LINQ_applications
{
    public class ProductType
    {
        public ICollection<Feature> Features { get; set; }

        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_applications
{
    public class ProductType
    {
        public string Name { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}

using LINQ_applications;
using System;
using System.Collections.Generic;

namespace LINQ_applications_Facts
{
    public class ProductQuantityComparer : IEqualityComparer<KeyValuePair<string, int>>
    {
        public bool Equals(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            return x.Key == y.Key;
        }

        public int GetHashCode(KeyValuePair<string, int> obj)
        {
            return obj.Key.ToLower().GetHashCode();
        }
    }
}
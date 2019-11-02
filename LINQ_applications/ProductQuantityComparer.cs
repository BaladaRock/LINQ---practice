using System;
using System.Collections.Generic;

namespace LINQ_applications_Facts
{
    public class ProductQuantityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x == y;
        }

        public int GetHashCode(string obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.ToLower().GetHashCode();
        }
    }
}
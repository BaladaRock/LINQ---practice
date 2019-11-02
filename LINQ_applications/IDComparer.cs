using System.Collections.Generic;

namespace LINQ_applications
{
    internal class IDComparer : IEqualityComparer<Feature>
    {
        public bool Equals(Feature first, Feature second)
        {
            return first.Id == second.Id;
        }

        public int GetHashCode(Feature feature)
        {
            return feature.Id.GetHashCode();
        }
    }
}
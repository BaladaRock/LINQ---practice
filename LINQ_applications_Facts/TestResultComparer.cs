using LINQ_applications;
using System.Collections.Generic;

namespace LINQ_applications_Facts
{
    internal class TestResultComparer : IEqualityComparer<TestResults>
    {
        public bool Equals(TestResults x, TestResults y)
        {
            return x.FamilyId == y.FamilyId &&
                   x.Id == y.Id &&
                   x.Score == y.Score;
        }

        public int GetHashCode(TestResults obj)
        {
            return obj.FamilyId.ToLower().GetHashCode();
        }
    }
}
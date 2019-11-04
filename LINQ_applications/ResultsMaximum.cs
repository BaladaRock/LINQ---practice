using LINQ_applications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications_Facts
{
    public class ResultsMaximum
    {
        private readonly List<TestResults> list;

        public ResultsMaximum(List<TestResults> list)
        {
            this.list = list;
        }

        public IEnumerable<TestResults> GetMaxPerFamily()
        {
            return list.GroupBy(x => x.FamilyId)
                .Select(x =>
                    x.First(y => y.Score == GetMaximum(x)));
        }

        private int GetMaximum(IGrouping<string, TestResults> group)
        {
            return group.Max(x => x.Score);
        }
    }
}
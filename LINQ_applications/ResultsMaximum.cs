using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
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
                    {
                        var seed = x.First();
                        return x.Aggregate(seed, (max, current) =>
                            current.Score > max.Score
                                ? current
                                : max);
                    });
        }
    }
}
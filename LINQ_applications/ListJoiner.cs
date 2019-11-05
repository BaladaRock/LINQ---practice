using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class ListJoiner
    {
        private readonly List<ProductQuantity> firstList;
        private readonly List<ProductQuantity> secondList;

        public ListJoiner(List<ProductQuantity> firstList, List<ProductQuantity> secondList)
        {
            this.firstList = firstList;
            this.secondList = secondList;
        }

        public IEnumerable<ProductQuantity> MergeLists()
        {
            return firstList.Concat(secondList)
                .GroupBy(x => x.Name)
                    .Select(x => new ProductQuantity(
                        x.Key,
                        x.Sum(y => y.Quantity)));
        }
    }
}

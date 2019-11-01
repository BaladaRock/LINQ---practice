using LINQ_applications;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications_Facts
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

        public IEnumerable<ProductQuantity> JoinLists()
        {
            return firstList.Zip(secondList, (x, y) => new ProductQuantity(x.Name, x.Quantity + y.Quantity));
        }
    }
}
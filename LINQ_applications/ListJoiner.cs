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
            var firstDictionary = new Dictionary<string, int>(new ProductQuantityComparer());

            var secondDictionary = new Dictionary<string, int>(new ProductQuantityComparer());

            foreach (var element in firstList)
            {
                if (!firstDictionary.TryAdd(element.Name, element.Quantity))
                {
                    firstDictionary[element.Name] += element.Quantity;
                }
            }

            foreach (var element in secondList)
            {
                if (!secondDictionary.TryAdd(element.Name, element.Quantity))
                {
                    secondDictionary[element.Name] += element.Quantity;
                }
            }

            return firstDictionary.Join(
                secondDictionary,
                x => x.Key,
                y => y.Key,
                (a, b) =>
                a.Key == b.Key
                  ? new ProductQuantity(a.Key, a.Value + b.Value)
                  : new ProductQuantity(b.Key, b.Value));
        }
    }
}
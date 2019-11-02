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
            Dictionary<string, int> firstDictionary = ConvertToDictionary(firstList);
            Dictionary<string, int> secondDictionary = ConvertToDictionary(secondList);

            return MergeDictionaries(firstDictionary, secondDictionary)
                .Select(x =>
                   firstDictionary.Count >= secondDictionary.Count
                     ? AddQuantities(x, firstDictionary, secondDictionary)
                     : AddQuantities(x, secondDictionary, firstDictionary));
        }

        private static IEnumerable<KeyValuePair<string, int>> MergeDictionaries(Dictionary<string, int> firstDictionary, Dictionary<string, int> secondDictionary)
        {
            return firstDictionary.Union(secondDictionary, new ProductQuantityComparer());
        }

        private ProductQuantity AddQuantities(KeyValuePair<string, int> x, Dictionary<string, int> firstDictionary, Dictionary<string, int> secondDictionary)
        {
            string key = x.Key;
            return secondDictionary.ContainsKey(key)
                ? new ProductQuantity(key, firstDictionary[key] + secondDictionary[key])
                : new ProductQuantity(key, firstDictionary[key]);
        }

        private Dictionary<string, int> ConvertToDictionary(List<ProductQuantity> list)
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var element in list)
            {
                if (!dictionary.TryAdd(element.Name, element.Quantity))
                {
                    dictionary[element.Name] += element.Quantity;
                }
            }

            return dictionary;
        }
    }
}
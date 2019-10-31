using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    internal static class Program
    {
        internal static void Main()
        {
            var stock = new Stock(new List<Product> { new Product("mere", 11) });

            void Method(Product product, int quantity)
            {
                Console.WriteLine("Produsul {0} are {1} elemente", product.Name, quantity);
            }

            stock.AddCallback(Method);
            stock.Buy(3, "mere");
            stock.Buy(5, "mere");

            foreach (var element in "abc".Intersect("dfg").ToList())
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class Stock
    {
        private static IEnumerable<Product> products;

        public static void InitProducts(params Product[] setProducts)
        {
            products = setProducts;
        }

        public static int GetQuantity(Product productName)
        {
            if (ThrowNull(productName))
            {
                return 0;
            }

            return products.SingleOrDefault(x => x.Name == productName.Name)?.Number ?? 0;
        }

        public void AddProducts(params Product[] productsList)
        {
            InitProducts(productsList);
        }

        public void Buy(Product product, int quantity)
        {
            product.Subtract(quantity);
        }

        public void Refill(Product product, int quantity)
        {
            product.Add(quantity);
        }

        public void RemoveProduct(Product productToRemove)
        {
            var newProducts = products.Select(x => x).Where(x => x.Name != productToRemove.Name);
            products = products.Intersect(newProducts, new CompareProducts());
        }

        private static bool ThrowNull(Product productName)
        {
            if (productName != null)
            {
                return false;
            }

            throw new ArgumentNullException(nameof(productName));
        }

        internal class CompareProducts : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                return x.Name == y.Name;
            }

            public int GetHashCode(Product obj)
            {
                return obj.Name.ToLower().GetHashCode();
            }
        }
    }
}
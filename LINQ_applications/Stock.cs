using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class Stock
    {
        private IEnumerable<Product> products;

        public Stock(params Product[] setProducts)
        {
            products = setProducts;
        }

        public void AddProducts(params Product[] productsList)
        {
            ThrowInvalidOperation(productsList);

            foreach (var product in productsList)
            {
                products = products.Append(product);
            }
        }

        public void Buy(Product product, int quantity)
        {
            RemoveProduct(product);
            products = products.Append(new Product(product.Name, product.Number - 1));
        }

        public int GetQuantity(Product productName)
        {
            if (ThrowNull(productName))
            {
                return 0;
            }

            return products.SingleOrDefault(x => x.Name == productName.Name)?.Number ?? 0;
        }

        public void Refill(Product product, int quantity)
        {
            RemoveProduct(product);
            products = products.Append(new Product(product.Name, product.Number + 1));
        }

        public void RemoveProduct(Product productToRemove)
        {
            var newProducts = products.Select(x => x).Where(x => x.Name != productToRemove.Name);
            products = products.Intersect(newProducts);
        }

        private void ThrowInvalidOperation(Product[] productsList)
        {
            var foundProducts = productsList.Intersect(products);
            if (!foundProducts.GetEnumerator().MoveNext())
            {
                return;
            }

            throw new InvalidOperationException("Product already exists in stock!/t");
        }

        private bool ThrowNull(Product productName)
        {
            if (productName != null)
            {
                return false;
            }

            throw new ArgumentNullException(nameof(productName));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class Stock
    {
        private List<Product> products;

        public Stock()
            : this(new List<Product>())
        {
        }

        public Stock(List<Product> setProducts)
        {
            ThrowNullParameters(setProducts);
            products = setProducts;
        }

        public void AddProducts(params Product[] productsList)
        {
            ThrowNullParameters(productsList);

            foreach (var product in productsList)
            {
                ThrowNull(product);
                ThrowInvalidOperation(product);
                ThrowInvalidParameter(product.Number);

                products = products.Append(product).ToList();
            }
        }

        public void AddProducts(int quantity, Product product)
        {
            ThrowNull(product);
            ThrowNotInStock(product);
            ThrowInvalidParameter(quantity);

            RemoveProduct(product);
            products = products.Append(new Product(product.Name, product.Number + quantity)).ToList();
        }

        public void Buy(int productsToBuy, Product product)
        {
            ThrowNull(product);
            ThrowInvalidParameter(productsToBuy);

            RemoveProduct(product);
            products = products.Append(new Product(product.Name, product.Number - productsToBuy)).ToList();
        }

        public int GetQuantity(Product product)
        {
            ThrowNull(product);
            ThrowNotInStock(product);

            return products.Single(x => x.Name == product.Name).Number;
        }

        public void RemoveProduct(Product productToRemove)
        {
            ThrowNull(productToRemove);
            ThrowNotInStock(productToRemove);

            var newProducts = products.Select(x => x).Where(x => x.Name != productToRemove.Name);
            products = products.Intersect(newProducts).ToList();
        }

        private void ThrowInvalidOperation(Product product)
        {
            if (!products.Contains(product))
            {
                return;
            }

            throw new InvalidOperationException("Product already exists in stock!/t");
        }

        private void ThrowInvalidParameter(int quantity)
        {
            if (quantity >= 0)
            {
                return;
            }

            throw new ArgumentException("Quantity must be positive!/t");
        }

        private void ThrowNotInStock(Product product)
        {
            if (products.Select(x => x.Name).Contains(product.Name))
            {
                return;
            }

            throw new InvalidOperationException("Product is not in stock!/t");
        }

        private void ThrowNull(Product productName)
        {
            if (productName != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(productName));
        }

        private void ThrowNullParameters(IEnumerable<Product> productsList)
        {
            if (productsList != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(productsList));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_applications
{
    public class Stock
    {
        private Action<Product, int> callback;
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

        public void AddProducts(int quantity, string productName)
        {
            var foundNode = products.Single(x => x.Name == productName);
            ThrowNull(foundNode);
            ThrowNotInStock(foundNode);
            ThrowInvalidParameter(quantity);

            RemoveProduct(foundNode);
            products = products.Append(new Product(foundNode.Name, foundNode.Number + quantity)).ToList();
        }

        public Action<Product, int> Buy(int productsToBuy, string productName)
        {
            var foundNode = products.Single(x => x.Name == productName);
            ThrowNull(foundNode);
            ThrowInvalidParameter(productsToBuy);

            var newProduct = new Product(foundNode.Name, foundNode.Number - productsToBuy);
            RemoveProduct(foundNode);
            products = products.Append(newProduct).ToList();

            return CallBackProduct(newProduct);
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

        private Action<Product, int> CallBackProduct(Product product)
        {
            if (product.Number < 10 || product.Number < 5 || product.Number < 2)
            {
                callback = (x, y) => CheckQuantity(product, product.Number);
            }

            return callback;
        }

        private void CheckQuantity(Product newProduct, int number)
        {
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
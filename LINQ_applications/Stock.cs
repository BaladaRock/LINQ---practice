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

        public void AddCallback(Action<Product, int> callback)
        {
            this.callback = callback;
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

        public void Buy(int productsToBuy, string productName)
        {
            var foundNode = products.Single(x => x.Name == productName);
            ThrowNull(foundNode);
            ThrowInvalidParameter(productsToBuy);

            var newProduct = new Product(foundNode.Name, foundNode.Number - productsToBuy);
            RemoveProduct(foundNode);
            products = products.Append(newProduct).ToList();

            CallBackProduct(newProduct, foundNode.Number);
        }

        public int GetQuantity(Product product)
        {
            ThrowNull(product);
            ThrowNotInStock(product);

            return products.Single(x => x.Name == product.Name).Number;
        }

        private void CallBackProduct(Product product, int oldQuantity)
        {
            if (callback == null || !CheckCallBack(product, oldQuantity))
            {
                return;
            }

            callback(product, product.Number);
        }

        private bool CheckCallBack(Product product, int oldQuantity)
        {
            var currentQuantity = product.Number;

            return CheckQuantities(oldQuantity, currentQuantity, 10)
                || CheckQuantities(oldQuantity, currentQuantity, 5)
                || CheckQuantities(oldQuantity, currentQuantity, 2);
        }

        private bool CheckQuantities(int oldQuantity, int currentQuantity, int limit)
        {
            return oldQuantity >= limit && currentQuantity < limit;
        }

        private void RemoveProduct(Product productToRemove)
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
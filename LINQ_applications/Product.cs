namespace LINQ_applications
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; }

        public int Quantity { get; }
    }
}
namespace LINQ_applications
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            Name = name;
            Number = quantity;
        }

        public string Name { get; }

        public int Number { get; }
    }
}
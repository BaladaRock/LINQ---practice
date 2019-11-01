using System;

namespace LINQ_applications
{
    public struct ProductQuantity
    {
        public ProductQuantity(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public static bool operator !=(ProductQuantity left, ProductQuantity right)
        {
            return !(left == right);
        }

        public static bool operator ==(ProductQuantity left, ProductQuantity right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Equals(Quantity);
        }

        public override int GetHashCode()
        {
            return Quantity.GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public class Product
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            ProductName = name;
            ProductPrice = price;
            ProductQuantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {ProductName}, Price: ${ProductPrice}, Quantity: {ProductQuantity}";
        }
    }

}

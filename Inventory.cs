using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{

    public class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct()
        {
        
            

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            products.Add(new Product(name, price, quantity));
            Console.WriteLine("Product added successfully");
        }
    }
}

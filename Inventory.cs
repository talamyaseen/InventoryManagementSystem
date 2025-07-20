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


        private Product FindProductByName(string name)
        {
            var product = products.FirstOrDefault(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                }

            return product;
        }

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

        public void ViewProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty");
                return;
            }

            Console.WriteLine("All Products:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }

        }

        public void SearchProduct()
        {
            Console.Write("Enter product name to search: ");
            string name = Console.ReadLine();

            var product = FindProductByName(name);
            if (product != null)
            {
                Console.WriteLine("Product found:");
                Console.WriteLine(product);
            }
        }

        public void DeleteProduct()
        {
            Console.Write("Enter product name to delete: ");
            string name = Console.ReadLine();

            var product = FindProductByName(name);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully");
            }

            
        }
    }
}

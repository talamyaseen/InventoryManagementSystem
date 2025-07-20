using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
  

            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("5. Search for a product");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inventory.AddProduct();
                        break;
                    case "2":
                        inventory.ViewProducts();
                        break;
                    case "3":
                        inventory.EditProduct();
                        break;
                    case "5":
                        inventory.SearchProduct();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
    }
}

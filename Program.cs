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
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inventory.AddProduct();
                        break;
                    case "2":
                        inventory.ViewProducts();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
    }
}

using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool running = true;


            while (running)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("5. Search for a product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inventory.AddProduct();
                        break;
                    case "2":
                        inventory.ViewProducts();
                        break;
                    case "4":
                        inventory.DeleteProduct();
                        break;
                    case "5":
                        inventory.SearchProduct();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
    }
}

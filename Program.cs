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
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inventory.AddProduct();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            }
        }
    }
}

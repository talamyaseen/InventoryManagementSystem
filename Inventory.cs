using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();

        private Product? FindProductByName(string name)
        {
            return products.FirstOrDefault(p => 
                p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            var price = InputHelper.PromptForValidDouble("Enter product price: ");
            if (price == null)
            {
                Console.WriteLine("Invalid price");
                return;
            }

            var quantity = InputHelper.PromptForValidInt("Enter product quantity: ");
            if (quantity == null)
            {
                Console.WriteLine("Invalid quantity");
                return;
            }

            products.Add(new Product(name, price.Value, quantity.Value));
            Console.WriteLine("Product added successfully.");
        }

        public void EditProduct()
        {
            Console.Write("Enter product name to edit: ");
            string name = Console.ReadLine();

            var product = FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("New name (leave empty to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                product.ProductName = newName;

            var newPrice = InputHelper.PromptForValidDouble("New price (leave empty to keep current): ", allowEmpty: true);
            if (newPrice != null)
                product.ProductPrice = newPrice.Value;

            var newQuantity = InputHelper.PromptForValidInt("New quantity (leave empty to keep current): ", allowEmpty: true);
            if (newQuantity != null)
                product.ProductQuantity = newQuantity.Value;

            Console.WriteLine("Product updated successfully.");
        }

        public void SearchProduct()
        {
            Console.Write("Enter product name to search: ");
            string name = Console.ReadLine();

            var product = FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("Product found:");
            Console.WriteLine(product);
        }

        public void DeleteProduct()
        {
            Console.Write("Enter product name to delete: ");
            string name = Console.ReadLine();

            var product = FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            products.Remove(product);
            Console.WriteLine("Product deleted successfully.");
        }
    }
}

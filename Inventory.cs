using System;
using System.Collections.Generic;
using System.Linq;

// Inventory.cs
using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class Inventory
    {
        
        private Dictionary<string, Product> products = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);

        private Product? FindProductByName(string name)
        {
            products.TryGetValue(name, out Product product);
            return product;
        }

        public void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            if (products.ContainsKey(name))
            {
                Console.WriteLine("Product already exists.");
                return;
            }

            var price = InputHelper.PromptForValidDecimal("Enter product price: ");
            if (price == null)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            var quantity = InputHelper.PromptForValidInt("Enter product quantity: ");
            if (quantity == null)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            products.Add(name, new Product(name, price.Value, quantity.Value));
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
            if (!string.IsNullOrWhiteSpace(newName) && !newName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                if (products.ContainsKey(newName))
                {
                    Console.WriteLine("Another product with this name already exists.");
                    return;
                }

                products.Remove(name);
                product.ProductName = newName;
                products.Add(newName, product);
            }

            var newPrice = InputHelper.PromptForValidDecimal("New price (leave empty to keep current): ", allowEmpty: true);
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

            if (!products.Remove(name))
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("Product deleted successfully.");
        }
    }
}

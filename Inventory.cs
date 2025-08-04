using System;
using System.Collections.Generic;
using System.Linq;

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
            var name = InputHelper.PromptForValidString("Enter product name: ");
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }

            if (products.ContainsKey(name))
            {
                Console.WriteLine("Product already exists.");
                return;
            }

            var price = InputHelper.PromptForValidDecimal("Enter product price: ", allowEmpty: false, maxAttempts: 5);
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
            var name = InputHelper.PromptForValidString("Enter product name to edit: ");
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }

            var product = FindProductByName(name);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            var newName = InputHelper.PromptForValidString("New name (leave empty to keep current): ", allowEmpty: true);
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
            var name = InputHelper.PromptForValidString("Enter product name to search: ");
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }

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
            var name = InputHelper.PromptForValidString("Enter product name to delete: ");
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }

            if (!products.Remove(name))
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("Product deleted successfully.");
        }

        public void ViewProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("All Products:");
            int index = 1;
            foreach (var product in products.Values)
            {
                Console.WriteLine($"{index++}. {product}");
            }
        }
    }
}

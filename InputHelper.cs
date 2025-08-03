using System;

namespace InventoryManagementSystem
{
    public static class InputHelper
    {
        public static double? PromptForValidDouble(string message, bool allowEmpty = false)
        {
            int attempts = 0;

            while (attempts < 3)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                    return null;

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
                attempts++;
            }

            Console.WriteLine("Too many invalid attempts.");
            return null;
        }

        public static int? PromptForValidInt(string message, bool allowEmpty = false)
        {
            int attempts = 0;

            while (attempts < 3)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                    return null;

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
                attempts++;
            }

            Console.WriteLine("Too many invalid attempts.");
            return null;
        }
    }
}

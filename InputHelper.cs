using System;

namespace InventoryManagementSystem
{
    public static class InputHelper
    {
        private static T? Prompt<T>(
            string message,
            Func<string, (bool success, T value)> tryParse,
            bool allowEmpty,
            int maxAttempts
        )
        {
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (input is null)
                {
                    if (allowEmpty)
                        return default;
                    Console.WriteLine("Input cannot be empty.");
                    attempts++;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input) && allowEmpty)
                    return default;

                var (success, value) = tryParse(input);
                if (success)
                    return value;

                Console.WriteLine($"Invalid {typeof(T).Name}. Try again.");
                attempts++;
            }

            Console.WriteLine("Too many invalid attempts.");
            return default;
        }

        public static T? PromptForValidValue<T>(
            string message,
            Func<string, (bool success, T value)> tryParse,
            bool allowEmpty = false,
            int maxAttempts = 3
        ) where T : struct
        {
            return Prompt(message, tryParse, allowEmpty, maxAttempts);
        }

        public static string? PromptForValidString(
            string message,
            bool allowEmpty = false,
            int? maxAttempts = null
        )
        {
            return Prompt(message, input =>
            {
                bool success = !string.IsNullOrWhiteSpace(input);
                return (success || allowEmpty, input);
            }, allowEmpty, maxAttempts ?? 3);
        }

        public static int? PromptForValidInt(string message, bool allowEmpty = false, int? maxAttempts = null) =>
            PromptForValidValue<int>(message, input =>
            {
                bool success = int.TryParse(input, out int val);
                return (success, val);
            }, allowEmpty, maxAttempts ?? 3);

        public static decimal? PromptForValidDecimal(string message, bool allowEmpty = false, int? maxAttempts = null) =>
            PromptForValidValue<decimal>(message, input =>
            {
                bool success = decimal.TryParse(input, out decimal val);
                return (success, val);
            }, allowEmpty, maxAttempts ?? 3);
    }
}

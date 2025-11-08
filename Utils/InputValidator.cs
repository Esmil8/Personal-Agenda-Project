
using System.Text.RegularExpressions;

namespace ContactManagerPro.Operations;

public static partial class InputValidator
{
    private const int MaxRetries = 3;

    public static string GetValidatedString(string prompt, int minLength = 3, int maxLength = 100)
    {
        for (int attempts = 0; attempts < MaxRetries; attempts++)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input) &&
                input.Length >= minLength && input.Length <= maxLength)
                return input;

            Console.WriteLine(
                $" Input must be between {minLength} and {maxLength} characters. " +
                $"Try again ({attempts + 1}/{MaxRetries})."
            );
        }

        throw new InvalidOperationException(" Maximum attempts reached. Input aborted.");
    }


    public static string GetValidatedEmail(string prompt)
    {
        for (int attempts = 0; attempts < MaxRetries; attempts++)
        {
            Console.Write(prompt);
            var email = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(email) && EmailRegex().IsMatch(email))
                return email;

            Console.WriteLine($" Invalid email format. Example: user@example.com ({attempts + 1}/{MaxRetries})");
        }

        throw new InvalidOperationException(" Too many invalid email attempts.");
    }

    public static string GetValidatedPhone(string prompt, int minLength = 10, int maxLength = 15)
    {
        for (int attempts = 0; attempts < MaxRetries; attempts++)
        {
            Console.Write(prompt);
            var phone = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(phone) &&
                PhoneRegex().IsMatch(phone) &&
                phone.Length >= minLength &&
                phone.Length <= maxLength)
                return phone;

            Console.WriteLine($" Phone must contain only digits and be between {minLength}-{maxLength} numbers. ({attempts + 1}/{MaxRetries})");
        }

        throw new InvalidOperationException(" Too many invalid phone attempts.");
    }

    public static int GetValidatedInt(string prompt, int minValue = 0, int maxValue = 120)
    {
        for (int attempts = 0; attempts < MaxRetries; attempts++)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input, out var result) && result >= minValue && result <= maxValue)
                return result;

            Console.WriteLine($" Enter a valid number between {minValue} and {maxValue}. ({attempts + 1}/{MaxRetries})");
        }

        throw new InvalidOperationException(" Too many invalid numeric attempts.");
    }


    public static bool GetYesNo(string prompt)
    {
        for (int attempts = 0; attempts < MaxRetries; attempts++)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            var result = input switch
            {
                "1" => true,
                "2" => false,
                _ => (bool?)null
            };

            if (result is not null)
                return result.Value;

            Console.WriteLine($" Invalid option. Enter 1 for Yes or 2 for No. ({attempts + 1}/{MaxRetries})");
        }

        throw new InvalidOperationException(" Too many invalid responses.");
    }


    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial Regex EmailRegex();

    [GeneratedRegex(@"^\d+$")]
    private static partial Regex PhoneRegex();
}

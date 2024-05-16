using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Services;

internal class InputValidator
{
    public static string ValidateString()
    {
        Console.Write("Please enter a valid string: ");

        string input;

        while (string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            Console.Write("String cannot be empty. Please re-enter: ");
        }

        return input;
    }

    public static int ValidateInteger()
    {
        Console.Write("Please enter a valid integer: ");

        int result;

        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Invalid input. Please enter a valid integer: ");
        }

        return result;
    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Services;

internal class InputValidator
{
    public static string ValidateString(string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write($"String cannot be empty or Null.\nPlease enter a valid string:\t");
            input = Console.ReadLine();
        };

        return input;
    }
}

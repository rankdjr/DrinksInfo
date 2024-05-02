using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Services;

internal class InputValidator
{
    public static string GetInput(string message)
    {
        Console.Write($"{message}:\t");
        return Console.ReadLine();
    }

    public static int GetIntInput(string message)
    {
        Console.Write($"{message}:\t");
        return int.Parse(Console.ReadLine());
    }

    public static double GetDoubleInput(string message)
    {
        Console.Write($"{message}:\t");
        return double.Parse(Console.ReadLine());
    }
}

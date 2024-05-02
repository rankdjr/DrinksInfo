using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Services;

public class InputHandler
{
    DrinksService drinksService = new DrinksService();

    public string GetInput(string message)
    {
        Console.Write($"{message}:\t");
        var input = Console.ReadLine();
        input = InputValidator.ValidateString(input);
        return input;
    }

    public int GetIntInput(string message)
    {
        Console.Write($"{message}:\t");
        return int.Parse(Console.ReadLine());
    }

    public double GetDoubleInput(string message)
    {
        Console.Write($"{message}:\t");
        return double.Parse(Console.ReadLine());
    }

    public void GetCategoriesInput()
    {
        drinksService.GetCategories();
    }
}

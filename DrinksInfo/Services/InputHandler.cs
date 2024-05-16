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
        string input = InputValidator.ValidateString();
        return input;
    }

    public int GetIntInput(string message)
    {
        Console.Write($"{message}:\t");
        int input = InputValidator.ValidateInteger();
        return input;
    }

    public void GetCategoriesInput()
    {
        drinksService.GetCategories();
    }
}

using DrinksInfo.Services;
using Microsoft.VisualBasic;

namespace DrinksInfo.Application;

public class App
{
    DrinksService drinksService;
    TableVisualization tableVisualization;
    InputHandler inputHandler;

    public App()
    {
        drinksService = new DrinksService();
        tableVisualization = new TableVisualization();
        inputHandler = new InputHandler();
    }

    public void Run()
    {
        Utilities.PrintNewLines(2);
        Console.WriteLine("Welcome to Drinks Info!");
        Utilities.PrintNewLines(1);

        var categoriesList = drinksService.GetCategories();
        tableVisualization.ShowTable(categoriesList, "Categories");
        Utilities.PrintNewLines(1);

        string category = inputHandler.GetInput("Enter a category to see drinks");
        Utilities.PrintNewLines(1);

        var drinksList = drinksService.GetDrinksByCategory(category);
        tableVisualization.ShowTable(drinksList, "Drinks");
        Utilities.PrintNewLines(1);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

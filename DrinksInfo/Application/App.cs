using DrinksInfo.Services;
using Microsoft.VisualBasic;

namespace DrinksInfo.Application;

public class App
{
    DrinksService drinksService;
    TableVisualization tableVisualization;

    public App()
    {
        drinksService = new DrinksService();
        tableVisualization = new TableVisualization();
    }

    public void Run()
    {
        Utilities.PrintNewLines(2);
        Console.WriteLine("Welcome to Drinks Info!");
        Utilities.PrintNewLines(1);

        var categoriesList = drinksService.GetCategories();
        tableVisualization.ShowTable(categoriesList, "Categories");
        Utilities.PrintNewLines(1);
    }
}

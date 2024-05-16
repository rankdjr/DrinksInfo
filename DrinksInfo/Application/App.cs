using DrinksInfo.Services;

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
        while (true)
        {
            Console.Clear();
            Utilities.PrintNewLines(2);
            Console.WriteLine("Welcome to Drinks Info!");
            Utilities.PrintNewLines(1);

            var categoriesList = drinksService.GetCategories();
            tableVisualization.ShowTable(categoriesList, "Categories");
            Utilities.PrintNewLines(1);

            string category = inputHandler.GetInput("Enter a category to see drinks or 0 to exit application");
            Utilities.PrintNewLines(1);
            if (category == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            var drinksList = drinksService.GetDrinksByCategory(category);
            if (drinksList.Count == 0)
            {
                Console.WriteLine($"No drinks found for category, {category}.");
                Utilities.PrintNewLines(1);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
            tableVisualization.ShowTable(drinksList, "Drinks");
            Utilities.PrintNewLines(1);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // TODO: Select drink by ID and show details
            int drinkId = inputHandler.GetIntInput("Enter drink ID to see details or 0 to return to categories");
            if (!drinksList.Any(drink => drink.idDrink == drinkId.ToString()))
            {
                Console.WriteLine("Drink ID not found in available list.");
                continue;
            }

            var ingreadientsList = drinksService.GetIngredientsByDrinkId(drinkId);
            Utilities.PrintNewLines(1);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

using Newtonsoft.Json;
using RestSharp;
using DrinksInfo.Models;

namespace DrinksInfo.Services;

public class DrinksService
{
    public List<DrinkCategory> GetCategories()
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list", Method.Get);

        try
        {
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                var categoriesResponse = JsonConvert.DeserializeObject<DrinkCategoriesResponse>(rawResponse);

                if (categoriesResponse != null && categoriesResponse.Categories != null)
                {
                    List<DrinkCategory> categories = categoriesResponse.Categories;
                    return categoriesResponse.Categories;

                }
                else
                {
                    Console.WriteLine("No categories found or bad JSON format.");
                }
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }

            return new List<DrinkCategory>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return new List<DrinkCategory>();
        }
    }
}

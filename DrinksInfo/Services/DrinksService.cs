﻿using Newtonsoft.Json;
using RestSharp;
using DrinksInfo.Models;
using System.Web;

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

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return new List<DrinkCategory>();
            }

            if (response.Content == null)
            {
                Console.WriteLine("No content found.");
                return new List<DrinkCategory>();
            }

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
                return new List<DrinkCategory>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return new List<DrinkCategory>();
        }
    }

    public List<Drink> GetDrinksByCategory(string category)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}", Method.Get);

        try
        {
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return new List<Drink>();
            }

            if (response.Content == null)
            {
                Console.WriteLine("No content found.");
                return new List<Drink>();
            }

            string rawResponse = response.Content;
            var seriliaze = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            if (seriliaze != null && seriliaze.drinks != null)
            {
                List<Drink> drinks = seriliaze.drinks;
                return drinks;

            }
            else
            {
                Console.WriteLine("No categories found or bad JSON format.");
                return new List<Drink>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return new List<Drink>();
        }
    }

    public Drink? GetIngredientsByDrinkId(int id)
    {
        var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={id}", Method.Get);

        try
        {
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return null;
            }

            if (response.Content == null)
            {
                Console.WriteLine("No content found.");
                return null;
            }

            
            string rawResponse = response.Content;
            var seriliaze = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            if (seriliaze != null && seriliaze.drinks != null && seriliaze.drinks.Count > 0)
            {
                Drink drink = seriliaze.drinks[0];
                return drink;
            }
            else
            {
                Console.WriteLine("No drink found or bad JSON format.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }
}

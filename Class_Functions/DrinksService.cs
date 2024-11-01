using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using DrinksInfo.Class_Objects;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo;

public class DrinksService
{
    public List<Category> GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);
        List<Category> returnedList = new List<Category>();

        if (response.Result != null && response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Result.Content;

            // var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse ?? string.Empty);

            // returnedList = serialize?.CategoriesList ?? new List<Category>();
            var rootObject = JsonConvert.DeserializeObject<Dictionary<string, List<Category>>>(rawResponse ?? string.Empty);

            returnedList = rootObject?["drinks"] ?? new List<Category>();

            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].ID = i + 1;
            }
        }
        return returnedList;
    }

    public List<Drink> GetDrinksByCategory(string categoryName)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={categoryName}");
        var response = client.ExecuteAsync(request);
        List<Drink> returnedList = new List<Drink>();

        if (response.Result != null && response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Result.Content;

            // var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse ?? string.Empty);
            var rootObject = JsonConvert.DeserializeObject<Dictionary<string, List<Drink>>>(rawResponse ?? string.Empty);

            returnedList = rootObject?["drinks"] ?? new List<Drink>();

            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].ID = i + 1;
            }
        }
        return returnedList;
    }

    public Drink? GetDrink(int idDrink)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={idDrink}");
        var response = client.ExecuteAsync(request);
        // Drink drink = new Drink();

        if (response.Result != null && response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Result.Content;

            var rootObject = JsonConvert.DeserializeObject<DrinkResponse>(rawResponse ?? string.Empty);

            return rootObject?.Drinks.FirstOrDefault();
        }
        return null;
    }
}

//  // This is the key change - we create an anonymous type to match the JSON structure
// var rootObject = JsonConvert.DeserializeObject<Dictionary<string, List<Category>>>(rawResponse ?? string.Empty);

// // Get the "drinks" list directly
// returnedList = rootObject?["drinks"] ?? new List<Category>();
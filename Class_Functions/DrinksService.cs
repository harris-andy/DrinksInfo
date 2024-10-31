using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DrinksInfo.Class_Objects;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo;

public class DrinksService
{
    public List<Category> GetCategories()
    {
        // www.thecocktaildb.com/api/json/v1/1/list.php?c=list
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);
        List<Category> returnedList = new List<Category>();

        if (response.Result != null && response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string? rawResponse = response.Result.Content;

            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse ?? string.Empty);

            returnedList = serialize?.CategoriesList ?? new List<Category>();

            // TableVisualizationEngine.ShowTable(returnedList, "Categories Name");

            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].ID = i + 1;
            }
            // DisplayData.ShowCategories(returnedList);
            // return returnedList;
        }
        return returnedList;
    }
}
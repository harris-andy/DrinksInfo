using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksInfo.Class_Objects;
using Microsoft.VisualBasic;

namespace DrinksInfo;

public class Controller
{
    DrinksService drinksService = new();
    UserInput userInput = new();

    internal void ShowCategories()
    {
        var categoryList = drinksService.GetCategories();
        DisplayData.ShowCategories(categoryList);
        // get menu choice
        GetCategory(categoryList);
    }

    internal void GetCategory(List<Category> categoryList)
    {
        int high = categoryList.Count();
        int menuChoice = userInput.GetMenuChoice(1, high, "Select a category by ID:");

    }

    // get user's selection for category

    // run another http request to get drinks from that category

    // display list of drinks

    // get user's selection for drink recipe

    // run another http request for drink recipe

    // display drink recipe
}
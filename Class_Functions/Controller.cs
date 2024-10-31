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
        List<Category> categoryList = drinksService.GetCategories();
        // DisplayData.ShowCategories(categoryList);
        DisplayData.ShowTable(categoryList, "Drink Categories",
            cat => cat.ID.ToString(),
            cat => cat.StrCategory);

        GetCategory(categoryList);
    }

    internal void GetCategory(List<Category> categoryList)
    {
        int high = categoryList.Count();
        int menuChoice = userInput.GetMenuChoice(1, high, "Select a category by ID:");
        string category = categoryList
            .Where(cat => cat.ID == menuChoice)
            .Select(cat => cat.StrCategory)
            .First();
        GetDrinks(category);
    }

    internal void GetDrinks(string category)
    {
        List<Drinks> drinksList = drinksService.GetDrinksByCategory(category);
        // DisplayData.ShowDrinks(drinksList);
        DisplayData.ShowTable(drinksList, "Drinks",
            drink => drink.ID.ToString(),
            drink => drink.StrDrink);
    }



    // get user's selection for drink recipe

    // run another http request for drink recipe

    // display drink recipe
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksInfo.Class_Objects;
using Microsoft.VisualBasic;
using System.Data;
using System.Security.Cryptography;

namespace DrinksInfo;

public class Controller
{
    DrinksService drinksService = new();
    UserInput userInput = new();
    DisplayData display = new();

    internal void ShowCategories()
    {
        List<Category> categoryList = drinksService.GetCategories();
        // DisplayData.ShowCategories(categoryList);
        display.ShowTable(categoryList, "Drink Categories",
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
        List<Drink> drinksList = drinksService.GetDrinksByCategory(category);
        ShowDrinks(drinksList);
    }

    internal void ShowDrinks(List<Drink> drinksList)
    {
        display.ShowTable(drinksList, "Drinks",
            drink => drink.ID.ToString(),
            drink => drink.StrDrink);

        GetDrinkInfo(drinksList);
    }

    internal void GetDrinkInfo(List<Drink> drinksList)
    {
        int menuChoice = userInput.GetMenuChoice(1, drinksList.Count(), "Select a drink by ID:");
        (int idDrink, string drinkName) = drinksList
            .Where(drink => drink.ID == menuChoice)
            .Select(drink => (drink.DrinkID, drink.StrDrink))
            .First();

        Drink drinkInfo = drinksService.GetDrink(idDrink) switch
        {
            null => throw new InvalidOperationException($"{drinkName} was not found"),
            Drink drink => drink
        };

        if (drinkInfo != null)
        {
            // Console.WriteLine($"Drink name: {drinkName}");
            // Console.WriteLine($"Drink ID: {idDrink}");
            // Console.WriteLine($"DrinkInfo: {drinkInfo.Instructions}");
            // // Console.WriteLine($"Ingredients: {drinkInfo.Ingredients}");
            // // Console.WriteLine($"Ingredients: {drinkInfo.Measures}");
            // // drinkInfo.CreateIngredientMeasures();
            // // Console.WriteLine($"Debug - Number of ingredients: {drinkInfo.Ingredients?.Count ?? 0}");
            // // Console.WriteLine($"Debug - Number of measures: {drinkInfo.Measures?.Count ?? 0}");
            // // Console.WriteLine("\nIngredients:");
            // Console.WriteLine($"Deserialized ingredients count: {drinkInfo.Ingredients?.Count}");
            // foreach (var ing in drinkInfo.Ingredients ?? new List<string>())
            // {
            //     Console.WriteLine($"Ingredient: {ing}");
            // }


            ShowDrinkInfo(drinkInfo);
        }
    }

    internal void ShowDrinkInfo(Drink drinkInfo)
    {

    }



    // get user's selection for drink recipe

    // run another http request for drink recipe

    // display drink recipe
}
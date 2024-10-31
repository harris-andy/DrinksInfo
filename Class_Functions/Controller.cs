using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinksInfo;

public class Controller
{
    DrinksService drinksService = new();

    internal void ShowCategories()
    {
        // drinksService.GetCategories();
        var categoryList = drinksService.GetCategories();
        DisplayData.ShowCategories(categoryList);
    }
}
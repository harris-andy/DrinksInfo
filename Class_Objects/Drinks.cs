using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects;

public class Drink
{
    public int ID { get; set; }

    [JsonProperty("strDrink")]
    public string StrDrink { get; set; } = null!;

    [JsonProperty("idDrink")]
    public int DrinkID { get; set; }

    // strDrink, idDrinnk, strGlass, strInstructions, List<strIngredient>, List<strMeasure>
    // [JsonProperty("idDrink")]
    // public int idDrink { get; set; }

    // [JsonProperty("strDrink")]
    // public string DrinkName { get; set; } = null!;

    [JsonProperty("strGlass")]
    public string Glass { get; set; } = null!;

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = null!;

    [JsonConverter(typeof(NumberedStringListConverter), "strIngredient")]
    public List<string> Ingredient { get; set; } = null!;

    [JsonConverter(typeof(NumberedStringListConverter), "strMeasure")]
    public List<string> Measure { get; set; } = null!;

    // [JsonConverter(typeof(NumberedStringListConverter), "strIngredient")]
    // public List<string> Ingredient { get; set; }

    public void CreateIngredientMeasures()
    {
        // List<string> ingredients = Ingredient
        //     .Where(ing => ing != null)
        //     .Select(ing => ing);
    }

    // (int idDrink, string drinkName) = drinksList
    //         .Where(drink => drink.ID == menuChoice)
    //         .Select(drink => (drink.DrinkID, drink.StrDrink))
    //         .First();
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects;

public class Drinks
{
    public int ID { get; set; }

    [JsonProperty("strDrink")]
    public string StrDrink { get; set; } = null!;

    [JsonProperty("idDrink")]
    public int DrinkID { get; set; }
}

public class Drink
{
    // strDrink, idDrinnk, strGlass, strInstructions, List<strIngredient>, List<strMeasure>
    [JsonProperty("idDrink")]
    public int idDrink { get; set; }

    [JsonProperty("strDrink")]
    public string DrinkName { get; set; } = null!;

    [JsonProperty("strGlass")]
    public string Glass { get; set; } = null!;

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = null!;

    [JsonProperty("strIngredient")]
    public string Ingredient { get; set; } = null!;

    [JsonProperty("strMeasure")]
    public string Measure { get; set; } = null!;
}
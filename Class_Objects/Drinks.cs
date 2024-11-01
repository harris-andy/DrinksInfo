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

    [JsonProperty("strGlass")]
    public string Glass { get; set; } = null!;

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = null!;

    // [JsonConverter(typeof(NumberedStringListConverter), "strIngredient")]
    [JsonProperty("strIngredient")]
    public string Ingredient1 { get; set; } = string.Empty;

    // [JsonConverter(typeof(NumberedStringListConverter), "strMeasure")]
    [JsonProperty("strMeasure")]
    public string Measure { get; set; } = string.Empty;

}
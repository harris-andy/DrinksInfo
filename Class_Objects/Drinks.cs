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

    [JsonConverter(typeof(NumberedStringListConverter), "strIngredient")]
    public List<string> Ingredients { get; set; } = new();

    [JsonConverter(typeof(NumberedStringListConverter), "strMeasure")]
    public List<string> Measures { get; set; } = new();

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects;

public class Drink
{
    public string DrinkDrink { get; set; } = null!;
}

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> CategoriesList { get; set; } = null!;
}
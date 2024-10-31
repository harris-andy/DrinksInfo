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
    public string DrinkDrink { get; set; } = null!;

    [JsonProperty("idDrink")]
    public int DrinkID { get; set; }
}

// public class Drinks
// {
//     [JsonProperty("drinks")]
//     public List<Drink> CategoriesList { get; set; } = null!;
// }
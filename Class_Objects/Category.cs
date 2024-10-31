using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects;

public class Category
{
    [JsonProperty("strCategory")]
    public string StrCategory { get; set; } = null!;
    public int ID { get; set; }
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; } = null!;
}
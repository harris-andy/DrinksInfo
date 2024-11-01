using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects
{
    public class DrinkResponse
    {
        [JsonProperty("drinks")]
        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }

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

        [JsonProperty("strIngredient1")]
        public string? Ingredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string? Ingredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string? Ingredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string? Ingredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string? Ingredient5 { get; set; }

        [JsonProperty("strIngredient6")]
        public string? Ingredient6 { get; set; }

        [JsonProperty("strIngredient7")]
        public string? Ingredient7 { get; set; }

        [JsonProperty("strIngredient8")]
        public string? Ingredient8 { get; set; }

        [JsonProperty("strIngredient9")]
        public string? Ingredient9 { get; set; }

        [JsonProperty("strIngredient10")]
        public string? Ingredient10 { get; set; }

        [JsonProperty("strIngredient11")]
        public string? Ingredient11 { get; set; }

        [JsonProperty("strIngredient12")]
        public string? Ingredient12 { get; set; }

        [JsonProperty("strIngredient13")]
        public string? Ingredient13 { get; set; }

        [JsonProperty("strIngredient14")]
        public string? Ingredient14 { get; set; }

        [JsonProperty("strIngredient15")]
        public string? Ingredient15 { get; set; }

        [JsonProperty("strMeasure1")]
        public string? Measure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string? Measure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string? Measure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string? Measure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string? Measure5 { get; set; }

        [JsonProperty("strMeasure6")]
        public string? Measure6 { get; set; }

        [JsonProperty("strMeasure7")]
        public string? Measure7 { get; set; }

        [JsonProperty("strMeasure8")]
        public string? Measure8 { get; set; }

        [JsonProperty("strMeasure9")]
        public string? Measure9 { get; set; }

        [JsonProperty("strMeasure10")]
        public string? Measure10 { get; set; }

        [JsonProperty("strMeasure11")]
        public string? Measure11 { get; set; }

        [JsonProperty("strMeasure12")]
        public string? Measure12 { get; set; }

        [JsonProperty("strMeasure13")]
        public string? Measure13 { get; set; }

        [JsonProperty("strMeasure14")]
        public string? Measure14 { get; set; }

        [JsonProperty("strMeasure15")]
        public string? Measure15 { get; set; }

        public List<string?> Ingredients => new List<string?> {
            Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5,
            Ingredient6, Ingredient7, Ingredient8, Ingredient9, Ingredient10,
            Ingredient11, Ingredient12, Ingredient13, Ingredient14, Ingredient15
        }.FindAll(i => !string.IsNullOrEmpty(i));

        public List<string?> Measures => new List<string?> {
            Measure1, Measure2, Measure3, Measure4, Measure5,
            Measure6, Measure7, Measure8, Measure9, Measure10,
            Measure11, Measure12, Measure13, Measure14, Measure15
        }.FindAll(m => !string.IsNullOrEmpty(m));

        public List<string> CombinedIngMsrList { get; set; } = new List<string>();

        public void CombineIngredientsMeasures()
        {
            for (int i = 0; i < Ingredients.Count(); i++)
            {
                string combo = $"{Ingredients[i]}: {Measures[i]}";
                CombinedIngMsrList.Add(combo);
            }
        }
    }

}

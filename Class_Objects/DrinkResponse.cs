using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects
{
    public class DrinkResponse
    {
        [JsonProperty("drinks")]
        public List<Drink>? Drinks { get; set; }
    }
}
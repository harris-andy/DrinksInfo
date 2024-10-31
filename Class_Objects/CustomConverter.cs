using System;
using System.Collections.Generic;
using System.Linq;
// using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace DrinksInfo.Class_Objects;

public class NumberedStringListConverter : JsonConverter<List<string>>
{
    private readonly string propertyPrefix;

    public NumberedStringListConverter(string prefix)
    {
        propertyPrefix = prefix;
    }

    public override List<string> ReadJson(
        JsonReader reader,
        Type objectType,
        List<string>? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        // This is where you'll handle the numbered properties
        // You'll want to look at the JObject and find properties starting with your prefix

        // First, we need to read the whole JSON object
        var jObject = JObject.Load(reader);

        // Now we need to:
        // 1. Find all properties that start with our prefix (like "strIngredient")
        List<string> ingredientsMeasures = (List<string>)jObject.Properties()
            .Where(prop => prop.Name.StartsWith(propertyPrefix) && prop.Name != null)
            .Select(prop => prop.Value.ToString());

        // We still need to handle nulls here
        // 2. Get their values
        // 3. Filter out the nulls
        // 4. Put them in a list
        return ingredientsMeasures;
    }

    public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        // if (reader.TokenType == JsonToken.Null)
        //     return new List<string>();

        var items = new List<string>();
        var jObject = JObject.Load(reader);

        // If we're at a property value, we need to start reading from the parent
        for (int i = 1; i <= 15; i++)
        {
            var propertyName = $"{propertyPrefix}{i}";
            var value = jObject[propertyName]?.ToString();

            if (string.IsNullOrWhiteSpace(value))
                continue;

            items.Add(value);
        }

        return items;
    }

    public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanWrite => false;
}
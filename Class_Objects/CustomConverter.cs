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
        Console.WriteLine($"[Converter] Constructor called with prefix: {prefix}");
        propertyPrefix = prefix;
    }

    public override bool CanRead => true;

    public override List<string> ReadJson(
        JsonReader reader,
        Type objectType,
        List<string>? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        Console.WriteLine($"[Converter] ReadJson called for prefix: {propertyPrefix}");
        Console.WriteLine($"[Converter] Reader TokenType: {reader.TokenType}");
        Console.WriteLine($"[Converter] Reader Path: {reader.Path}");

        var items = new List<string>();

        try
        {
            var jObject = JObject.Load(reader);
            Console.WriteLine("[Converter] Successfully loaded JObject");
            Console.WriteLine("[Converter] Available properties:");
            foreach (var prop in jObject.Properties())
            {
                Console.WriteLine($"- {prop.Name}: {prop.Value}");
            }

            for (int i = 1; i <= 15; i++)
            {
                var propertyName = $"{propertyPrefix}{i}";
                Console.WriteLine($"[Converter] Looking for property: {propertyName}");

                var token = jObject[propertyName];
                if (token != null)
                {
                    Console.WriteLine($"[Converter] Found token type: {token.Type}");
                    var value = token.ToString();
                    Console.WriteLine($"[Converter] Value: {value}");

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine($"[Converter] Adding value to list: {value}");
                        items.Add(value);
                    }
                }
                else
                {
                    Console.WriteLine($"[Converter] Property {propertyName} not found");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Converter] Error: {ex.Message}");
            Console.WriteLine($"[Converter] Stack trace: {ex.StackTrace}");
        }

        Console.WriteLine($"[Converter] Final list count: {items.Count}");
        return items;
    }

    public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanWrite => false;
}
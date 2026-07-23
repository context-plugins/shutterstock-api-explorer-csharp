using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Models.AnyOf;

[JsonConverter(typeof(Region1ModelConverter))]
public record Region1Model
{
    private readonly Optional<string> _stringValue;

    private Region1Model(Optional<string> stringValue)
    {
        _stringValue = stringValue;
    }

    public static Region1Model String(string value) => new(Optional<string>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator Region1Model(string value) => String(value);
}

file sealed class Region1ModelConverter : JsonConverter<Region1Model>
{
    public override Region1Model Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            return Region1Model.String(value);
        }
        throw new JsonException($"JSON does not match string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Region1Model value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Region1Model)} contains no valid value to serialize.");
        }
    }
}

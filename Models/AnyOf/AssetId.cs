using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Models.AnyOf;

[JsonConverter(typeof(AssetIdConverter))]
public record AssetId
{
    private readonly Optional<string> _stringValue;

    private AssetId(Optional<string> stringValue)
    {
        _stringValue = stringValue;
    }

    public static AssetId String(string value) => new(Optional<string>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator AssetId(string value) => String(value);
}

file sealed class AssetIdConverter : JsonConverter<AssetId>
{
    public override AssetId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind == JsonValueKind.String)
        {
            var value = root.GetString()!;
            return AssetId.String(value);
        }
        throw new JsonException($"JSON does not match string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, AssetId value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(AssetId)} contains no valid value to serialize.");
        }
    }
}

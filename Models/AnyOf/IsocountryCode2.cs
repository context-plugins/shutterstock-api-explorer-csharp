using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Extensions;
using ShutterstockApiExplorer.Core.Models;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models.AnyOf;

/// <summary>
/// A valid ISO 3166-1 Alpha-2 or ISO 3166-1 Alpha-3 code.
/// </summary>
[JsonConverter(typeof(IsocountryCode2Converter))]
public record IsocountryCode2
{
    private readonly Optional<IsocountryCode> _isocountryCodeValue;

    private readonly Optional<IsocountryCode1> _isocountryCode1Value;

    private IsocountryCode2(Optional<IsocountryCode> isocountryCodeValue,
        Optional<IsocountryCode1> isocountryCode1Value)
    {
        _isocountryCodeValue = isocountryCodeValue;
        _isocountryCode1Value = isocountryCode1Value;
    }

    public static IsocountryCode2 IsocountryCode(IsocountryCode value) =>
        new(Optional<IsocountryCode>.Some(value), default);

    public static IsocountryCode2 IsocountryCode1(IsocountryCode1 value) =>
        new(default, Optional<IsocountryCode1>.Some(value));

    public bool TryGetIsocountryCode(out IsocountryCode value) => _isocountryCodeValue.TryGetValue(out value);

    public bool TryGetIsocountryCode1(out IsocountryCode1 value) =>
        _isocountryCode1Value.TryGetValue(out value);

    public static implicit operator IsocountryCode2(IsocountryCode value) => IsocountryCode(value);

    public static implicit operator IsocountryCode2(IsocountryCode1 value) => IsocountryCode1(value);
}

file sealed class IsocountryCode2Converter : JsonConverter<IsocountryCode2>
{
    public override IsocountryCode2 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<IsocountryCode>(root, options, out var isocountryCodeValue))
        {
            return IsocountryCode2.IsocountryCode(isocountryCodeValue);
        }
        if (JsonSerializer.TryDeserialize<IsocountryCode1>(root, options, out var isocountryCode1Value))
        {
            return IsocountryCode2.IsocountryCode1(isocountryCode1Value);
        }
        throw new JsonException($"JSON does not match IsocountryCode or IsocountryCode1 schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, IsocountryCode2 value, JsonSerializerOptions options)
    {
        if (value.TryGetIsocountryCode(out var isocountryCodeValue))
        {
            JsonSerializer.Serialize(writer, isocountryCodeValue, options);
        }
        else if (value.TryGetIsocountryCode1(out var isocountryCode1Value))
        {
            JsonSerializer.Serialize(writer, isocountryCode1Value, options);
        }
        else
        {
            throw new JsonException($"{nameof(IsocountryCode2)} contains no valid value to serialize.");
        }
    }
}

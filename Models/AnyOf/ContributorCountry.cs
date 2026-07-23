using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Extensions;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Models.AnyOf;

/// <summary>
/// Show images from contributors in one or more specified countries, or start with NOT to exclude a country from the search
/// </summary>
[JsonConverter(typeof(ContributorCountryConverter))]
public record ContributorCountry
{
    private readonly Optional<IReadOnlyList<string>> _listOfStringValue;

    private ContributorCountry(Optional<IReadOnlyList<string>> listOfStringValue)
    {
        _listOfStringValue = listOfStringValue;
    }

    public static ContributorCountry ListOfString(IReadOnlyList<string> value) =>
        new(Optional<IReadOnlyList<string>>.Some(value));

    public bool TryGetListOfString(out IReadOnlyList<string> value) =>
        _listOfStringValue.TryGetValue(out value);
}

file sealed class ContributorCountryConverter : JsonConverter<ContributorCountry>
{
    public override ContributorCountry Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<IReadOnlyList<string>>(root, options, out var listOfStringValue))
        {
            return ContributorCountry.ListOfString(listOfStringValue);
        }
        throw new JsonException($"JSON does not match IReadOnlyList<string> schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, ContributorCountry value, JsonSerializerOptions options)
    {
        if (value.TryGetListOfString(out var listOfStringValue))
        {
            JsonSerializer.Serialize(writer, listOfStringValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(ContributorCountry)} contains no valid value to serialize.");
        }
    }
}

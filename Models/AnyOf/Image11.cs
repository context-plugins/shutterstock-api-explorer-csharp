using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Extensions;
using ShutterstockApiExplorer.Core.Models;

namespace ShutterstockApiExplorer.Models.AnyOf;

[JsonConverter(typeof(Image11Converter))]
public record Image11
{
    private readonly Optional<LicenseImage> _licenseImageValue;

    private readonly Optional<LicenseImageVector> _licenseImageVectorValue;

    private Image11(Optional<LicenseImage> licenseImageValue, Optional<LicenseImageVector> licenseImageVectorValue)
    {
        _licenseImageValue = licenseImageValue;
        _licenseImageVectorValue = licenseImageVectorValue;
    }

    public static Image11 LicenseImage(LicenseImage value) =>
        new(Optional<LicenseImage>.Some(value), default);

    public static Image11 LicenseImageVector(LicenseImageVector value) =>
        new(default, Optional<LicenseImageVector>.Some(value));

    public bool TryGetLicenseImage(out LicenseImage value) => _licenseImageValue.TryGetValue(out value);

    public bool TryGetLicenseImageVector(out LicenseImageVector value) =>
        _licenseImageVectorValue.TryGetValue(out value);

    public static implicit operator Image11(LicenseImage value) => LicenseImage(value);

    public static implicit operator Image11(LicenseImageVector value) => LicenseImageVector(value);
}

file sealed class Image11Converter : JsonConverter<Image11>
{
    public override Image11 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<LicenseImage>(root, options, out var licenseImageValue))
        {
            return Image11.LicenseImage(licenseImageValue);
        }
        if (JsonSerializer.TryDeserialize<LicenseImageVector>(root, options, out var licenseImageVectorValue))
        {
            return Image11.LicenseImageVector(licenseImageVectorValue);
        }
        throw new JsonException($"JSON does not match LicenseImage or LicenseImageVector schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Image11 value, JsonSerializerOptions options)
    {
        if (value.TryGetLicenseImage(out var licenseImageValue))
        {
            JsonSerializer.Serialize(writer, licenseImageValue, options);
        }
        else if (value.TryGetLicenseImageVector(out var licenseImageVectorValue))
        {
            JsonSerializer.Serialize(writer, licenseImageVectorValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Image11)} contains no valid value to serialize.");
        }
    }
}

using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// The scale quality; if this field is not specified, the API selects the quality automatically
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TonicQuality>))]
public sealed record TonicQuality : StringEnum<TonicQuality>
{
    private TonicQuality(string value) : base(value)
    {
    }

    public static readonly TonicQuality Major = new("major");

    public static readonly TonicQuality NaturalMinor = new("natural_minor");

    public static readonly TonicQuality HarmonicMinor = new("harmonic_minor");

    public static readonly TonicQuality MelodicMinor = new("melodic_minor");

    public static readonly TonicQuality Ionian = new("ionian");

    public static readonly TonicQuality Dorian = new("dorian");

    public static readonly TonicQuality Phrygian = new("phrygian");

    public static readonly TonicQuality Lydian = new("lydian");

    public static readonly TonicQuality Mixolydian = new("mixolydian");

    public static readonly TonicQuality Aeolian = new("aeolian");

    public static readonly TonicQuality Locrian = new("locrian");

    public static TonicQuality FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// A text representation of the accidental; if this field is specified, the tonic_note field should also be specified
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TonicAccidental>))]
public sealed record TonicAccidental : StringEnum<TonicAccidental>
{
    private TonicAccidental(string value) : base(value)
    {
    }

    public static readonly TonicAccidental DoubleFlat = new("double flat");

    public static readonly TonicAccidental Flat = new("flat");

    public static readonly TonicAccidental Natural = new("natural");

    public static readonly TonicAccidental Sharp = new("sharp");

    public static readonly TonicAccidental DoubleSharp = new("double sharp");

    public static TonicAccidental FromValue(string value) => FromValueCore(value);
}

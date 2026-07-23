using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// A text representation of the musical note; if this field is specified, the tonic_accidental field should also be specified
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TonicNote>))]
public sealed record TonicNote : StringEnum<TonicNote>
{
    private TonicNote(string value) : base(value)
    {
    }

    public static readonly TonicNote C = new("c");

    public static readonly TonicNote D = new("d");

    public static readonly TonicNote E = new("e");

    public static readonly TonicNote F = new("f");

    public static readonly TonicNote G = new("g");

    public static readonly TonicNote A = new("a");

    public static readonly TonicNote B = new("b");

    public static TonicNote FromValue(string value) => FromValueCore(value);
}

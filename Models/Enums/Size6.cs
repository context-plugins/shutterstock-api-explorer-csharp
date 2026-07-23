using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Size of the image
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size6>))]
public sealed record Size6 : StringEnum<Size6>
{
    private Size6(string value) : base(value)
    {
    }

    public static readonly Size6 Small = new("small");

    public static readonly Size6 Medium = new("medium");

    public static readonly Size6 Huge = new("huge");

    public static readonly Size6 Supersize = new("supersize");

    public static readonly Size6 Vector = new("vector");

    public static Size6 FromValue(string value) => FromValueCore(value);
}

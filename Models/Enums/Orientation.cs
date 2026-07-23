using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Show image results with horizontal or vertical orientation
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Orientation>))]
public sealed record Orientation : StringEnum<Orientation>
{
    private Orientation(string value) : base(value)
    {
    }

    public static readonly Orientation Horizontal = new("horizontal");

    public static readonly Orientation Vertical = new("vertical");

    public static Orientation FromValue(string value) => FromValueCore(value);
}

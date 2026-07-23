using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Image size to download
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size2>))]
public sealed record Size2 : StringEnum<Size2>
{
    private Size2(string value) : base(value)
    {
    }

    public static readonly Size2 Small = new("small");

    public static readonly Size2 Medium = new("medium");

    public static readonly Size2 Huge = new("huge");

    public static readonly Size2 Custom = new("custom");

    public static Size2 FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Asset size to download
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size>))]
public sealed record Size : StringEnum<Size>
{
    private Size(string value) : base(value)
    {
    }

    public static readonly Size Small = new("small");

    public static readonly Size Medium = new("medium");

    public static readonly Size Original = new("original");

    public static Size FromValue(string value) => FromValueCore(value);
}

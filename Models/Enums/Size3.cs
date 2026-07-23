using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Image size to download
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size3>))]
public sealed record Size3 : StringEnum<Size3>
{
    private Size3(string value) : base(value)
    {
    }

    public static readonly Size3 Vector = new("vector");

    public static Size3 FromValue(string value) => FromValueCore(value);
}

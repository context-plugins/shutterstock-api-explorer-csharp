using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// (Deprecated) Image format to download
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Format1>))]
public sealed record Format1 : StringEnum<Format1>
{
    private Format1(string value) : base(value)
    {
    }

    public static readonly Format1 Eps = new("eps");

    public static Format1 FromValue(string value) => FromValueCore(value);
}

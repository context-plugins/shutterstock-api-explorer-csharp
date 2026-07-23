using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Asset size to download
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size1>))]
public sealed record Size1 : StringEnum<Size1>
{
    private Size1(string value) : base(value)
    {
    }

    public static readonly Size1 Original = new("original");

    public static Size1 FromValue(string value) => FromValueCore(value);
}

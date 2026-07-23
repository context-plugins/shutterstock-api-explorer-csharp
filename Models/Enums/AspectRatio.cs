using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AspectRatio>))]
public sealed record AspectRatio : StringEnum<AspectRatio>
{
    private AspectRatio(string value) : base(value)
    {
    }

    public static readonly AspectRatio _43 = new("4_3");

    public static readonly AspectRatio _169 = new("16_9");

    public static readonly AspectRatio Nonstandard = new("nonstandard");

    public static AspectRatio FromValue(string value) => FromValueCore(value);
}

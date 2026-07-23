using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Size9>))]
public sealed record Size9 : StringEnum<Size9>
{
    private Size9(string value) : base(value)
    {
    }

    public static readonly Size9 Web = new("web");

    public static readonly Size9 Sd = new("sd");

    public static readonly Size9 Hd = new("hd");

    public static readonly Size9 _4K = new("4k");

    public static Size9 FromValue(string value) => FromValueCore(value);
}

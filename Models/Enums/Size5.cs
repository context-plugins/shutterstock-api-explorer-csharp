using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Size of the video being licensed
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size5>))]
public sealed record Size5 : StringEnum<Size5>
{
    private Size5(string value) : base(value)
    {
    }

    public static readonly Size5 Web = new("web");

    public static readonly Size5 Sd = new("sd");

    public static readonly Size5 Hd = new("hd");

    public static readonly Size5 _4K = new("4k");

    public static Size5 FromValue(string value) => FromValueCore(value);
}

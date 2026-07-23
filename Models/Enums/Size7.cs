using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Size of the video
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Size7>))]
public sealed record Size7 : StringEnum<Size7>
{
    private Size7(string value) : base(value)
    {
    }

    public static readonly Size7 Web = new("web");

    public static readonly Size7 Sd = new("sd");

    public static readonly Size7 Hd = new("hd");

    public static readonly Size7 _4K = new("4k");

    public static Size7 FromValue(string value) => FromValueCore(value);
}

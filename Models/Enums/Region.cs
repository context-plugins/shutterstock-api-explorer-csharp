using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// The type of region
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Region>))]
public sealed record Region : StringEnum<Region>
{
    private Region(string value) : base(value)
    {
    }

    public static readonly Region Music = new("music");

    public static readonly Region Silence = new("silence");

    public static Region FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Media type of the license
/// </summary>
[JsonConverter(typeof(StringEnumConverter<MediaType>))]
public sealed record MediaType : StringEnum<MediaType>
{
    private MediaType(string value) : base(value)
    {
    }

    public static readonly MediaType Image = new("image");

    public static readonly MediaType Video = new("video");

    public static readonly MediaType Audio = new("audio");

    public static readonly MediaType Editorial = new("editorial");

    public static MediaType FromValue(string value) => FromValueCore(value);
}

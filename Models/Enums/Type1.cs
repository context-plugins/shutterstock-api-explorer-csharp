using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type1>))]
public sealed record Type1 : StringEnum<Type1>
{
    private Type1(string value) : base(value)
    {
    }

    public static readonly Type1 Image = new("image");

    public static readonly Type1 Video = new("video");

    public static readonly Type1 Audio = new("audio");

    public static readonly Type1 EditorialImage = new("editorial-image");

    public static readonly Type1 EditorialVideo = new("editorial-video");

    public static Type1 FromValue(string value) => FromValueCore(value);
}

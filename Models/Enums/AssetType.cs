using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AssetType>))]
public sealed record AssetType : StringEnum<AssetType>
{
    private AssetType(string value) : base(value)
    {
    }

    public static readonly AssetType Image = new("image");

    public static readonly AssetType Video = new("video");

    public static readonly AssetType Audio = new("audio");

    public static readonly AssetType Elements = new("elements");

    public static readonly AssetType EditorialImage = new("editorial-image");

    public static readonly AssetType EditorialVideo = new("editorial-video");

    public static AssetType FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<AssetHint>))]
public sealed record AssetHint : StringEnum<AssetHint>
{
    private AssetHint(string value) : base(value)
    {
    }

    public static readonly AssetHint _1X = new("1x");

    public static readonly AssetHint _2X = new("2x");

    public static AssetHint FromValue(string value) => FromValueCore(value);
}

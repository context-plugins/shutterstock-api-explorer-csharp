using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Embed>))]
public sealed record Embed : StringEnum<Embed>
{
    private Embed(string value) : base(value)
    {
    }

    public static readonly Embed ShareCode = new("share_code");

    public static readonly Embed ShareUrl = new("share_url");

    public static Embed FromValue(string value) => FromValueCore(value);
}

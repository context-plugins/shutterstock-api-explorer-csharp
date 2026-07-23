using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Embed3>))]
public sealed record Embed3 : StringEnum<Embed3>
{
    private Embed3(string value) : base(value)
    {
    }

    public static readonly Embed3 ShareUrl = new("share_url");

    public static Embed3 FromValue(string value) => FromValueCore(value);
}

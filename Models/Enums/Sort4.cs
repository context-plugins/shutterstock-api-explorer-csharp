using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort4>))]
public sealed record Sort4 : StringEnum<Sort4>
{
    private Sort4(string value) : base(value)
    {
    }

    public static readonly Sort4 Newest = new("newest");

    public static readonly Sort4 Popular = new("popular");

    public static readonly Sort4 Relevance = new("relevance");

    public static readonly Sort4 Random = new("random");

    public static Sort4 FromValue(string value) => FromValueCore(value);
}

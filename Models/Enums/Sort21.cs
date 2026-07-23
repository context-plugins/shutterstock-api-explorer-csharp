using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort21>))]
public sealed record Sort21 : StringEnum<Sort21>
{
    private Sort21(string value) : base(value)
    {
    }

    public static readonly Sort21 Popular = new("popular");

    public static readonly Sort21 Newest = new("newest");

    public static readonly Sort21 Relevance = new("relevance");

    public static readonly Sort21 Random = new("random");

    public static readonly Sort21 Oldest = new("oldest");

    public static Sort21 FromValue(string value) => FromValueCore(value);
}

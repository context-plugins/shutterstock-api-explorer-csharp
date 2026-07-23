using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort10>))]
public sealed record Sort10 : StringEnum<Sort10>
{
    private Sort10(string value) : base(value)
    {
    }

    public static readonly Sort10 Relevant = new("relevant");

    public static readonly Sort10 Newest = new("newest");

    public static readonly Sort10 Oldest = new("oldest");

    public static Sort10 FromValue(string value) => FromValueCore(value);
}

using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort1>))]
public sealed record Sort1 : StringEnum<Sort1>
{
    private Sort1(string value) : base(value)
    {
    }

    public static readonly Sort1 Newest = new("newest");

    public static readonly Sort1 Oldest = new("oldest");

    public static Sort1 FromValue(string value) => FromValueCore(value);
}

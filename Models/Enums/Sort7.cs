using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Sort7>))]
public sealed record Sort7 : StringEnum<Sort7>
{
    private Sort7(string value) : base(value)
    {
    }

    public static readonly Sort7 Newest = new("newest");

    public static readonly Sort7 LastUpdated = new("last_updated");

    public static readonly Sort7 ItemCount = new("item_count");

    public static Sort7 FromValue(string value) => FromValueCore(value);
}

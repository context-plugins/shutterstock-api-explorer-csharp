using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SortOrder>))]
public sealed record SortOrder : StringEnum<SortOrder>
{
    private SortOrder(string value) : base(value)
    {
    }

    public static readonly SortOrder Asc = new("asc");

    public static readonly SortOrder Desc = new("desc");

    public static SortOrder FromValue(string value) => FromValueCore(value);
}

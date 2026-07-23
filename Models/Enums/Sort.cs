using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Sort by
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Sort>))]
public sealed record Sort : StringEnum<Sort>
{
    private Sort(string value) : base(value)
    {
    }

    public static readonly Sort Newest = new("newest");

    public static readonly Sort Popular = new("popular");

    public static readonly Sort Relevance = new("relevance");

    public static readonly Sort Random = new("random");

    public static Sort FromValue(string value) => FromValueCore(value);
}

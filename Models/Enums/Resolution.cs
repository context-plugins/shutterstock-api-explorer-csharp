using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Resolution>))]
public sealed record Resolution : StringEnum<Resolution>
{
    private Resolution(string value) : base(value)
    {
    }

    public static readonly Resolution _4K = new("4k");

    public static readonly Resolution HighDefinition = new("high_definition");

    public static readonly Resolution StandardDefinition = new("standard_definition");

    public static Resolution FromValue(string value) => FromValueCore(value);
}

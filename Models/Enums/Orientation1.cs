using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Orientation1>))]
public sealed record Orientation1 : StringEnum<Orientation1>
{
    private Orientation1(string value) : base(value)
    {
    }

    public static readonly Orientation1 Horizontal = new("horizontal");

    public static readonly Orientation1 Vertical = new("vertical");

    public static Orientation1 FromValue(string value) => FromValueCore(value);
}

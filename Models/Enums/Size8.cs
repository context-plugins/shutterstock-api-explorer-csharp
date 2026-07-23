using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Size8>))]
public sealed record Size8 : StringEnum<Size8>
{
    private Size8(string value) : base(value)
    {
    }

    public static readonly Size8 Small = new("small");

    public static readonly Size8 Medium = new("medium");

    public static readonly Size8 Huge = new("huge");

    public static readonly Size8 Vector = new("vector");

    public static readonly Size8 Custom = new("custom");

    public static Size8 FromValue(string value) => FromValueCore(value);
}

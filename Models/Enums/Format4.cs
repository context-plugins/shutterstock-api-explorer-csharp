using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Format4>))]
public sealed record Format4 : StringEnum<Format4>
{
    private Format4(string value) : base(value)
    {
    }

    public static readonly Format4 Eps = new("eps");

    public static readonly Format4 Jpg = new("jpg");

    public static Format4 FromValue(string value) => FromValueCore(value);
}

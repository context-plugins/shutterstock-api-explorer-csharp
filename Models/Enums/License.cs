using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<License>))]
public sealed record License : StringEnum<License>
{
    private License(string value) : base(value)
    {
    }

    public static readonly License Commercial = new("commercial");

    public static readonly License Editorial = new("editorial");

    public static readonly License Enhanced = new("enhanced");

    public static License FromValue(string value) => FromValueCore(value);
}

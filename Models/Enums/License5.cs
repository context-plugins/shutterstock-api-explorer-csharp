using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<License5>))]
public sealed record License5 : StringEnum<License5>
{
    private License5(string value) : base(value)
    {
    }

    public static readonly License5 Commercial = new("commercial");

    public static readonly License5 Editorial = new("editorial");

    public static License5 FromValue(string value) => FromValueCore(value);
}

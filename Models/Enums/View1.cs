using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<View1>))]
public sealed record View1 : StringEnum<View1>
{
    private View1(string value) : base(value)
    {
    }

    public static readonly View1 Minimal = new("minimal");

    public static readonly View1 Full = new("full");

    public static View1 FromValue(string value) => FromValueCore(value);
}

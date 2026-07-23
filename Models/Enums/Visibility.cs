using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Visibility>))]
public sealed record Visibility : StringEnum<Visibility>
{
    private Visibility(string value) : base(value)
    {
    }

    public static readonly Visibility Private = new("private");

    public static readonly Visibility Public = new("public");

    public static Visibility FromValue(string value) => FromValueCore(value);
}

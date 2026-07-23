using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Realm2>))]
public sealed record Realm2 : StringEnum<Realm2>
{
    private Realm2(string value) : base(value)
    {
    }

    public static readonly Realm2 Customer = new("customer");

    public static readonly Realm2 Contributor = new("contributor");

    public static Realm2 FromValue(string value) => FromValueCore(value);
}

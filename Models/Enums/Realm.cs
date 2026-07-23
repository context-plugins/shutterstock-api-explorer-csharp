using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Type of access token
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Realm>))]
public sealed record Realm : StringEnum<Realm>
{
    private Realm(string value) : base(value)
    {
    }

    public static readonly Realm Customer = new("customer");

    public static readonly Realm Contributor = new("contributor");

    public static Realm FromValue(string value) => FromValueCore(value);
}

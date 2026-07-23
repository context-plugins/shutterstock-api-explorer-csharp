using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// User type to be authorized (usually 'customer')
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Realm1>))]
public sealed record Realm1 : StringEnum<Realm1>
{
    private Realm1(string value) : base(value)
    {
    }

    public static readonly Realm1 Customer = new("customer");

    public static readonly Realm1 Contributor = new("contributor");

    public static Realm1 FromValue(string value) => FromValueCore(value);
}

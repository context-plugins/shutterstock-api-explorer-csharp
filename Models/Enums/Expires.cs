using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Whether or not the token expires, expiring tokens come with a refresh_token to renew the access_token
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Expires>))]
public sealed record Expires : StringEnum<Expires>
{
    private Expires(string value) : base(value)
    {
    }

    public static readonly Expires True = new("true");

    public static readonly Expires False = new("false");

    public static Expires FromValue(string value) => FromValueCore(value);
}

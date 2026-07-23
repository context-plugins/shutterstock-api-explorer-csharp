using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Core.Enum;

namespace ShutterstockApiExplorer.Models.Enums;

/// <summary>
/// Grant type: authorization_code generates user tokens, client_credentials generates short-lived client grants
/// </summary>
[JsonConverter(typeof(StringEnumConverter<GrantType>))]
public sealed record GrantType : StringEnum<GrantType>
{
    private GrantType(string value) : base(value)
    {
    }

    public static readonly GrantType AuthorizationCode = new("authorization_code");

    public static readonly GrantType ClientCredentials = new("client_credentials");

    public static readonly GrantType RefreshToken = new("refresh_token");

    public static GrantType FromValue(string value) => FromValueCore(value);
}

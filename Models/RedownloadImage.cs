using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Data required to redownload an image
/// </summary>
public record RedownloadImage
{
    /// <summary>
    /// Cookie object
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("auth_cookie")]
    public Cookie? AuthCookie { get; init; }

    /// <summary>
    /// (Deprecated)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("show_modal")]
    public bool? ShowModal { get; init; }

    /// <summary>
    /// Size of the image
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public Size6? Size { get; init; }

    /// <summary>
    /// (Deprecated)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("verification_code")]
    public string? VerificationCode { get; init; }
}

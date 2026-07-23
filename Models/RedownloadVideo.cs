using System.Text.Json.Serialization;
using ShutterstockApiExplorer.Models.Enums;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Data required to redownload a video
/// </summary>
public record RedownloadVideo
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
    /// Size of the video
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("size")]
    public Size7? Size { get; init; }

    /// <summary>
    /// (Deprecated)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("verification_code")]
    public string? VerificationCode { get; init; }
}

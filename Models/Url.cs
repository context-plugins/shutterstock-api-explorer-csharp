using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// URL object
/// </summary>
public record Url
{
    /// <summary>
    /// URL that can be used to download the unwatermarked, licensed asset
    /// </summary>
    [JsonPropertyName("url")]
    public required string UrlValue { get; init; }
}

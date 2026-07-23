using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Sound effect license URL object
/// </summary>
public record SfxUrl
{
    /// <summary>
    /// URL that can be used to download the unwatermarked, licensed asset
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}

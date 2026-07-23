using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Video preview information
/// </summary>
public record VideoPreviewUrl
{
    /// <summary>
    /// Direct URL to the image
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}

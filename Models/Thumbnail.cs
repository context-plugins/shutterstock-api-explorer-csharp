using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Image thumbnail information
/// </summary>
public record Thumbnail
{
    /// <summary>
    /// Height in pixels of the image thumbnail
    /// </summary>
    [JsonPropertyName("height")]
    public required int Height { get; init; }

    /// <summary>
    /// Direct URL to the image
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    /// <summary>
    /// Width in pixels of the image thumbnail
    /// </summary>
    [JsonPropertyName("width")]
    public required int Width { get; init; }
}

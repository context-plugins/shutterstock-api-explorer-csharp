using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Featured collection cover item metadata
/// </summary>
public record FeaturedCollectionCoverItem
{
    /// <summary>
    /// URL of the collection cover item
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}

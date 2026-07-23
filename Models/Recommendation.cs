using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Media Recommendation
/// </summary>
public record Recommendation
{
    /// <summary>
    /// Media ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}

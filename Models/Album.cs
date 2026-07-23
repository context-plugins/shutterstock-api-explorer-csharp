using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Album metadata
/// </summary>
public record Album
{
    /// <summary>
    /// The album ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The album title
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }
}

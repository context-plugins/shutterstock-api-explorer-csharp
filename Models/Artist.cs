using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Metadata about the artist that created the media
/// </summary>
public record Artist
{
    /// <summary>
    /// The artist's name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

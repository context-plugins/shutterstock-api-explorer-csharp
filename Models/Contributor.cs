using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a contributor
/// </summary>
public record Contributor
{
    /// <summary>
    /// ID of the contributor
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}

using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Collection creation request
/// </summary>
public record CollectionCreateRequest
{
    /// <summary>
    /// The name of the collection
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

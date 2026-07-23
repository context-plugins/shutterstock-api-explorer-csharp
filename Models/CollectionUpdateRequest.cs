using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Collection update request
/// </summary>
public record CollectionUpdateRequest
{
    /// <summary>
    /// The new name of the collection
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

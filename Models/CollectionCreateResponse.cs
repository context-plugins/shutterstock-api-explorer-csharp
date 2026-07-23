using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Collection creation response
/// </summary>
public record CollectionCreateResponse
{
    /// <summary>
    /// ID of the new collection
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}

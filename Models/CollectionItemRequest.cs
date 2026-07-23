using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Request to get a list of items in a collection
/// </summary>
public record CollectionItemRequest
{
    /// <summary>
    /// List of items
    /// </summary>
    [JsonPropertyName("items")]
    public required IReadOnlyList<CollectionItem> Items { get; init; }
}

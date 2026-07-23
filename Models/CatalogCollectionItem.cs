using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Metadata about an item that is part of a collection
/// </summary>
public record CatalogCollectionItem
{
    [JsonPropertyName("asset")]
    public required Asset Asset { get; init; }

    /// <summary>
    /// The collection IDs that this asset belongs to
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("collection_ids")]
    public IReadOnlyList<string>? CollectionIds { get; init; }

    [JsonPropertyName("created_time")]
    public required DateTimeOffset CreatedTime { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }
}

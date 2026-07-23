using System;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Metadata about a collection of assets
/// </summary>
public record Collection
{
    /// <summary>
    /// Metadata about an item that is part of a collection
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cover_item")]
    public CollectionItem? CoverItem { get; init; }

    /// <summary>
    /// When the collection was created
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("created_time")]
    public DateTimeOffset? CreatedTime { get; init; }

    /// <summary>
    /// The collection ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The last time this collection's items were updated
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items_updated_time")]
    public DateTimeOffset? ItemsUpdatedTime { get; init; }

    /// <summary>
    /// The name of the collection
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// A code that can be used to share the collection (optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("share_code")]
    public string? ShareCode { get; init; }

    /// <summary>
    /// The browser URL that can be used to share the collection (optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("share_url")]
    public string? ShareUrl { get; init; }

    /// <summary>
    /// The number of items in the collection
    /// </summary>
    [JsonPropertyName("total_item_count")]
    public required int TotalItemCount { get; init; }

    /// <summary>
    /// The last time the collection was update (other than changes to the items in it)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_time")]
    public DateTimeOffset? UpdatedTime { get; init; }
}

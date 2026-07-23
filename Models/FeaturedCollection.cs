using System;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Metadata about a featured collection
/// </summary>
public record FeaturedCollection
{
    /// <summary>
    /// Featured collection cover item metadata
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cover_item")]
    public FeaturedCollectionCoverItem? CoverItem { get; init; }

    /// <summary>
    /// Date that the collection was created
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("created_time")]
    public DateTimeOffset? CreatedTime { get; init; }

    /// <summary>
    /// Featured collection cover item metadata
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hero_item")]
    public FeaturedCollectionCoverItem? HeroItem { get; init; }

    /// <summary>
    /// Collection ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Date that an item in the collection was last added or removed
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items_updated_time")]
    public DateTimeOffset? ItemsUpdatedTime { get; init; }

    /// <summary>
    /// Name of the collection
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Unique share url for the collection
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("share_url")]
    public string? ShareUrl { get; init; }

    /// <summary>
    /// Total number of items in the collection
    /// </summary>
    [JsonPropertyName("total_item_count")]
    public required int TotalItemCount { get; init; }

    /// <summary>
    /// Date that the collection was last modified
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updated_time")]
    public DateTimeOffset? UpdatedTime { get; init; }
}

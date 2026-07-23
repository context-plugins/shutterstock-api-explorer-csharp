using System;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Metadata about an item that is part of a collection
/// </summary>
public record CollectionItem
{
    /// <summary>
    /// The date the item was added to the collection
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("added_time")]
    public DateTimeOffset? AddedTime { get; init; }

    /// <summary>
    /// ID of the item
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The media type of the item, such as image, video, or audio
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("media_type")]
    public string? MediaType { get; init; }
}

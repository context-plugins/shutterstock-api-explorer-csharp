using System;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Metadata about editorial livefeed
/// </summary>
public record EditorialLivefeed
{
    /// <summary>
    /// Cover image for editorial livefeed
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cover_item")]
    public EditorialCoverItem? CoverItem { get; init; }

    /// <summary>
    /// When the livefeed was initially created
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("created_time")]
    public DateTimeOffset? CreatedTime { get; init; }

    /// <summary>
    /// Livefeed ID
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Name of the livefeed
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Total count of items in the livefeed
    /// </summary>
    [JsonPropertyName("total_item_count")]
    public required int TotalItemCount { get; init; }
}

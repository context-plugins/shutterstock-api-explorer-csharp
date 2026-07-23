using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a piece of updated media
/// </summary>
public record UpdatedMedia
{
    /// <summary>
    /// ID of the media
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Date that the media was updated
    /// </summary>
    [JsonPropertyName("updated_time")]
    public required DateTimeOffset UpdatedTime { get; init; }

    /// <summary>
    /// Types of updates that were made to the piece of media
    /// </summary>
    [JsonPropertyName("updates")]
    public required IReadOnlyList<string> Updates { get; init; }
}

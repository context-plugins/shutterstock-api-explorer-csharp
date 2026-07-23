using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of editorial livefeeds
/// </summary>
public record EditorialImageLivefeedList
{
    /// <summary>
    /// Editorial livefeeds
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<EditorialLivefeed> Data { get; init; }

    /// <summary>
    /// Optional error message
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>
    /// Current page of the response
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("page")]
    public int? Page { get; init; }

    /// <summary>
    /// Number of results per page
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("per_page")]
    public int? PerPage { get; init; }

    /// <summary>
    /// Total count of all results
    /// </summary>
    [JsonPropertyName("total_count")]
    public required int TotalCount { get; init; }
}

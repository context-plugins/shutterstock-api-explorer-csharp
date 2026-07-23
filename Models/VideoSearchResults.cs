using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Video search results
/// </summary>
public record VideoSearchResults
{
    /// <summary>
    /// List of videos
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Video> Data { get; init; }

    /// <summary>
    /// Server-generated message, if any
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>
    /// Current page that is returned
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
    /// Unique identifier for the search request
    /// </summary>
    [JsonPropertyName("search_id")]
    public required string SearchId { get; init; }

    /// <summary>
    /// Total count of all results across all pages
    /// </summary>
    [JsonPropertyName("total_count")]
    public required int TotalCount { get; init; }
}

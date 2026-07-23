using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Editorial search results
/// </summary>
public record EditorialSearchResults
{
    /// <summary>
    /// Editorial items
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<EditorialContent> Data { get; init; }

    /// <summary>
    /// Optional error message
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    /// <summary>
    /// Cursor value that represents the next page of results
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("next")]
    public string? Next { get; init; }

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
    /// Cursor value that represents the previous page of results
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prev")]
    public string? Prev { get; init; }

    /// <summary>
    /// Unique identifier for the search request
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search_id")]
    public string? SearchId { get; init; }

    /// <summary>
    /// Total count of all results
    /// </summary>
    [JsonPropertyName("total_count")]
    public required int TotalCount { get; init; }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Image search results
/// </summary>
public record ImageSearchResults
{
    /// <summary>
    /// List of images
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<Image> Data { get; init; }

    /// <summary>
    /// AI-powered insights about an asset, based on the specified audience and objective
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("insights")]
    public Insights? Insights { get; init; }

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
    /// Returns information if search phrase has potentially been mistyped or another query would lead to better search results
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("spellcheck_info")]
    public object? SpellcheckInfo { get; init; }

    /// <summary>
    /// Total count of all results across all pages
    /// </summary>
    [JsonPropertyName("total_count")]
    public required int TotalCount { get; init; }
}

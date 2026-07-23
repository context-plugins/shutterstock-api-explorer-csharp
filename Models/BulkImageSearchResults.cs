using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of search results for each given query
/// </summary>
public record BulkImageSearchResults
{
    /// <summary>
    /// Unique identifier for the search request
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bulk_search_id")]
    public string? BulkSearchId { get; init; }

    /// <summary>
    /// List of image search results
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("results")]
    public IReadOnlyList<ImageSearchResults>? Results { get; init; }
}

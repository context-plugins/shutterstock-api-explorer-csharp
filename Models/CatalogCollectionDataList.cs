using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of catalog collections
/// </summary>
public record CatalogCollectionDataList
{
    /// <summary>
    /// List of catalog collections
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<CatalogCollection> Data { get; init; }

    [JsonPropertyName("page")]
    public required double Page { get; init; }

    [JsonPropertyName("per_page")]
    public required double PerPage { get; init; }

    [JsonPropertyName("total_count")]
    public required double TotalCount { get; init; }
}

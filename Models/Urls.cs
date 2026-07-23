using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of URLs
/// </summary>
public record Urls
{
    /// <summary>
    /// URLs
    /// </summary>
    [JsonPropertyName("urls")]
    public required IReadOnlyList<string> UrlsValue { get; init; }
}

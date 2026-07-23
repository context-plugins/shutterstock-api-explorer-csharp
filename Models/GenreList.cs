using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of audio genres
/// </summary>
public record GenreList
{
    /// <summary>
    /// List of genres
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<string> Data { get; init; }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// List of audio moods
/// </summary>
public record MoodList
{
    /// <summary>
    /// List of audio moods
    /// </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<string> Data { get; init; }
}

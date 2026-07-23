using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Audio License URL object
/// </summary>
public record AudioUrl
{
    /// <summary>
    /// URL that can be used to download the .zip file containing shorts, loops, and stems
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shorts_loops_stems")]
    public string? ShortsLoopsStems { get; init; }

    /// <summary>
    /// URL that can be used to download the unwatermarked, licensed asset
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}

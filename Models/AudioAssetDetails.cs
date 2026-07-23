using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a file that is part of an audio asset
/// </summary>
public record AudioAssetDetails
{
    /// <summary>
    /// File size of the track
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("file_size")]
    public int? FileSize { get; init; }

    /// <summary>
    /// URL the track is available at
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}

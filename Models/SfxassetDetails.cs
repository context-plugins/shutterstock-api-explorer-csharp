using System.Text.Json.Serialization;

namespace ShutterstockApiExplorer.Models;

/// <summary>
/// Information about a file that is part of an sound effect asset
/// </summary>
public record SfxassetDetails
{
    /// <summary>
    /// File size of the sound effect
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("file_size")]
    public int? FileSize { get; init; }

    /// <summary>
    /// URL the sound effect is available at
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}
